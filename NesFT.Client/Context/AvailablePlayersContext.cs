using NesFT.Models;

namespace NesFT.Client.Context
{
    public class AvailablePlayersContext
    {
        public List<Player> players { get; set; } = new();
        public Action PlayersHaveChanged { get; set; }
    }
}
