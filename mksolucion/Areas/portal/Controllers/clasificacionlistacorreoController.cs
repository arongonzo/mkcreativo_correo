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
    public class clasificacionlistacorreoController : Controller
    {
        private ModelMK db = new ModelMK();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult lis02_clasificacion_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<lis02_clasificacion> lis02_clasificacion = db.lis02_clasificacion;

            request.Filters.Add(new FilterDescriptor() { Member = "lis02_estado", MemberType = typeof(Int32), Operator = FilterOperator.IsEqualTo, Value = "1" });

            DataSourceResult result = lis02_clasificacion.ToDataSourceResult(request, c => new _lis02_clasificacion 
            {
                lis02_id = c.lis02_id,
                lis02_nombre = c.lis02_nombre,
                lis02_descripcion = c.lis02_descripcion,
                lis02_estado = c.lis02_estado,
                lis02_fechacreacion = c.lis02_fechacreacion,
                lis02_ultimaactualizacion = c.lis02_ultimaactualizacion
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
            lis02_clasificacion lis02_clasificacion = db.lis02_clasificacion.Find(id);
            if (lis02_clasificacion == null)
            {
                return HttpNotFound();
            }
            return View(lis02_clasificacion);
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
        public ActionResult Create([Bind(Include = "lis02_nombre,lis02_descripcion")] lis02_clasificacion lis02_clasificacion)
        {
            if (ModelState.IsValid)
            {

                lis02_clasificacion.lis02_estado = 1;
                lis02_clasificacion.lis02_fechacreacion = DateTime.Now;
                lis02_clasificacion.lis02_ultimaactualizacion = DateTime.Now;

                db.lis02_clasificacion.Add(lis02_clasificacion);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(lis02_clasificacion);
        }

        // GET: configuracion/tipoplan/Edit/5
        [Authorization(UserRoles.Admin)]
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lis02_clasificacion lis02_clasificacion = db.lis02_clasificacion.Find(id);
            if (lis02_clasificacion == null)
            {
                return HttpNotFound();
            }
            return View(lis02_clasificacion);
        }

        // POST: configuracion/tipoplan/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorization(UserRoles.Admin)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "lis02_id,lis02_nombre,lis02_descripcion,lis02_estado")] lis02_clasificacion lis02_clasificacion)
        {
            if (ModelState.IsValid)
            {

                db.lis02_clasificacion.Attach(lis02_clasificacion);
                lis02_clasificacion.lis02_ultimaactualizacion = DateTime.Now;

                db.Entry(lis02_clasificacion).Property(x => x.lis02_nombre).IsModified = true;
                db.Entry(lis02_clasificacion).Property(x => x.lis02_descripcion).IsModified = true;
                db.Entry(lis02_clasificacion).Property(x => x.lis02_estado).IsModified = true;
                db.Entry(lis02_clasificacion).Property(x => x.lis02_ultimaactualizacion).IsModified = true;
                db.SaveChanges();

                /*                
                db.Entry(lis02_tipoplan).State = EntityState.Modified;
                db.SaveChanges();
                 */
                return RedirectToAction("Index");
            }
            return View(lis02_clasificacion);
        }
        // GET: configuracion/tipoplan/Delete/5
        [Authorization(UserRoles.Admin)]
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            lis02_clasificacion lis02_clasificacion = db.lis02_clasificacion.Find(id);
            if (lis02_clasificacion == null)
            {
                return HttpNotFound();
            }
            return View(lis02_clasificacion);
        }

        // POST: configuracion/tipoplan/Delete/5
        [Authorization(UserRoles.Admin)]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {

            var lis02_clasificacion = new lis02_clasificacion { lis02_id = id };
            db.lis02_clasificacion.Attach(lis02_clasificacion);
            lis02_clasificacion.lis02_estado = 2;
            db.Entry(lis02_clasificacion).Property(x => x.lis02_estado).IsModified = true;

            db.Configuration.ValidateOnSaveEnabled = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
