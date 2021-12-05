using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TurismoReal.Negocio;

namespace TurismoReal.Controllers
{
    [Authorize]
    public class ReservaController : Controller
    {
        // GET: Reserva
        public ActionResult Index()
        {
            ViewBag.reserva = new Reserva().ReadAll();
            return View();
        }

        // GET: Reserva/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Reserva/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reserva/Create
        [HttpPost]
        public ActionResult Create([Bind(Include ="IdReserva,IdUser,IdDepto,FechaReserva,FechaInicio,FechaTermino")]Reserva reserva)
        {
            try
            {
                // TODO: Add insert logic here
                if (!ModelState.IsValid)
                {
                    ViewBag.reserva = new Reserva().ReadAll();
                    return View(reserva);
                }
                reserva.Save();
                TempData["mensaje"] = "Reserva creada correctamente";
                return RedirectToAction("Index");
            }
            catch
            {
                return View(reserva);
            }
        }

        // GET: Reserva/Edit/5
        public ActionResult Edit(int id)
        {
            Reserva r = new Reserva().Find(id);

            if (r == null)
            {
                TempData["mensaje"] = "Reserva no encontrada";
                return RedirectToAction("Index");
            }
            ViewBag.reserva = new Reserva().ReadAll();
            return View(r);
        }

        // POST: Reserva/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "IdReserva,IdUser,IdDepto,FechaReserva,FechaInicio,FechaTermino")] Reserva reserva)
        {
            try
            {
                // TODO: Add update logic here
                if (!ModelState.IsValid)
                {
                    ViewBag.reserva = new Reserva().ReadAll();
                    return View(reserva);
                }
                reserva.Update();
                TempData["mensaje"] = "Reserva editada correctamente";
                return RedirectToAction("Index");
            }
            catch
            {
                return View(reserva);
            }
        }

        // GET: Reserva/Delete/5
        public ActionResult Delete(int id)
        {
            if (new Reserva().Find(id) == null)
            {
                TempData["mensaje"] = "no se encontro la reserva";
                return RedirectToAction("Index");
            }
            if (new Reserva().Delete(id))
            {
                TempData["mensaje"] = "Eliminado correctamente";
                return RedirectToAction("Index");
            }
            TempData["mensaje"] = "no se pudo eliminar";
            return RedirectToAction("Index");
        }

        // POST: Reserva/Delete/5
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
