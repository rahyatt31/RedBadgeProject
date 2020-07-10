using GameLibrary.Model.Publisher;
using GameLibrary.Service;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameLibrary.WebMVC.Controllers
{
    public class PublisherController : Controller
    {
        // GET: Publisher
        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.PublisherIDSortParm = String.IsNullOrEmpty(sortOrder) ? "publisherID_desc" : "";
            ViewBag.PublisherNameSortParm = sortOrder == "publisherName" ? "publisherName_desc" : "publisherName";
            ViewBag.PublisherFounderSortParm = sortOrder == "publisherFounder" ? "publisherFounder_desc" : "publisherFounder";
            ViewBag.PublisherLocationSortParm = sortOrder == "publisherLocation" ? "publisherLocation_desc" : "publisherLocation";
            ViewBag.PublisherYearEstablishedSortParm = sortOrder == "publisherYearEstablished" ? "publisherYearEstablished_desc" : "publisherYearEstablished";
            ViewBag.PublisherMostPopularGameSortParm = sortOrder == "publisherMostPopularGame" ? "publisherMostPopularGame_desc" : "publisherMostPopularGame";

            PublisherService service = CreatePublisherService();
            var model = service.SortPublishers(sortOrder, searchString);

            return View(model);
        }

        private PublisherService CreatePublisherService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PublisherService(userId);
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
        public ActionResult Create(PublisherCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreatePublisherService();

            if (service.CreatePublisher(model))
            {
                TempData["SaveResult"] = "The publisher was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Publisher could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreatePublisherService();
            var model = svc.GetPublisherByID(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreatePublisherService();
            var detail = service.GetPublisherByID(id);
            var model =
                new PublisherEdit
                {
                    PublisherID = detail.PublisherID,
                    PublisherName = detail.PublisherName,
                    PublisherFounder = detail.PublisherFounder,
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PublisherEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.PublisherID != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }

            var service = CreatePublisherService();

            if (service.UpdatePublisher(model))
            {
                TempData["SaveResult"] = "The publisher was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The publisher could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreatePublisherService();
            var model = svc.GetPublisherByID(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePublisher(int id)
        {
            var service = CreatePublisherService();

            service.DeletePublisher(id);

            TempData["SaveResult"] = "The publisher was deleted";

            return RedirectToAction("Index");
        }
    }
}