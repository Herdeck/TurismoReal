using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TurismoReal.Negocio;
namespace TurismoReal.Controllers
{
    public class MultaController : Controller
    {
        // GET: Multa
        public ActionResult Index()
        {
            ViewBag.multa = new Multa().ReadAll();

            return View();
        }

        // GET: Multa/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Multa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Multa/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "IdMulta,Detalle,ValorMulta")] Multa multa)
        {
            try
            {
                // TODO: Add insert logic here
                multa.Save();
                TempData["mensaje"] = "Item guardado corectamente";
                return RedirectToAction("IndexMulta");
            
                return RedirectToAction("IndexMulta");
            }
            catch
            {
                return View("Create");
            }
        }

        // GET: Multa/Edit/5
        public ActionResult Edit(int id)
        {
            Multa i = new Multa().Find(id);

            if (i == null)
            {
                TempData["mensaje"] = "el item no existe";
                return RedirectToAction("IndexMulta");
            }
            ViewBag.multa = new Multa().ReadAll();
         

            return View(i);
        }

        // POST: Multa/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include ="IdMulta,Detalle,ValorMulta")] Multa multa)
        {
            try
            {
                // TODO: Add update logic here
                multa.Update();
                TempData["mensaje"] = "editado correctamente";
                return RedirectToAction("IndexMulta");
            }
            catch
            {
                return View(multa);
            }
        }

        // GET: Multa/Delete/5
        public ActionResult Delete(int id)
        {

            if (new Multa().Find(id) == null)
            {
                TempData["mensaje"] = "no existe el producto";
                return RedirectToAction("IndexMulta");
            }

            if (new Multa().Delete(id))
            {
                TempData["mensaje"] = "Eliminado correctamente";
                return RedirectToAction("IndexMulta");
            }
            TempData["mensaje"] = "no se pudo eliminar";
            return RedirectToAction("IndexMulta");
        }
    

        // POST: Multa/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("IndexMulta");
            }
            catch
            {
                return View();
            }
        }
    }
}
