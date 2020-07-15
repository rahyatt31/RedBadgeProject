using GameLibrary.Data;
using GameLibrary.Model.Console;
using GameLibrary.Model.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Service
{
    public class GameService
    {
        private readonly Guid _userId;
        public GameService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateGame(GameCreate model)
        {
            var entity = new Game()
            {
                GameName = model.GameName,
                GameGenre = model.GameGenre,
                GameMultiplayer = model.GameMultiplayer,
                GameOnline = model.GameOnline,
                GameAdvisoryRating = model.GameAdvisoryRating,
                GameRating = model.GameRating,
                ConsoleID = model.ConsoleID,
                PublisherID = model.PublisherID,
                GameReleaseDate = model.GameReleaseDate,
                GameGameStop = GameStopRandomizedCost() // I want to set up a random number to be given instead of user input
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Games.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<GameListItem> GetGames()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Games
                        .Select(
                            e =>
                                new GameListItem
                                {
                                    GameID = e.GameID,
                                    GameName = e.GameName,
                                    GameGenre = e.GameGenre,
                                    GameMultiplayer = e.GameMultiplayer,
                                    GameOnline = e.GameOnline,
                                    GameAdvisoryRating = e.GameAdvisoryRating,
                                    GameRating = e.GameRating,
                                    GameReleaseDate = e.GameReleaseDate,
                                    ConsoleName = e.Console.ConsoleName, // Setting this up like this allowed me to view the name of Console instead of just the IDnumber
                                    PublisherName = e.Publisher.PublisherName, // Also had to add properties to my GameListItemModel for this to work
                                    GameGameStop = e.GameGameStop
                                }
                        );
                return query.ToArray();
            }
        }

        public GameDetail GetGameByID(int gameID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Games
                        .Single(e => e.GameID == gameID);
                return
                    new GameDetail
                    {
                        GameID = entity.GameID,
                        GameName = entity.GameName,
                        GameGenre = entity.GameGenre,
                        GameMultiplayer = entity.GameMultiplayer,
                        GameOnline = entity.GameOnline,
                        GameAdvisoryRating = entity.GameAdvisoryRating,
                        GameRating = entity.GameRating,
                        ConsoleName = entity.Console.ConsoleName,
                        PublisherName = entity.Publisher.PublisherName,
                        GameReleaseDate = entity.GameReleaseDate,
                        GameGameStop = entity.GameGameStop
                    };
            }
        }

        public bool UpdateGame(GameEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Games
                        .Single(e => e.GameID == model.GameID);

                entity.GameName = model.GameName;
                entity.GameGenre = model.GameGenre;
                entity.GameMultiplayer = model.GameMultiplayer;
                entity.GameOnline = model.GameOnline;
                entity.GameAdvisoryRating = model.GameAdvisoryRating;
                entity.GameRating = model.GameRating;
                entity.GameReleaseDate = model.GameReleaseDate;
                entity.ConsoleID = model.ConsoleID;
                entity.PublisherID = model.PublisherID;
                entity.GameGameStop = model.GameGameStop;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteGame(int gameID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Games
                        .Single(e => e.GameID == gameID);

                ctx.Games.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        public decimal GameStopRandomizedCost()
        {
            Random number = new Random();
            decimal gameStop = number.Next(0, 300);
            return (gameStop/100);
        }

        public IEnumerable<GameListItem> SortGames(string sortOrder, string searchString)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var games = from s in ctx.Games                          // Similar to line 123
                            select s;

                if (!String.IsNullOrEmpty(searchString))
                {
                    games = games.Where(s => s.GameName.Contains(searchString)
                    || s.Console.ConsoleName.Contains(searchString)
                    || s.Publisher.PublisherName.Contains(searchString));
                }

                switch (sortOrder)
                {
                    case "gameID_desc":
                        games = games.OrderByDescending(s => s.GameID);
                        break;
                    case "gameName":
                        games = games.OrderBy(s => s.GameName);
                        break;
                    case "gameName_desc":
                        games = games.OrderByDescending(s => s.GameName);
                        break;
                    case "gameGenre":
                        games = games.OrderBy(s => s.GameGenre);
                        break;
                    case "gameGenre_desc":
                        games = games.OrderByDescending(s => s.GameGenre);
                        break;
                    case "gameAdvisoryRating":
                        games = games.OrderBy(s => s.GameAdvisoryRating);
                        break;
                    case "gameAdvisoryRating_desc":
                        games = games.OrderByDescending(s => s.GameAdvisoryRating);
                        break;
                    case "gameRating":
                        games = games.OrderBy(s => s.GameRating);
                        break;
                    case "gameRating_desc":
                        games = games.OrderByDescending(s => s.GameRating);
                        break;
                    case "gameReleaseDate":
                        games = games.OrderBy(s => s.GameReleaseDate);
                        break;
                    case "gameReleaseDate_desc":
                        games = games.OrderByDescending(s => s.GameReleaseDate);
                        break;
                    case "consoleID":
                        games = games.OrderBy(s => s.Console.ConsoleName);
                        break;
                    case "consoleID_desc":
                        games = games.OrderByDescending(s => s.Console.ConsoleName);
                        break;
                    case "publisherID":
                        games = games.OrderBy(s => s.Publisher.PublisherName);
                        break;
                    case "publisherID_desc":
                        games = games.OrderByDescending(s => s.Publisher.PublisherName);
                        break;
                    case "gameGameStop":
                        games = games.OrderBy(s => s.GameGameStop);
                        break;
                    case "gameGameStop_desc":
                        games = games.OrderByDescending(s => s.GameGameStop);
                        break;
                    default:
                        games = games.OrderBy(s => s.GameID);
                        break;
                }

                return (games.Select(
                            e =>
                                new GameListItem
                                {
                                    GameID = e.GameID,
                                    GameName = e.GameName,
                                    GameGenre = e.GameGenre,
                                    GameMultiplayer = e.GameMultiplayer,
                                    GameOnline = e.GameOnline,
                                    GameAdvisoryRating = e.GameAdvisoryRating,
                                    GameRating = e.GameRating,
                                    GameReleaseDate = e.GameReleaseDate,
                                    ConsoleName = e.Console.ConsoleName,
                                    PublisherName = e.Publisher.PublisherName,
                                    GameGameStop = e.GameGameStop
                                }
                        ).ToList());
            }
        }
    }
}