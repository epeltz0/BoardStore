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

        public ActionResult Edit(int id)
        {
            var service = CreateBoardService();
            var detail = service.GetBoardById(id);
            var model =
                new BoardEdit
                {
                    BoardId = detail.BoardId,
                    BoardCategory = detail.BoardCategory,
                    BoardName = detail.BoardName,
                    Description = detail.Description,
                    Price = detail.Price,
                    BoardQuality = detail.BoardQuality
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, BoardEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.BoardId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateBoardService();

            if (service.UpdateBoard(model))
            {
                TempData["SaveResult"] = "Your board was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your board could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateBoardService();
            var model = svc.GetBoardById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteBoard(int id)
        {
            var service = CreateBoardService();

            service.DeleteBoard(id);

            TempData["SaveResult"] = "Your board was deleted";

            return RedirectToAction("Index");
        }
    }

}
