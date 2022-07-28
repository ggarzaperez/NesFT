using NesFT.Client;
using NesFT.Client.JsInterops;
using NesFT.Client.Services;
using NesFT.Client.State;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(sp.GetService<IConfiguration>().GetValue<string>("ApiEndpoint")) });
builder.Services.AddScoped<GamesService>();
builder.Services.AddScoped<PlayersService>();
builder.Services.AddScoped<SweetAlert2>();

builder.Services.AddSingleton<StateManager>();

builder.Services.AddMsalAuthentication(options =>
{
    builder.Configuration.Bind("AzureAd", options.ProviderOptions.Authentication);
});

builder.Services.AddGraphClient("https://graph.microsoft.com/User.Read", "https://graph.microsoft.com/User.Read.All");

await builder.Build().RunAsync();
