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
    public class pasoscompletarinformacionController : Controller
    {
        private ModelMK db = new ModelMK();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult coninf01_pasocominfo_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<coninf01_pasocominfo> coninf01_pasocominfo = db.coninf01_pasocominfo;
            DataSourceResult result = coninf01_pasocominfo.ToDataSourceResult(request, c => new _coninf01_pasocominfo 
            {
                coninf01_id = c.coninf01_id,
                coninf01_nombre = c.coninf01_nombre,
                pln01_estado = c.coninf01_estado,
                pln01_fechacreacion = c.coninf01_fechacreacion,
                pln01_ultimaactualizacion = c.coninf01_ultimaactualizacion
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
            coninf01_pasocominfo coninf01_pasocominfo = db.coninf01_pasocominfo.Find(id);
            if (coninf01_pasocominfo == null)
            {
                return HttpNotFound();
            }
            return View(coninf01_pasocominfo);
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
        public ActionResult Create([Bind(Include = "coninf01_nombre,coninf01_descripcion")] coninf01_pasocominfo coninf01_pasocominfo)
        {
            if (ModelState.IsValid)
            {

                coninf01_pasocominfo.coninf01_estado = 1;
                coninf01_pasocominfo.coninf01_fechacreacion = DateTime.Now;
                coninf01_pasocominfo.coninf01_ultimaactualizacion = DateTime.Now;

                db.coninf01_pasocominfo.Add(coninf01_pasocominfo);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(coninf01_pasocominfo);
        }

        // GET: configuracion/tipoplan/Edit/5
        [Authorization(UserRoles.Admin)]
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            coninf01_pasocominfo coninf01_pasocominfo = db.coninf01_pasocominfo.Find(id);
            if (coninf01_pasocominfo == null)
            {
                return HttpNotFound();
            }
            return View(coninf01_pasocominfo);
        }

        // POST: configuracion/tipoplan/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorization(UserRoles.Admin)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "coninf01_id,coninf01_nombre,coninf01_descripcion,coninf01_estado")] coninf01_pasocominfo coninf01_pasocominfo)
        {
            if (ModelState.IsValid)
            {

                db.coninf01_pasocominfo.Attach(coninf01_pasocominfo);
                coninf01_pasocominfo.coninf01_ultimaactualizacion = DateTime.Now;

                db.Entry(coninf01_pasocominfo).Property(x => x.coninf01_nombre).IsModified = true;
                db.Entry(coninf01_pasocominfo).Property(x => x.coninf01_estado).IsModified = true;
                db.Entry(coninf01_pasocominfo).Property(x => x.coninf01_ultimaactualizacion).IsModified = true;
                db.SaveChanges();

                /*                
                db.Entry(coninf01_pasocominfo).State = EntityState.Modified;
                db.SaveChanges();
                 */
                return RedirectToAction("Index");
            }
            return View(coninf01_pasocominfo);
        }
        // GET: configuracion/tipoplan/Delete/5
        [Authorization(UserRoles.Admin)]
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            coninf01_pasocominfo coninf01_pasocominfo = db.coninf01_pasocominfo.Find(id);
            if (coninf01_pasocominfo == null)
            {
                return HttpNotFound();
            }
            return View(coninf01_pasocominfo);
        }

        // POST: configuracion/tipoplan/Delete/5
        [Authorization(UserRoles.Admin)]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {

            var coninf01_pasocominfo = new coninf01_pasocominfo { coninf01_id = id };
            db.coninf01_pasocominfo.Attach(coninf01_pasocominfo);
            coninf01_pasocominfo.coninf01_estado = 2;
            db.Entry(coninf01_pasocominfo).Property(x => x.coninf01_estado).IsModified = true;

            db.Configuration.ValidateOnSaveEnabled = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
