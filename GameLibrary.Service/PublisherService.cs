using GameLibrary.Data;
using GameLibrary.Model.Publisher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Service
{
    public class PublisherService
    {
        private readonly Guid _userId;
        public PublisherService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreatePublisher(PublisherCreate model)
        {
            var entity = new Publisher()
            {
                PublisherName = model.PublisherName,
                PublisherFounder = model.PublisherFounder,
                PublisherLocation = model.PublisherLocation,
                PublisherYearEstablished = model.PublisherYearEstablished,
                PublisherMostPopularGame = model.PublisherMostPopularGame,
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Publishers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<PublisherListItem> GetPublisher()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Publishers
                        .Select(
                            e =>
                                new PublisherListItem
                                {
                                    PublisherID = e.PublisherID,
                                    PublisherName = e.PublisherName,
                                    PublisherFounder = e.PublisherFounder,
                                    PublisherLocation = e.PublisherLocation,
                                    PublisherYearEstablished = e.PublisherYearEstablished,
                                    PublisherMostPopularGame = e.PublisherMostPopularGame,
                                }
                        );
                return query.ToArray();
            }
        }

        public PublisherDetail GetPublisherByID(int publisherID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Publishers
                        .Single(e => e.PublisherID == publisherID);
                return
                    new PublisherDetail
                    {
                        PublisherID = entity.PublisherID,
                        PublisherName = entity.PublisherName,
                        PublisherFounder = entity.PublisherFounder,
                        PublisherLocation = entity.PublisherLocation,
                        PublisherYearEstablished = entity.PublisherYearEstablished,
                        PublisherMostPopularGame = entity.PublisherMostPopularGame,
                    };
            }
        }

        public bool UpdatePublisher(PublisherEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Publishers
                        .Single(e => e.PublisherID == model.PublisherID);

                entity.PublisherName = model.PublisherName;
                entity.PublisherFounder = model.PublisherFounder;
                entity.PublisherLocation = model.PublisherLocation;
                entity.PublisherYearEstablished = model.PublisherYearEstablished;
                entity.PublisherMostPopularGame = model.PublisherMostPopularGame;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletePublisher(int publisherID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Publishers
                        .Single(e => e.PublisherID == publisherID);

                ctx.Publishers.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}