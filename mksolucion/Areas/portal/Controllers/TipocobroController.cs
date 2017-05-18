﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using mksolucion.Models;

namespace mksolucion.Areas.portal.Controllers
{
    public class TipocobroController : Controller
    {
        private ModelMK db = new ModelMK();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult pln03_tipocobro_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<pln03_tipocobro> pln03_tipocobro = db.pln03_tipocobro;
            DataSourceResult result = pln03_tipocobro.ToDataSourceResult(request, c => new _pln03_tipocobro 
            {
                pln03_id = c.pln03_id,
                pln03_nombre = c.pln03_nombre,
                pln03_descripcion = c.pln03_descripcion,
                pln03_estado = c.pln03_estado,
                pln03_fechacreacion = c.pln03_fechacreacion,
                pln03_ultimaactualizacion = c.pln03_ultimaactualizacion
            });

            return Json(result);
        }

        [HttpPost]
        public ActionResult Excel_Export_Save(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return File(fileContents, contentType, fileName);
        }
    
        [HttpPost]
        public ActionResult Pdf_Export_Save(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return File(fileContents, contentType, fileName);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        [Authorization(UserRoles.Admin, UserRoles.Manager)]
        // GET: configuracion/tipoplan/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pln03_tipocobro pln03_tipocobro = db.pln03_tipocobro.Find(id);
            if (pln03_tipocobro == null)
            {
                return HttpNotFound();
            }
            return View(pln03_tipocobro);
        }

        [Authorization(UserRoles.Admin)]
        // GET: configuracion/tipoplan/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: configuracion/tipoplan/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorization(UserRoles.Admin)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "pln03_nombre,pln03_descripcion")] pln03_tipocobro pln03_tipocobro)
        {
            if (ModelState.IsValid)
            {

                pln03_tipocobro.pln03_estado = 1;
                pln03_tipocobro.pln03_fechacreacion = DateTime.Now;
                pln03_tipocobro.pln03_ultimaactualizacion = DateTime.Now;

                db.pln03_tipocobro.Add(pln03_tipocobro);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(pln03_tipocobro);
        }

        // GET: configuracion/tipoplan/Edit/5
        [Authorization(UserRoles.Admin)]
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pln03_tipocobro pln03_tipocobro = db.pln03_tipocobro.Find(id);
            if (pln03_tipocobro == null)
            {
                return HttpNotFound();
            }
            return View(pln03_tipocobro);
        }

        // POST: configuracion/tipoplan/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorization(UserRoles.Admin)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "pln03_id,pln03_nombre,pln03_descripcion,pln03_estado")] pln03_tipocobro pln03_tipocobro)
        {
            if (ModelState.IsValid)
            {

                db.pln03_tipocobro.Attach(pln03_tipocobro);
                pln03_tipocobro.pln03_ultimaactualizacion = DateTime.Now;

                db.Entry(pln03_tipocobro).Property(x => x.pln03_nombre).IsModified = true;
                db.Entry(pln03_tipocobro).Property(x => x.pln03_descripcion).IsModified = true;
                db.Entry(pln03_tipocobro).Property(x => x.pln03_estado).IsModified = true;
                db.Entry(pln03_tipocobro).Property(x => x.pln03_ultimaactualizacion).IsModified = true;
                db.SaveChanges();

                /*                
                db.Entry(pln02_tipoplan).State = EntityState.Modified;
                db.SaveChanges();
                 */
                return RedirectToAction("Index");
            }
            return View(pln03_tipocobro);
        }

        // GET: configuracion/tipoplan/Delete/5
        [Authorization(UserRoles.Admin)]
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            pln03_tipocobro pln03_tipocobro = db.pln03_tipocobro.Find(id);
            if (pln03_tipocobro == null)
            {
                return HttpNotFound();
            }
            return View(pln03_tipocobro);
        }

        // POST: configuracion/tipoplan/Delete/5
        [Authorization(UserRoles.Admin)]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {

            var pln03_tipocobro = new pln03_tipocobro { pln03_id = id };
            db.pln03_tipocobro.Attach(pln03_tipocobro);
            pln03_tipocobro.pln03_estado = 2;
            db.Entry(pln03_tipocobro).Property(x => x.pln03_estado).IsModified = true;

            db.Configuration.ValidateOnSaveEnabled = false;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
