namespace NesFT.Models
{
    public class Game
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = "";
        public string ImageName { get; set; } = "";
        public int YearPublished { get; set; }
    }
}