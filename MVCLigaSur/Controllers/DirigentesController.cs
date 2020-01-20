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
    public class DirigentesController : Controller
    {
        private BarrialSurEntities db = new BarrialSurEntities();

        // GET: Dirigentes
        public ActionResult Index()
        {
            return View(db.Dirigente.ToList());
        }

        // GET: Dirigentes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dirigente dirigente = db.Dirigente.Find(id);
            if (dirigente == null)
            {
                return HttpNotFound();
            }
            return View(dirigente);
        }

        // GET: Dirigentes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dirigentes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_dirigente,ced_dirigente,nom_dirigente,apelli_dirigente,dir_dirigente,telf_dirigente")] Dirigente dirigente)
        {
            if (ModelState.IsValid)
            {
                db.Dirigente.Add(dirigente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dirigente);
        }

        // GET: Dirigentes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dirigente dirigente = db.Dirigente.Find(id);
            if (dirigente == null)
            {
                return HttpNotFound();
            }
            return View(dirigente);
        }

        // POST: Dirigentes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_dirigente,ced_dirigente,nom_dirigente,apelli_dirigente,dir_dirigente,telf_dirigente")] Dirigente dirigente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dirigente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dirigente);
        }

        // GET: Dirigentes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dirigente dirigente = db.Dirigente.Find(id);
            if (dirigente == null)
            {
                return HttpNotFound();
            }
            return View(dirigente);
        }

        // POST: Dirigentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dirigente dirigente = db.Dirigente.Find(id);
            db.Dirigente.Remove(dirigente);
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
