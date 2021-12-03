using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TurismoReal.Negocio;

namespace TurismoReal.Controllers
{

    public class UsuarioController : Controller
    {
        // GET: Usuario
        [Authorize]
        public ActionResult Index()
        {
            ViewBag.usuarios = new Usuario().RealAll();
            return View();
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "id,email,tipo_cuenta,pNombre,sNombre,pApellido,sApellido,rut,dVer,cargo")] Usuario usuario)
        {
            try
            {
                // TODO: Add insert logic here
                if (!ModelState.IsValid)
                {
                    return View(usuario);
                }
                usuario.Save();
                TempData["mensaje"] = "Guardado Correctamente";
                return RedirectToAction("Index");
            }
            catch
            {
                return View(usuario);
            }
        }

        // GET: Usuario/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            Usuario u = new Usuario().Find(id);
            if (u == null)
            {
                TempData["mensaje"] = "El producto no existe";
                return RedirectToAction("Index");
            }

            return View(u);
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "id,email,tipo_cuenta,pNombre,sNombre,pApellido,sApellido,rut,dVer,cargo")] Usuario usuario)
        {
            try
            {
                // TODO: Add update logic here
                if (!ModelState.IsValid)
                {
                    return View(usuario);
                }
                usuario.Update();
                TempData["mensaje"] = "Modificado correctamente";
                return RedirectToAction("Index");
            }
            catch
            {
                return View(usuario);
            }
        }

        // GET: Usuario/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            if (new Usuario().Find(id) == null)
            {
                TempData["mensaje"] = "no existe el producto";
                return RedirectToAction("Index");
            }
            if (new Usuario().Delete(id))
            {
                TempData["mensaje"] = "Eliminado correctamente";
                return RedirectToAction("Index");
            }
            TempData["mensaje"] = "No se ha podido eliminar";
            return View();
        }

        // POST: Usuario/Delete/5
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
