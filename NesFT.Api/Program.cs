using NesFT.Api.Hubs;
using NesFT.Models;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.AspNetCore.SignalR;
using NesFT.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("https://localhost:7066")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();
        });
});

builder.Services.AddResponseCompression(opts =>
{
    opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
        new[] { "application/octet-stream" });
});

builder.Services.AddSingleton<GamesRepository>();
builder.Services.AddSingleton<PlayersRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapHub<PlayersHub>("/playershub");


app.MapGet("/games", (GamesRepository gameRepo) =>
{
    return gameRepo.Get();
});

app.MapPut("/games", (Game newGame, GamesRepository gamesRepo) =>
{
    gamesRepo.Upsert(newGame);
    return newGame;
});

app.MapGet("/players", (PlayersRepository playersRepo) => {
    return playersRepo.Get();
});

app.MapGet("/players/{email}", (string email, PlayersRepository playersRepo) => {
    var player = playersRepo.Get(email);
    return (player == null ? Results.NotFound() : Results.Ok(player));
});

app.MapPut("/players", async (Player player, PlayersRepository playersRepo, IHubContext<PlayersHub> hubContext) =>
{
    playersRepo.Upsert(player);
    await hubContext.Clients.All.SendAsync("PlayerCreated", player);
    return player;
});

app.UseCors();

app.Run();
