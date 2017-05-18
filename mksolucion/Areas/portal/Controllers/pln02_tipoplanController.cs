using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using mksolucion.Models;

namespace mksolucion.Areas.portal.Controllers
{
    public class pln02_tipoplanController : Controller
    {
        private ModelMK db = new ModelMK();

        // GET: portal/pln02_tipoplan
        public ActionResult Index()
        {
            var pln02_tipoplan = db.pln02_tipoplan.Include(p => p.gen01_estados).Include(p => p.pln03_tipocobro);
            return View(pln02_tipoplan.ToList());
        }

        // GET: portal/pln02_tipoplan/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pln02_tipoplan pln02_tipoplan = db.pln02_tipoplan.Find(id);
            if (pln02_tipoplan == null)
            {
                return HttpNotFound();
            }
            return View(pln02_tipoplan);
        }

        // GET: portal/pln02_tipoplan/Create
        public ActionResult Create()
        {
            ViewBag.pln02_estado = new SelectList(db.gen01_estados, "gen01_id", "gen01_nombre");
            ViewBag.pln03_id = new SelectList(db.pln03_tipocobro, "pln03_id", "pln03_nombre");
            return View();
        }

        // POST: portal/pln02_tipoplan/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "pln02_id,pln03_id,pln02_nombre,pln02_descripcion,pln02_estado,pln02_fechacreacion,pln02_ultimaactualizacion")] pln02_tipoplan pln02_tipoplan)
        {
            if (ModelState.IsValid)
            {
                db.pln02_tipoplan.Add(pln02_tipoplan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.pln02_estado = new SelectList(db.gen01_estados, "gen01_id", "gen01_nombre", pln02_tipoplan.pln02_estado);
            ViewBag.pln03_id = new SelectList(db.pln03_tipocobro, "pln03_id", "pln03_nombre", pln02_tipoplan.pln03_id);
            return View(pln02_tipoplan);
        }

        // GET: portal/pln02_tipoplan/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pln02_tipoplan pln02_tipoplan = db.pln02_tipoplan.Find(id);
            if (pln02_tipoplan == null)
            {
                return HttpNotFound();
            }
            ViewBag.pln02_estado = new SelectList(db.gen01_estados, "gen01_id", "gen01_nombre", pln02_tipoplan.pln02_estado);
            ViewBag.pln03_id = new SelectList(db.pln03_tipocobro, "pln03_id", "pln03_nombre", pln02_tipoplan.pln03_id);
            return View(pln02_tipoplan);
        }

        // POST: portal/pln02_tipoplan/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "pln02_id,pln03_id,pln02_nombre,pln02_descripcion,pln02_estado,pln02_fechacreacion,pln02_ultimaactualizacion")] pln02_tipoplan pln02_tipoplan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pln02_tipoplan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.pln02_estado = new SelectList(db.gen01_estados, "gen01_id", "gen01_nombre", pln02_tipoplan.pln02_estado);
            ViewBag.pln03_id = new SelectList(db.pln03_tipocobro, "pln03_id", "pln03_nombre", pln02_tipoplan.pln03_id);
            return View(pln02_tipoplan);
        }

        // GET: portal/pln02_tipoplan/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pln02_tipoplan pln02_tipoplan = db.pln02_tipoplan.Find(id);
            if (pln02_tipoplan == null)
            {
                return HttpNotFound();
            }
            return View(pln02_tipoplan);
        }

        // POST: portal/pln02_tipoplan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            pln02_tipoplan pln02_tipoplan = db.pln02_tipoplan.Find(id);
            db.pln02_tipoplan.Remove(pln02_tipoplan);
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
