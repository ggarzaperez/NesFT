using NesFT.Models;

namespace NesFT.Data.Repositories
{
    public class GamesRepository
    {
        public List<Game> Games { get; set; }

        public GamesRepository()
        {
            Games = new List<Game>{
                new Game{Id=Guid.NewGuid(), Title="TMNT III: Manhattan Project", ImageName="ninja_turtles_manhattan_project.jfif", YearPublished=1991},
                new Game{Id=Guid.NewGuid(), Title="Ducktales", ImageName="ducktales.jpg", YearPublished=1989},
                new Game{Id=Guid.NewGuid(), Title="Dr. Mario", ImageName="drmario.jpg", YearPublished=1990},
                new Game{Id=Guid.NewGuid(), Title="Super Mario 3", ImageName="supermario3.jfif", YearPublished=1988},
                new Game{Id=Guid.NewGuid(), Title="Wario Woods", ImageName="wariowoods.jfif", YearPublished=1994},
                new Game{Id=Guid.NewGuid(), Title="Tetris", ImageName="tetris.jpg", YearPublished=1989}
            };
        }

        public IReadOnlyList<Game> Get()
        {
            return Games; 
        }

        public void Upsert(Game game)
        {
            if (Games.Exists(g => g.Title == game.Title)) return;

            Games.Add(game);
        }
    }
}
