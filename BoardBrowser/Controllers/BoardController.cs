using BoardBrowser.Models;
using BoardBrowser.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BoardBrowser.Controllers
{
    public class BoardController : Controller
    {
        // GET: Board
        [Authorize]
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new BoardServices(userId);
            var model = service.GetBoards();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BoardCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateBoardService();

            if (service.CreateBoard(model))
            {
                TempData["SaveResult"] = "Your board was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Board could not be created.");

            return View(model);
        }

        private BoardServices CreateBoardService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new BoardServices(userId);
            return service;
        }

        public ActionResult Details(int id)
        {
            var svc = CreateBoardService();
            var model = svc.GetBoardById(id);

            return View(model);
        }

    }
}