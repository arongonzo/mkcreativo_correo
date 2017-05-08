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
    [SessionExpire]
    public class clasificacioncorreoController : Controller
    {
        private ModelMK db = new ModelMK();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult crr02_tipoclasificacion_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<crr02_tipoclasificacion> crr02_tipoclasificacion = db.crr02_tipoclasificacion;

            request.Filters.Add(new FilterDescriptor() { Member = "crr02_estado", MemberType = typeof(Int32), Operator = FilterOperator.IsEqualTo, Value = "1" });

            DataSourceResult result = crr02_tipoclasificacion.ToDataSourceResult(request, c => new _crr02_tipoclasificacion 
            {
                crr02_id = c.crr02_id,
                crr02_nombre = c.crr02_nombre,
                crr02_descripcion = c.crr02_descripcion,
                crr02_estado = c.crr02_estado,
                crr02_fechacreacion = c.crr02_fechacreacion,
                crr02_ultimaactualizacion = c.crr02_ultimaactualizacion
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
            crr02_tipoclasificacion crr02_tipoclasificacion = db.crr02_tipoclasificacion.Find(id);
            if (crr02_tipoclasificacion == null)
            {
                return HttpNotFound();
            }
            return View(crr02_tipoclasificacion);
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
        public ActionResult Create([Bind(Include = "crr02_nombre,crr02_descripcion")] crr02_tipoclasificacion crr02_tipoclasificacion)
        {
            if (ModelState.IsValid)
            {

                crr02_tipoclasificacion.crr02_estado = 1;
                crr02_tipoclasificacion.crr02_fechacreacion = DateTime.Now;
                crr02_tipoclasificacion.crr02_ultimaactualizacion = DateTime.Now;

                db.crr02_tipoclasificacion.Add(crr02_tipoclasificacion);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(crr02_tipoclasificacion);
        }

        // GET: configuracion/tipoplan/Edit/5
        [Authorization(UserRoles.Admin)]
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            crr02_tipoclasificacion crr02_tipoclasificacion = db.crr02_tipoclasificacion.Find(id);
            if (crr02_tipoclasificacion == null)
            {
                return HttpNotFound();
            }
            return View(crr02_tipoclasificacion);
        }

        // POST: configuracion/tipoplan/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorization(UserRoles.Admin)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "crr02_id,crr02_nombre,crr02_descripcion,crr02_estado")] crr02_tipoclasificacion crr02_tipoclasificacion)
        {
            if (ModelState.IsValid)
            {

                db.crr02_tipoclasificacion.Attach(crr02_tipoclasificacion);
                crr02_tipoclasificacion.crr02_ultimaactualizacion = DateTime.Now;

                db.Entry(crr02_tipoclasificacion).Property(x => x.crr02_nombre).IsModified = true;
                db.Entry(crr02_tipoclasificacion).Property(x => x.crr02_descripcion).IsModified = true;
                db.Entry(crr02_tipoclasificacion).Property(x => x.crr02_estado).IsModified = true;
                db.Entry(crr02_tipoclasificacion).Property(x => x.crr02_ultimaactualizacion).IsModified = true;
                db.SaveChanges();

                /*                
                db.Entry(pln02_tipoplan).State = EntityState.Modified;
                db.SaveChanges();
                 */
                return RedirectToAction("Index");
            }
            return View(crr02_tipoclasificacion);
        }

        // GET: configuracion/tipoplan/Delete/5
        [Authorization(UserRoles.Admin)]
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            crr02_tipoclasificacion crr02_tipoclasificacion = db.crr02_tipoclasificacion.Find(id);
            if (crr02_tipoclasificacion == null)
            {
                return HttpNotFound();
            }
            return View(crr02_tipoclasificacion);
        }

        // POST: configuracion/tipoplan/Delete/5
        [Authorization(UserRoles.Admin)]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {

            var crr02_tipoclasificacion = new crr02_tipoclasificacion { crr02_id = id };
            db.crr02_tipoclasificacion.Attach(crr02_tipoclasificacion);
            crr02_tipoclasificacion.crr02_estado = 2;
            db.Entry(crr02_tipoclasificacion).Property(x => x.crr02_estado).IsModified = true;

            db.Configuration.ValidateOnSaveEnabled = false;
            db.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}
