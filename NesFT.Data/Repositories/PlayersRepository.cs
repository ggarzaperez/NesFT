using NesFT.Models;

namespace NesFT.Data.Repositories
{
    public class PlayersRepository
    {
        private List<Player> Players { get; set; }
        public PlayersRepository()
        {
            Players = new();
        }

        public IReadOnlyList<Player> Get()
        {
            return Players;
        }

        public Player? Get(string email)
        {
            return Players.Find(p => p.Email == email);
        }

        public void Upsert(Player player)
        {
            if (Players.Exists(p => p.Email == player.Email)) return;

            Players.Add(player);
        }

        public void UpdateOnlineStatus(string email, bool newOnlineStatus)
        {
            var player = Get(email);

            if(player is not null)
            {
                player.Online = newOnlineStatus;
            }
        }
    }
}
