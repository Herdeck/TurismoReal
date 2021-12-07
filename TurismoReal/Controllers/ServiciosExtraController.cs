using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TurismoReal.Negocio;

namespace TurismoReal.Controllers
{
    public class ServiciosExtraController : Controller
    {
        // GET: ServiciosExtra
        public ActionResult Index()
        {
            ViewBag.serviciosextra = new ServiciosExtra().ReadAll();
            return View();
        }

        // GET: ServiciosExtra/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ServiciosExtra/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ServiciosExtra/Create
        [HttpPost]
        public ActionResult Create([Bind(Include ="IdServicio,IdReserva,NombreServicio,Descripcion")]ServiciosExtra servicios)
        {
            try
            {
                // TODO: Add insert logic here
                if (!ModelState.IsValid)
                {
                    ViewBag.serviciosextra = new ServiciosExtra().ReadAll();
                    return View(servicios);
                }
                servicios.Save();
                TempData["mensaje"] = "Guardado Correctamente";
                return RedirectToAction("Index");
            }
            catch
            {
                return View(servicios);
            }
        }

        // GET: ServiciosExtra/Edit/5
        public ActionResult Edit(int id)
        {
            ServiciosExtra s = new ServiciosExtra().Find(id);
            if(s == null)
            {
                TempData["mensaje"] = "servicio extra no encontrado";
                return RedirectToAction("Index");
            }
            ViewBag.serviciosextra = new ServiciosExtra().ReadAll();
            return View(s);
        }

        // POST: ServiciosExtra/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "IdServicio,IdReserva,NombreServicio,Descripcion")]ServiciosExtra servicios)
        {
            try
            {
                // TODO: Add update logic here
                if (!ModelState.IsValid)
                {
                    ViewBag.serviciosextra = new ServiciosExtra().ReadAll();
                    return View(servicios);
                }
                servicios.Update();
                TempData["mensaje"] = "Editado correctamente";
                return RedirectToAction("Index");
            }
            catch
            {
                return View(servicios);
            }
        }

        // GET: ServiciosExtra/Delete/5
        public ActionResult Delete(int id)
        {
            if(new ServiciosExtra().Find(id) == null)
            {
                TempData["mensaje"] = "no existe el servicio extra";
                return RedirectToAction("Index");
            }
            if(new ServiciosExtra().Delete(id))
            {
                TempData["mensaje"] = "Eliminado correctamente";
                return RedirectToAction("Index");
            }
            TempData["mensaje"] = "no se pudo eliminar";
            return RedirectToAction("Index");
        }

        // POST: ServiciosExtra/Delete/5
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
