using GameLibrary.Data;
using GameLibrary.Model.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console = GameLibrary.Data.Console;

namespace GameLibrary.Service
{
    public class ConsoleService
    {
        private readonly Guid _userId;
        public ConsoleService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateConsole(ConsoleCreate model)
        {
            var entity = new Console()
            {
                ConsoleName = model.ConsoleName,
                ConsoleCost = model.ConsoleCost,
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Consoles.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ConsoleListItem> GetConsole()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Consoles
                        .Select(
                            e =>
                                new ConsoleListItem
                                {
                                    ConsoleID = e.ConsoleID,
                                    ConsoleName = e.ConsoleName,
                                    ConsoleCost = e.ConsoleCost,
                                }
                        );
                return query.ToArray();
            }
        }

        public ConsoleDetail GetConsoleByID(int consoleID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Consoles
                        .Single(e => e.ConsoleID == consoleID);
                return
                    new ConsoleDetail
                    {
                        ConsoleID = entity.ConsoleID,
                        ConsoleName = entity.ConsoleName,
                        ConsoleCost = entity.ConsoleCost,
                    };
            }
        }

        public bool UpdateConsole(ConsoleEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Consoles
                        .Single(e => e.ConsoleID == model.ConsoleID);

                entity.ConsoleName = model.ConsoleName;
                entity.ConsoleCost = model.ConsoleCost;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteConsole(int ConsoleID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Consoles
                        .Single(e => e.ConsoleID == ConsoleID);

                ctx.Consoles.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
