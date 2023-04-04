using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Proyecto_Eventos_Progra_V.Models;

namespace Proyecto_Eventos_Progra_V.Controllers
{
    public class Eventoes1Controller : Controller
    {
        private BD_Proyecto_EventosEntities db = new BD_Proyecto_EventosEntities();

        // GET: Eventoes1
        public ActionResult Index()
        {
            var eventoes = db.Eventoes.Include(e => e.Lugar).Include(e => e.Tipo_Evento);
            return View(eventoes.ToList());
        }

        // GET: Eventoes1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evento evento = db.Eventoes.Find(id);
            if (evento == null)
            {
                return HttpNotFound();
            }
            return View(evento);
        }

        // GET: Eventoes1/Create
        public ActionResult Create()
        {
            ViewBag.id_Lugar = new SelectList(db.Lugars, "id_Lugar", "lugar1");
            ViewBag.id_Tipo_Evento = new SelectList(db.Tipo_Evento, "id_Tipo_Evento", "Tipo_Evento1");
            return View();
        }

        // POST: Eventoes1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_Evento,nombre_Evento,id_Tipo_Evento,fecha_Evento,hora_Evento,id_Lugar")] Evento evento)
        {
            if (ModelState.IsValid)
            {
                db.Eventoes.Add(evento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_Lugar = new SelectList(db.Lugars, "id_Lugar", "lugar1", evento.id_Lugar);
            ViewBag.id_Tipo_Evento = new SelectList(db.Tipo_Evento, "id_Tipo_Evento", "Tipo_Evento1", evento.id_Tipo_Evento);
            return View(evento);
        }

        // GET: Eventoes1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evento evento = db.Eventoes.Find(id);
            if (evento == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_Lugar = new SelectList(db.Lugars, "id_Lugar", "lugar1", evento.id_Lugar);
            ViewBag.id_Tipo_Evento = new SelectList(db.Tipo_Evento, "id_Tipo_Evento", "Tipo_Evento1", evento.id_Tipo_Evento);
            return View(evento);
        }

        // POST: Eventoes1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_Evento,nombre_Evento,id_Tipo_Evento,fecha_Evento,hora_Evento,id_Lugar")] Evento evento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(evento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_Lugar = new SelectList(db.Lugars, "id_Lugar", "lugar1", evento.id_Lugar);
            ViewBag.id_Tipo_Evento = new SelectList(db.Tipo_Evento, "id_Tipo_Evento", "Tipo_Evento1", evento.id_Tipo_Evento);
            return View(evento);
        }

        // GET: Eventoes1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evento evento = db.Eventoes.Find(id);
            if (evento == null)
            {
                return HttpNotFound();
            }
            return View(evento);
        }

        // POST: Eventoes1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Evento evento = db.Eventoes.Find(id);
            db.Eventoes.Remove(evento);
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
