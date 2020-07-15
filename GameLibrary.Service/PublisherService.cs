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
                                    PublisherMostPopularGame = e.PublisherMostPopularGame
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

        public IEnumerable<PublisherListItem> SortPublishers(string sortOrder, string searchString)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var publishers = from s in ctx.Publishers
                               select s;

                if (!String.IsNullOrEmpty(searchString))
                {
                    publishers = publishers.Where(s => s.PublisherName.Contains(searchString)
                                                    || s.PublisherLocation.Contains(searchString));
                }

                switch (sortOrder)
                {
                    case "publisherID_desc":
                        publishers = publishers.OrderByDescending(s => s.PublisherID);
                        break;
                    case "publisherName":
                        publishers = publishers.OrderBy(s => s.PublisherName);
                        break;
                    case "publisherName_desc":
                        publishers = publishers.OrderByDescending(s => s.PublisherName);
                        break;
                    case "publisherFounder":
                        publishers = publishers.OrderBy(s => s.PublisherFounder);
                        break;
                    case "publisherFounder_desc":
                        publishers = publishers.OrderByDescending(s => s.PublisherFounder);
                        break;
                    case "publisherLocation":
                        publishers = publishers.OrderBy(s => s.PublisherLocation);
                        break;
                    case "publisherLocation_desc":
                        publishers = publishers.OrderByDescending(s => s.PublisherLocation);
                        break;
                    case "publisherYearEstablished":
                        publishers = publishers.OrderBy(s => s.PublisherYearEstablished);
                        break;
                    case "publisherYearEstablished_desc":
                        publishers = publishers.OrderByDescending(s => s.PublisherYearEstablished);
                        break;
                    case "publisherMostPopularGame":
                        publishers = publishers.OrderBy(s => s.PublisherMostPopularGame);
                        break;
                    case "publisherMostPopularGame_desc":
                        publishers = publishers.OrderByDescending(s => s.PublisherMostPopularGame);
                        break;
                    default:
                        publishers = publishers.OrderBy(s => s.PublisherID);
                        break;
                }

                return (publishers.Select(
                            e =>
                                new PublisherListItem
                                {
                                    PublisherID = e.PublisherID,
                                    PublisherName = e.PublisherName,
                                    PublisherFounder = e.PublisherFounder,
                                    PublisherLocation = e.PublisherLocation,
                                    PublisherYearEstablished = e.PublisherYearEstablished,
                                    PublisherMostPopularGame = e.PublisherMostPopularGame
                                }
                        ).ToList());
            }
        }

    }
}