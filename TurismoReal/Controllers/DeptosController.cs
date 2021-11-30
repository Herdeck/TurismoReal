using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TurismoReal.Negocio;

namespace TurismoReal.Controllers
{
    public class DeptosController : Controller
    {
        // GET: Deptos
        public ActionResult Index()
        {
            ViewBag.deptos = new Deptos().ReadAll();
            return View();
        }

        // GET: Deptos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Deptos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Deptos/Create
        [HttpPost]
        public ActionResult Create([Bind(Include ="Id,Disponibilidad,Estado,Region,Comuna,Direccion,PrecioDia")]Deptos deptos)
        {
            try
            {
                // TODO: Add insert logic here
                if(!ModelState.IsValid)
                {
                    ViewBag.deptos = new Deptos().ReadAll();
                    return View(deptos);
                }
                deptos.Save();
                TempData["mensaje"] = "Guardado Corectamente";
                return RedirectToAction("Index");
            }
            catch
            {
                return View(deptos);
            }
        }

        // GET: Deptos/Edit/5
        public ActionResult Edit(int id)
        {

            Deptos d = new Deptos().Find(id);

            if(d == null)
            {
                TempData["mensaje"] = "Departamento no encontrado";
                return RedirectToAction("Index");
            }
            ViewBag.deptos = new Deptos().ReadAll();
            return View(d);
        }

        // POST: Deptos/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include ="Id,Disponibilidad,Estado,Region,Comuna,Direccion,PrecioDia")]Deptos depto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.deptos = new Deptos().ReadAll();
                    return View(depto);
                }
                // TODO: Add update logic here
                depto.Update();
                TempData["mensaje"] = "Editado correctamente";
                return RedirectToAction("Index");
            }
            catch
            {
                return View(depto);
            }
        }

        // GET: Deptos/Delete/5
        public ActionResult Delete(int id)
        {

            if(new Deptos().Find(id) == null)
            {
                TempData["mensaje"] = "no existe el depto";
                return RedirectToAction("Index");
            }

            if(new Deptos().Delete(id))
            {
                TempData["mensaje"] = "Eliminado correctamente";
                return RedirectToAction("Index");
            }
            TempData["mensaje"] = "no se pudo eliminar";
            return RedirectToAction("Index");
        }

        // POST: Deptos/Delete/5
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
