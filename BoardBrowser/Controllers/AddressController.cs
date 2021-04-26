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
    public class AddressController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new AddressService(userId);
            var model = service.GetAddresses();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AddressCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateAddressService();

            if (service.CreateAddress(model))
            {
                TempData["SaveResult"] = "Your address was saved.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Address could not be saved.");

            return View(model);
        }

        private AddressService CreateAddressService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new AddressService(userId);
            return service;
        }

        public ActionResult Details(int id)
        {
            var svc = CreateAddressService();
            var model = svc.GetAddressById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateAddressService();
            var detail = service.GetAddressById(id);
            var model =
                new AddressEdit
                {
                    AddressId = detail.AddressId,
                    AddressLine1 = detail.AddressLine1,
                    AddressLine2 = detail.AddressLine2,
                    State = detail.State,
                    City = detail.City,
                    ZipCode = detail.ZipCode

                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AddressEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.AddressId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateAddressService();

            if (service.UpdateAddress(model))
            {
                TempData["SaveResult"] = "Your address was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your address could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateAddressService();
            var model = svc.GetAddressById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteAddress(int id)
        {
            var service = CreateAddressService();

            service.DeleteAddress(id);

            TempData["SaveResult"] = "Your address was deleted";

            return RedirectToAction("Index");
        }
    }
}
