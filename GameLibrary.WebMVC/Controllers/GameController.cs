using GameLibrary.Model.Game;
using GameLibrary.Service;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameLibrary.WebMVC.Controllers
{
    public class GameController : Controller
    {
        // GET: Game
        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.GameIDSortParm = String.IsNullOrEmpty(sortOrder) ? "gameID_desc" : "";
            ViewBag.GameNameSortParm = sortOrder == "gameName" ? "gameName_desc" : "gameName";
            ViewBag.GameGenreSortParm = sortOrder == "gameGenre" ? "gameGenre_desc" : "gameGenre";
            ViewBag.GameAdvisoryRatingSortParm = sortOrder == "gameAdvisoryRating" ? "gameAdvisoryRating_desc" : "gameAdvisoryRating";
            ViewBag.GameRatingSortParm = sortOrder == "gameRating" ? "gameRating_desc" : "gameRating";
            ViewBag.ConsoleIDSortParm = sortOrder == "consoleID" ? "consoleID_desc" : "consoleID";
            ViewBag.PublisherIDSortParm = sortOrder == "publisherID" ? "publisherID_desc" : "publisherID";
            ViewBag.GameReleaseDateSortParm = sortOrder == "gameReleaseDate" ? "gameReleaseDate_desc" : "gameReleaseDate";
            ViewBag.GameGameStopSortParm = sortOrder == "gameGameStop" ? "gameGameStop_desc" : "gameGameStop";

            GameService service = CreateGameService();
            var model = service.SortGames(sortOrder, searchString);

            return View(model);
        }

        public GameService CreateGameService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new GameService(userId);
            return service;
        }

        // GET: Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GameCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateGameService();

            if (service.CreateGame(model))
            {
                TempData["SaveResult"] = "The game was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Game could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateGameService();
            var model = svc.GetGameByID(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateGameService();
            var detail = service.GetGameByID(id);
            var model =
                new GameEdit
                {
                    GameID = detail.GameID,
                    GameName = detail.GameName,
                    GameGenre = detail.GameGenre,
                    GameMultiplayer = detail.GameMultiplayer,
                    GameOnline = detail.GameOnline,
                    GameAdvisoryRating = detail.GameAdvisoryRating,
                    GameRating = detail.GameRating,
                    ConsoleID = detail.ConsoleID,
                    PublisherID = detail.PublisherID,
                    GameReleaseDate = detail.GameReleaseDate,
                    GameGameStop = detail.GameGameStop
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, GameEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.GameID != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }

            var service = CreateGameService();

            if (service.UpdateGame(model))
            {
                TempData["SaveResult"] = "The game was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The game could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateGameService();
            var model = svc.GetGameByID(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateGameService();

            service.DeleteGame(id);

            TempData["SaveResult"] = "The game was deleted";

            return RedirectToAction("Index");
        }
    }
}