namespace NesFT.Models
{
    public class Player
    {
        public string Email { get; set; } = "";
        public string Nickname { get; set; } = "";
        public string WinQuote { get; set; } = "";
        public bool Online { get; set; } = false;
        public Guid FavoriteGameId { get; set; }
    }
}
