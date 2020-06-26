using GameLibrary.Data;
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
                    GameReleaseDate = model.GameReleaseDate,
                    //GameGameStop = model.GameGameStop
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
                                    GameGameStop = e.GameGameStop
                                }
                        );
                return query.ToArray();
            }
        }

        public GameDetail GetGameByID(int gameid)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Games
                        .Single(e => e.GameID == gameid);
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
    }
}
