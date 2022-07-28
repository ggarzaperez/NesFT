using NesFT.Models;
using System.Net.Http.Json;

namespace NesFT.Client.Services
{
    public class GamesService
    {
        private HttpClient HttpClient { get; }

        public GamesService(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public async Task<List<Game>?> Get()
        {
            return await HttpClient.GetFromJsonAsync<List<Game>>("games");
        }

        public async Task<HttpResponseMessage> Upsert(Game game)
        {
            return await HttpClient.PutAsJsonAsync("games", game);
        }
    }
}
