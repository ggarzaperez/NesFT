using NesFT.Models;
using System.Net.Http.Json;

namespace NesFT.Client.Services
{
    public class PlayersService
    {
        private HttpClient HttpClient { get; }

        public PlayersService(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public async Task<List<Player>?> Get()
        {
            return await HttpClient.GetFromJsonAsync<List<Player>>("players");
        }

        public async Task<Player?> GetPlayerByEmail(string email)
        {
            return await HttpClient.GetFromJsonAsync<Player>($"players/{email}");
        }

        public async Task<HttpResponseMessage> UpsertPlayer(Player player)
        {
            return await HttpClient.PutAsJsonAsync("players", player);
        }
    }
}
