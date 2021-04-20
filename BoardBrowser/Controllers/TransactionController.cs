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
    public class TransactionController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TransactionServices(userId);
            var model = service.GetTransactions();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TransactionCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateTransactionService();

            if (service.CreateTransaction(model))
            {
                TempData["SaveResult"] = "Your transaction was posted.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Transaction could not be posted.");

            return View(model);
        }

        private TransactionServices CreateTransactionService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TransactionServices(userId);
            return service;
        }

        public ActionResult Details(int id)
        {
            var svc = CreateTransactionService();
            var model = svc.GetTransactionById(id);

            return View(model);
        }
    }
}