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
    public class ejemplo_contactoController : Controller
    {
        private ModelMK db = new ModelMK();

        // GET: portal/ejemplo_contacto
        public ActionResult Index()
        {
            var con01_contacto = db.con01_contacto.Include(c => c.con02_tipocontacto).Include(c => c.con03_importancia).Include(c => c.gen01_estados).Include(c => c.serv01_servicios);
            return View(con01_contacto.ToList());
        }

        // GET: portal/ejemplo_contacto/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            con01_contacto con01_contacto = db.con01_contacto.Find(id);
            if (con01_contacto == null)
            {
                return HttpNotFound();
            }
            return View(con01_contacto);
        }

        // GET: portal/ejemplo_contacto/Create
        public ActionResult Create()
        {
            ViewBag.con02_id = new SelectList(db.con02_tipocontacto, "con02_id", "con02_nombre");
            ViewBag.con03_id = new SelectList(db.con03_importancia, "con03_id", "con03_nombre");
            ViewBag.con01_estado = new SelectList(db.gen01_estados, "gen01_id", "gen01_nombre");
            ViewBag.ser01_id = new SelectList(db.serv01_servicios, "ser01_id", "ser01_id");
            return View();
        }

        // POST: portal/ejemplo_contacto/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "con01_id,con01_nombre,con01_email,con01_asunto,con02_id,con03_id,ser01_id,con01_mensaje,con01_adjunto,con01_estado,con01_fechacreacion,con01_ultimaactualizacion")] con01_contacto con01_contacto)
        {
            if (ModelState.IsValid)
            {
                db.con01_contacto.Add(con01_contacto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.con02_id = new SelectList(db.con02_tipocontacto, "con02_id", "con02_nombre", con01_contacto.con02_id);
            ViewBag.con03_id = new SelectList(db.con03_importancia, "con03_id", "con03_nombre", con01_contacto.con03_id);
            ViewBag.con01_estado = new SelectList(db.gen01_estados, "gen01_id", "gen01_nombre", con01_contacto.con01_estado);
            ViewBag.ser01_id = new SelectList(db.serv01_servicios, "ser01_id", "ser01_id", con01_contacto.ser01_id);
            return View(con01_contacto);
        }

        // GET: portal/ejemplo_contacto/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            con01_contacto con01_contacto = db.con01_contacto.Find(id);
            if (con01_contacto == null)
            {
                return HttpNotFound();
            }
            ViewBag.con02_id = new SelectList(db.con02_tipocontacto, "con02_id", "con02_nombre", con01_contacto.con02_id);
            ViewBag.con03_id = new SelectList(db.con03_importancia, "con03_id", "con03_nombre", con01_contacto.con03_id);
            ViewBag.con01_estado = new SelectList(db.gen01_estados, "gen01_id", "gen01_nombre", con01_contacto.con01_estado);
            ViewBag.ser01_id = new SelectList(db.serv01_servicios, "ser01_id", "ser01_id", con01_contacto.ser01_id);
            return View(con01_contacto);
        }

        // POST: portal/ejemplo_contacto/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "con01_id,con01_nombre,con01_email,con01_asunto,con02_id,con03_id,ser01_id,con01_mensaje,con01_adjunto,con01_estado,con01_fechacreacion,con01_ultimaactualizacion")] con01_contacto con01_contacto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(con01_contacto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.con02_id = new SelectList(db.con02_tipocontacto, "con02_id", "con02_nombre", con01_contacto.con02_id);
            ViewBag.con03_id = new SelectList(db.con03_importancia, "con03_id", "con03_nombre", con01_contacto.con03_id);
            ViewBag.con01_estado = new SelectList(db.gen01_estados, "gen01_id", "gen01_nombre", con01_contacto.con01_estado);
            ViewBag.ser01_id = new SelectList(db.serv01_servicios, "ser01_id", "ser01_id", con01_contacto.ser01_id);
            return View(con01_contacto);
        }

        // GET: portal/ejemplo_contacto/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            con01_contacto con01_contacto = db.con01_contacto.Find(id);
            if (con01_contacto == null)
            {
                return HttpNotFound();
            }
            return View(con01_contacto);
        }

        // POST: portal/ejemplo_contacto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            con01_contacto con01_contacto = db.con01_contacto.Find(id);
            db.con01_contacto.Remove(con01_contacto);
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
