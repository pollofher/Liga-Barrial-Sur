using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCLigaSur.Models;

namespace MVCLigaSur.Controllers
{
    public class EquipoController : Controller
    {
        private BarrialSurEntities db = new BarrialSurEntities();

        // GET: Equipo
        public ActionResult Index()
        {
            var equipo = db.Equipo.Include(e => e.Dirigente);
            return View(equipo.ToList());
        }

        // GET: Equipo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipo equipo = db.Equipo.Find(id);
            if (equipo == null)
            {
                return HttpNotFound();
            }
            return View(equipo);
        }

        // GET: Equipo/Create
        public ActionResult Create()
        {
            ViewBag.id_dirigente = new SelectList(db.Dirigente, "Id_dirigente", "ced_dirigente");
            return View();
        }

        // POST: Equipo/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Equipo,nom_equipo,color_equipo,fundacion,foto_equipo,liga,serie,Estado_equipo,id_dirigente")] Equipo equipo)
        {

            //Ruta donde se guarda la imagen
            HttpPostedFileBase foto_equipo = Request.Files[0];
            string ruta = Server.MapPath("~/Repositorio/");
            ruta += foto_equipo.FileName;
            foto_equipo.SaveAs(ruta);

            //Guardar nimbre en la base de datos
            equipo.foto_equipo = foto_equipo.FileName;

            if (ModelState.IsValid)
            {
                db.Equipo.Add(equipo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_dirigente = new SelectList(db.Dirigente, "Id_dirigente", "ced_dirigente", equipo.id_dirigente);
            return View(equipo);
        }

        // GET: Equipo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipo equipo = db.Equipo.Find(id);
            if (equipo == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_dirigente = new SelectList(db.Dirigente, "Id_dirigente", "ced_dirigente", equipo.id_dirigente);
            return View(equipo);
        }

        // POST: Equipo/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Equipo,nom_equipo,color_equipo,fundacion,foto_equipo,liga,serie,Estado_equipo,id_dirigente")] Equipo equipo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(equipo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_dirigente = new SelectList(db.Dirigente, "Id_dirigente", "ced_dirigente", equipo.id_dirigente);
            return View(equipo);
        }

        // GET: Equipo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipo equipo = db.Equipo.Find(id);
            if (equipo == null)
            {
                return HttpNotFound();
            }
            return View(equipo);
        }

        // POST: Equipo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Equipo equipo = db.Equipo.Find(id);
            db.Equipo.Remove(equipo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
