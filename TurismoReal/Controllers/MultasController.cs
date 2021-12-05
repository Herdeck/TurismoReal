using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TurismoReal.Negocio;

namespace TurismoReal.Controllers
{
    [Authorize]
    public class MultasController : Controller
    {
        // GET: Multas
        public ActionResult Index()
        {
            ViewBag.multas = new Multas().ReadAll();
            return View();
        }

        // GET: Multas/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Multas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Multas/Create
        [HttpPost]
        public ActionResult Create([Bind(Include ="Id,Detalle,ValorMulta")]Multas multas)
        {
            try
            {
                // TODO: Add insert logic here
                if (!ModelState.IsValid)
                {
                    ViewBag.multas = new Multas().ReadAll();
                    return View(multas);
                }
                multas.Save();
                TempData["mensaje"] = "Multa creada correctamente";
                return RedirectToAction("Index");
            }
            catch
            {
                return View(multas);
            }
        }

        // GET: Multas/Edit/5
        public ActionResult Edit(int id)
        {
            Multas m = new Multas().Find(id);

            if(m == null)
            {
                TempData["mensaje"] = "Multa no encontrada";
                return RedirectToAction("Index");
            }
            ViewBag.multas = new Multas().ReadAll();
            return View(m);
        }

        // POST: Multas/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,Detalle,ValorMulta")] Multas multas)
        {
            try
            {
                // TODO: Add update logic here
                if (!ModelState.IsValid)
                {
                    ViewBag.multas = new Multas().ReadAll();
                    return View(multas);
                }
                multas.Update();
                TempData["mensaje"] = "Multa editada correctamente";
                return RedirectToAction("Index");
            }
            catch
            {
                return View(multas);
            }
        }

        // GET: Multas/Delete/5
        public ActionResult Delete(int id)
        {
            if (new Multas().Find(id) == null)
            {
                TempData["mensaje"] = "no existe la multa";
                return RedirectToAction("Index");
            }

            if (new Multas().Delete(id))
            {
                TempData["mensaje"] = "Eliminado correctamente";
                return RedirectToAction("Index");
            }
            TempData["mensaje"] = "no se pudo eliminar";
            return RedirectToAction("Index");
        }

        // POST: Multas/Delete/5
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
