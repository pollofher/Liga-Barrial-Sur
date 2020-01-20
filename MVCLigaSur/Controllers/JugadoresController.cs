using MVCLigaSur.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVCLigaSur.Controllers
{
    public class JugadoresController : Controller
    {
        BarrialSurEntities db = new BarrialSurEntities();
        public ActionResult Index()
        {
            List<Equipo> JugadoryEquipoList = db.Equipo.ToList();
            return View(JugadoryEquipoList);
        }
        public ActionResult SaveOrder(string nom_equipo, String color_equipo,Jugador[]jugador)
        {
            string result = "Error! Order Is Not Complete!";
            if (nom_equipo != null && color_equipo != null && jugador!=null)
            {
                int id_equipo = Guid.NewGuid().GetHashCode();
                Equipo model = new Equipo();
                model.Id_Equipo = id_equipo;
                model.nom_equipo = nom_equipo;
                model.color_equipo = color_equipo;

                db.Equipo.Add(model);

                foreach (var item in jugador)
                {
                    int jugadorId = Guid.NewGuid().GetHashCode();
                    Jugador j = new Jugador();
                    j.Id_jugador = jugadorId;
                    j.nom_jugador = item.nom_jugador;
                    j.apell_jugador = item.apell_jugador;
                    j.Id_jugador = id_equipo;

                    db.Jugador.Add(j);
                }
                db.SaveChanges();
                result = "Success! Order Is Complete!";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}