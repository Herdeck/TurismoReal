using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TurismoReal.Negocio;

namespace TurismoReal.Controllers
{
    [Authorize]
    public class CheckInController : Controller
    {
        // GET: CheckIn
        public ActionResult Index()
        {
            ViewBag.checkin = new CheckIn().ReadAll();
            return View();
        }

        // GET: CheckIn/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CheckIn/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CheckIn/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "IdCheckIn,IdDepto,IdPago,IdServicio,DocumentacionAceptacion")]CheckIn checkin)
        {
            try
            {
                // TODO: Add insert logic here
                checkin.Save();
                TempData["mensaje"] = "Item guardado corectamente";
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Create");
            }
        }

        // GET: CheckIn/Edit/5
        public ActionResult Edit(int id)
        {
            CheckIn i = new CheckIn().Find(id);

            if (i == null)
            {
                TempData["mensaje"] = "el item no existe";
                return RedirectToAction("Index");
            }
            ViewBag.checkin = new CheckIn().ReadAll();

            return View(i);
        }

        // POST: CheckIn/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "IdCheckIn,IdDepto,IdPago,IdServicio,DocumentacionAceptacion")] CheckIn checkin)
        {
            try
            {
                // TODO: Add update logic here
                checkin.Update();
                TempData["mensaje"] = "editado correctamente";
                return RedirectToAction("Index");
            }
            catch
            {
                return View(checkin);
            }
        }

        // GET: CheckIn/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CheckIn/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
