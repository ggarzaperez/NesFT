using Microsoft.AspNetCore.SignalR;
using NesFT.Data.Repositories;
using NesFT.Models;

namespace NesFt.Api.Hubs
{
    public class GamesHub : Hub
    {
        public GamesRepository GamesRepo { get; }

        public GamesHub(GamesRepository gamesRepo)
        {
            GamesRepo = gamesRepo;
        }

        public async Task Created(Game game)
        {
            await Clients.All.SendAsync("GameCreated", game);
        }
    }
}
