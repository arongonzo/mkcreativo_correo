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
using Kendo.Mvc;

namespace mksolucion.Areas.portal.Controllers
{
    public class TipoNotificacionCorreoController : Controller
    {
        private ModelMK db = new ModelMK();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ntf02_tiponotificacioncorreo_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<ntf02_tiponotificacioncorreo> ntf02_tiponotificacioncorreo = db.ntf02_tiponotificacioncorreo;
            request.Filters.Add(new FilterDescriptor() { Member = "ntf02_estado", MemberType = typeof(Int32), Operator = FilterOperator.IsEqualTo, Value = "1" });
            DataSourceResult result = ntf02_tiponotificacioncorreo.ToDataSourceResult(request, c => new _ntf02_tiponotificacioncorreo 
            {
                ntf02_id = c.ntf02_id,
                ntf02_nombre = c.ntf02_nombre,
                ntf02_descripcion = c.ntf02_descripcion,
                ntf02_estado = c.ntf02_estado,
                ntf02_fechacreacion = c.ntf02_fechacreacion,
                ntf02_ultimaactualizacion = c.ntf02_ultimaactualizacion
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
            ntf02_tiponotificacioncorreo ntf02_tiponotificacioncorreo = db.ntf02_tiponotificacioncorreo.Find(id);
            if (ntf02_tiponotificacioncorreo == null)
            {
                return HttpNotFound();
            }
            return View(ntf02_tiponotificacioncorreo);
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
        public ActionResult Create([Bind(Include = "ntf02_nombre,ntf02_descripcion")] ntf02_tiponotificacioncorreo ntf02_tiponotificacioncorreo)
        {
            if (ModelState.IsValid)
            {

                ntf02_tiponotificacioncorreo.ntf02_estado = 1;
                ntf02_tiponotificacioncorreo.ntf02_fechacreacion = DateTime.Now;
                ntf02_tiponotificacioncorreo.ntf02_ultimaactualizacion = DateTime.Now;

                db.ntf02_tiponotificacioncorreo.Add(ntf02_tiponotificacioncorreo);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(ntf02_tiponotificacioncorreo);
        }

        // GET: configuracion/tipoplan/Edit/5
        [Authorization(UserRoles.Admin)]
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ntf02_tiponotificacioncorreo ntf02_tiponotificacioncorreo = db.ntf02_tiponotificacioncorreo.Find(id);
            if (ntf02_tiponotificacioncorreo == null)
            {
                return HttpNotFound();
            }
            return View(ntf02_tiponotificacioncorreo);
        }

        // POST: configuracion/tipoplan/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorization(UserRoles.Admin)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ntf02_id,ntf02_nombre,ntf02_descripcion,ntf02_estado")] ntf02_tiponotificacioncorreo ntf02_tiponotificacioncorreo)
        {
            if (ModelState.IsValid)
            {

                db.ntf02_tiponotificacioncorreo.Attach(ntf02_tiponotificacioncorreo);
                ntf02_tiponotificacioncorreo.ntf02_ultimaactualizacion = DateTime.Now;

                db.Entry(ntf02_tiponotificacioncorreo).Property(x => x.ntf02_nombre).IsModified = true;
                db.Entry(ntf02_tiponotificacioncorreo).Property(x => x.ntf02_descripcion).IsModified = true;
                db.Entry(ntf02_tiponotificacioncorreo).Property(x => x.ntf02_estado).IsModified = true;
                db.Entry(ntf02_tiponotificacioncorreo).Property(x => x.ntf02_ultimaactualizacion).IsModified = true;
                db.SaveChanges();

                /*                
                db.Entry(pln02_tipoplan).State = EntityState.Modified;
                db.SaveChanges();
                 */
                return RedirectToAction("Index");
            }
            return View(ntf02_tiponotificacioncorreo);
        }

        // GET: configuracion/tipoplan/Delete/5
        [Authorization(UserRoles.Admin)]
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ntf02_tiponotificacioncorreo ntf02_tiponotificacioncorreo = db.ntf02_tiponotificacioncorreo.Find(id);
            if (ntf02_tiponotificacioncorreo == null)
            {
                return HttpNotFound();
            }
            return View(ntf02_tiponotificacioncorreo);
        }

        // POST: configuracion/tipoplan/Delete/5
        [Authorization(UserRoles.Admin)]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {

            var ntf02_tiponotificacioncorreo = new ntf02_tiponotificacioncorreo { ntf02_id = id };
            db.ntf02_tiponotificacioncorreo.Attach(ntf02_tiponotificacioncorreo);
            ntf02_tiponotificacioncorreo.ntf02_estado = 2;
            db.Entry(ntf02_tiponotificacioncorreo).Property(x => x.ntf02_estado).IsModified = true;

            db.Configuration.ValidateOnSaveEnabled = false;
            db.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}
