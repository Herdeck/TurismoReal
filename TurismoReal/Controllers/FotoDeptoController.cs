using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TurismoReal.Negocio;

namespace TurismoReal.Controllers
{
    public class FotoDeptoController : Controller
    {
        // GET: FotoDepto
        public ActionResult Index()
        {
            ViewBag.fotodepto = new FotoDepto().ReadAll();
            return View();
        }

        // GET: FotoDepto/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FotoDepto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FotoDepto/Create
        [HttpPost]
        public ActionResult Create([Bind(Include ="Id,Foto")]FotoDepto foto, HttpPostedFileBase file)
        {
            try
            {
                // TODO: Add insert logic here
                if (!ModelState.IsValid)
                {
                    ViewBag.fotodepto = new FotoDepto().ReadAll();
                    return View(foto);
                }
                foto.Save();
                TempData["mensaje"] = "Guardado correctamente";
                return RedirectToAction("Index");
            }
            catch
            {
                return View(foto);
            }
        }

        // GET: FotoDepto/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FotoDepto/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: FotoDepto/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FotoDepto/Delete/5
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
