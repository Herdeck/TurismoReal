using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TurismoReal.Negocio;

namespace TurismoReal.Controllers
{
    public class PagoReservaController : Controller
    {
        // GET: PagoReserva
        public ActionResult Index()
        {
            ViewBag.pagoreserva = new PagoReserva().ReadAll();
            return View();
        }

        // GET: PagoReserva/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PagoReserva/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PagoReserva/Create
        [HttpPost]
        public ActionResult Create([Bind(Include ="IdPago,IdReserva,FechaPago,Monto")]PagoReserva pago)
        {
            try
            {
                // TODO: Add insert logic here
                if (!ModelState.IsValid)
                {
                    ViewBag.pagoreserva = new PagoReserva().ReadAll();
                    return View(pago);
                }
                pago.Save();
                TempData["mensaje"] = "pago reserva creado correctamente";
                return RedirectToAction("Index");
            }
            catch
            {
                return View(pago);
            }
        }

        // GET: PagoReserva/Edit/5
        public ActionResult Edit(int id)
        {
            PagoReserva p = new PagoReserva().Find(id);
            if(p == null)
            {
                TempData["mensaje"] ="pago reserva no encontrado";
                return RedirectToAction("Index");
            }
            ViewBag.pagoreserva = new PagoReserva().ReadAll();
            return View(p);
        }

        // POST: PagoReserva/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include ="IdPago,IdReserva,FechaPago,Monto")]PagoReserva pago)
        {
            try
            {
                // TODO: Add update logic here
                if(!ModelState.IsValid)
                {
                    ViewBag.pagoreserva = new PagoReserva().ReadAll();
                    return View(pago);
                }
                pago.Update();
                TempData["mensaje"] = "pago reserva editado correctamente";
                return RedirectToAction("Index");
            }
            catch
            {
                return View(pago);
            }
        }

        // GET: PagoReserva/Delete/5
        public ActionResult Delete(int id)
        {
            if(new PagoReserva().Find(id) == null)
            {
                TempData["mensaje"] ="no se encontro el pago";
                return RedirectToAction("Index");
            }
            if(new PagoReserva().Delete(id))
            {
                TempData["mensaje"] ="Eliminado correctamente";
                return RedirectToAction("Index");
            }
            TempData["mensaje"] ="no se pudo eliminar";
            return RedirectToAction("Index");
        }

        // POST: PagoReserva/Delete/5
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
