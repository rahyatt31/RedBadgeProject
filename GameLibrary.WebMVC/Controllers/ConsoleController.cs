using GameLibrary.Model.Console;
using GameLibrary.Service;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameLibrary.WebMVC.Controllers
{
    public class ConsoleController : Controller
    {
        // GET: Console
        public ActionResult Index()
        {
            ConsoleService service = CreateConsoleService();
            var model = service.GetConsole();

            return View(model);
        }

        private ConsoleService CreateConsoleService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ConsoleService(userId);
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
        public ActionResult Create(ConsoleCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateConsoleService();

            if (service.CreateConsole(model))
            {
                TempData["SaveResult"] = "The console was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Console could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateConsoleService();
            var model = svc.GetConsoleByID(id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ConsoleEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ConsoleID != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }

            var service = CreateConsoleService();

            if (service.UpdateConsole(model))
            {
                TempData["SaveResult"] = "The console was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The console could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateConsoleService();
            var model = svc.GetConsoleByID(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateConsoleService();

            service.DeleteConsole(id);

            TempData["SaveResult"] = "The console was deleted";

            return RedirectToAction("Index");
        }
    }
}