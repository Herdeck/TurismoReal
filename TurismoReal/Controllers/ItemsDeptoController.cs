using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TurismoReal.Negocio;
namespace TurismoReal.Controllers
{
    public class ItemsDeptoController : Controller
    {
        // GET: ItemsDepto
        public ActionResult Index()
        {
            ViewBag.itemsdepto = new ItemsDepto().ReadAll();
            return View();
        }

        // GET: ItemsDepto/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ItemsDepto/Create
        public ActionResult Create()
        {
            ViewBag.deptos = new Deptos().ReadAll();
            return View();
        }

        // POST: ItemsDepto/Create
        [HttpPost]
        public ActionResult Create([Bind(Include ="IdItem,IdDepto,Descripcion,Valor")]ItemsDepto itemsdepto)
        {
            try
            {
                // TODO: Add insert logic here
                itemsdepto.Save();
                TempData["mensaje"] = "Item guardado corectamente";
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Create");
            }
        }

        // GET: ItemsDepto/Edit/5
        public ActionResult Edit(int id)
        {

            ItemsDepto i = new ItemsDepto().Find(id);

            if(i == null)
            {
                TempData["mensaje"] ="el item no existe";
                return RedirectToAction("Index");
            }
            ViewBag.itemsdepto = new ItemsDepto().ReadAll();
            ViewBag.deptos = new Deptos().ReadAll();

            return View(i);
        }

        // POST: ItemsDepto/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include ="IdItem,IdDepto,Descripcion,Valor")]ItemsDepto itemsDepto)
        {
            try
            {
                // TODO: Add update logic here
                itemsDepto.Update();
                TempData["mensaje"] ="editado correctamente";
                return RedirectToAction("Index");
            }
            catch
            {
                return View(itemsDepto);
            }
        }

        // GET: ItemsDepto/Delete/5
        public ActionResult Delete(int id)
        {

            if(new ItemsDepto().Find(id) == null)
            {
                TempData["mensaje"] = "no existe el producto";
                return RedirectToAction("Index");
            }

            if (new ItemsDepto().Delete(id))
            {
                TempData["mensaje"] ="Eliminado correctamente";
                return RedirectToAction("Index");
            }
            TempData["mensaje"] = "no se pudo eliminar";
            return RedirectToAction("Index");
        }

        // POST: ItemsDepto/Delete/5
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
