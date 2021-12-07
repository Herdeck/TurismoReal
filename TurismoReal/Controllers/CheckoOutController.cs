using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TurismoReal.Negocio;

namespace TurismoReal.Controllers
{
    public class CheckoOutController : Controller
    {
        // GET: CheckoOut
        public ActionResult Index()
        {

            ViewBag.checkin = new CheckOut().ReadAll();
            return View();
        }

        // GET: CheckoOut/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CheckoOut/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CheckoOut/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "IdCheckOut,IdMulta,IdDepto,IdReserva,DocumentoEntrega")] CheckOut checkout)
        {
            try
            {
                // TODO: Add insert logic here
                checkout.Save();
                TempData["mensaje"] = "Item guardado corectamente";
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Create");
            }
        }

        // GET: CheckoOut/Edit/5
        public ActionResult Edit(int id)
        {
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
        }

        // POST: CheckoOut/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "IdCheckOut,IdMulta,IdDepto,IdReserva,DocumentoEntrega")] CheckOut checkout)
        {
            try
            {
                // TODO: Add update logic here
                checkout.Update();
                TempData["mensaje"] = "editado correctamente";
                return RedirectToAction("Index");
            }
            catch
            {
                return View(checkout);
            }
        }
        

        // GET: CheckoOut/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CheckoOut/Delete/5
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
