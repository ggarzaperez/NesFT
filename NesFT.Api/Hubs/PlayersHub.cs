using NesFT.Models;
using Microsoft.AspNetCore.SignalR;
using NesFT.Data.Repositories;

namespace NesFT.Api.Hubs
{
    public class PlayersHub : Hub
    {
        public PlayersRepository PlayersRepo { get; }

        public PlayersHub(PlayersRepository playersRepo)
        {
            PlayersRepo = playersRepo;
        }

        public async Task Connect(string email)
        {
            PlayersRepo.UpdateOnlineStatus(email, true);
            await Clients.All.SendAsync("PlayerOnline", email);
        }

        public async Task Disconnect(string email)
        {
            PlayersRepo.UpdateOnlineStatus(email, false);
            await Clients.All.SendAsync("PlayerOffline", email);
        }

        public async Task Created(Player player)
        {
            await Clients.All.SendAsync("PlayerCreated", player);
        }
    }
}
