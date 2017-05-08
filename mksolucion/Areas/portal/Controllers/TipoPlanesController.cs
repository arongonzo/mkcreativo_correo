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
    public class TipoPlanesController : Controller
    {
        private ModelMK db = new ModelMK();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult pln02_tipoplan_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<pln02_tipoplan> pln02_tipoplan = db.pln02_tipoplan;

            request.Filters.Add(new FilterDescriptor() { Member = "pln02_estado", MemberType = typeof(Int32), Operator = FilterOperator.IsEqualTo, Value = "1" });
            
            DataSourceResult result = pln02_tipoplan.ToDataSourceResult(request, c => new _pnl02_tipoplan 
            {
                pln02_id = (decimal)c.pln02_id,
                pln02_nombre = c.pln02_nombre,
                pln02_descripcion = c.pln02_descripcion,
                pln02_estado = c.pln02_estado,
                pln02_ultimaactualizacion = c.pln02_ultimaactualizacion,
                pln02_fechacreacion = c.pln02_fechacreacion
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
            pln02_tipoplan pln02_tipoplan = db.pln02_tipoplan.Find(id);
            if (pln02_tipoplan == null)
            {
                return HttpNotFound();
            }
            return View(pln02_tipoplan);
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
        public ActionResult Create([Bind(Include = "pln02_nombre,pln02_descripcion")] pln02_tipoplan pln02_tipoplan)
        {
            if (ModelState.IsValid)
            {

                pln02_tipoplan.pln02_estado = 1;
                pln02_tipoplan.pln02_fechacreacion = DateTime.Now;
                pln02_tipoplan.pln02_ultimaactualizacion = DateTime.Now;

                db.pln02_tipoplan.Add(pln02_tipoplan);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(pln02_tipoplan);
        }

        // GET: configuracion/tipoplan/Edit/5
        [Authorization(UserRoles.Admin)]
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
            return View(pln02_tipoplan);
        }

        // POST: configuracion/tipoplan/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorization(UserRoles.Admin)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "pln02_id,pln02_nombre,pln02_descripcion,pln02_estado")] pln02_tipoplan pln02_tipoplan)
        {
            if (ModelState.IsValid)
            {

                db.pln02_tipoplan.Attach(pln02_tipoplan);
                pln02_tipoplan.pln02_ultimaactualizacion = DateTime.Now;

                db.Entry(pln02_tipoplan).Property(x => x.pln02_nombre).IsModified = true;
                db.Entry(pln02_tipoplan).Property(x => x.pln02_descripcion).IsModified = true;
                db.Entry(pln02_tipoplan).Property(x => x.pln02_estado).IsModified = true;
                db.Entry(pln02_tipoplan).Property(x => x.pln02_ultimaactualizacion).IsModified = true;
                db.SaveChanges();

                /*                
                db.Entry(pln02_tipoplan).State = EntityState.Modified;
                db.SaveChanges();
                 */
                return RedirectToAction("Index");
            }
            return View(pln02_tipoplan);
        }
        // GET: configuracion/tipoplan/Delete/5
        [Authorization(UserRoles.Admin)]
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

        // POST: configuracion/tipoplan/Delete/5
        [Authorization(UserRoles.Admin)]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {

            var pln02_tipoplan = new pln02_tipoplan { pln02_id = id };
            db.pln02_tipoplan.Attach(pln02_tipoplan);
            pln02_tipoplan.pln02_estado = 2;
            db.Entry(pln02_tipoplan).Property(x => x.pln02_estado).IsModified = true;

            db.Configuration.ValidateOnSaveEnabled = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
