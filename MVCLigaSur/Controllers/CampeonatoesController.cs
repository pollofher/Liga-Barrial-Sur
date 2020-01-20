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
    public class CampeonatoesController : Controller
    {
        private BarrialSurEntities db = new BarrialSurEntities();

        // GET: Campeonatoes
        public ActionResult Index()
        {
            return View(db.Campeonato.ToList());
        }

        // GET: Campeonatoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Campeonato campeonato = db.Campeonato.Find(id);
            if (campeonato == null)
            {
                return HttpNotFound();
            }
            return View(campeonato);
        }

        // GET: Campeonatoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Campeonatoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_campeonato,Nom_Campeonato,fecha_ini,fecha_fin,Estado_campeonato")] Campeonato campeonato)
        {
            if (ModelState.IsValid)
            {
                db.Campeonato.Add(campeonato);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(campeonato);
        }

        // GET: Campeonatoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Campeonato campeonato = db.Campeonato.Find(id);
            if (campeonato == null)
            {
                return HttpNotFound();
            }
            return View(campeonato);
        }

        // POST: Campeonatoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_campeonato,Nom_Campeonato,fecha_ini,fecha_fin,Estado_campeonato")] Campeonato campeonato)
        {
            if (ModelState.IsValid)
            {
                db.Entry(campeonato).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(campeonato);
        }

        public ActionResult Delete(int Id)
        {
                var campeonato = db.Campeonato.Where(x => x.Id_campeonato == Id).FirstOrDefault();
                db.Campeonato.Remove(campeonato);
                db.SaveChanges();
                string message = "Registro Eliminado.";
                bool status = true;
                return Json(new { status = status, message = message }, JsonRequestBehavior.AllowGet);
        

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
