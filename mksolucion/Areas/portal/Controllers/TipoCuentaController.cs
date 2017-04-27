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
using Kendo.Mvc;
using mksolucion.Models;

namespace mksolucion.Areas.portal.Controllers
{
    public class TipoCuentaController : Controller
    {
        private ModelMK db = new ModelMK();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult cnt02_tipocuenta_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<cnt02_tipocuenta> cnt02_tipocuenta = db.cnt02_tipocuenta;

            request.Filters.Add(new FilterDescriptor() { Member = "cnt02_estado", MemberType = typeof(Int32), Operator = FilterOperator.IsEqualTo, Value = "1" });

            DataSourceResult result = cnt02_tipocuenta.ToDataSourceResult(request, c => new _cnt02_tipocuenta 
            {
                cnt02_id = c.cnt02_id,
                cnt02_nombre = c.cnt02_nombre,
                cnt02_descripcion = c.cnt02_descripcion,
                cnt02_estado = c.cnt02_estado,
                cnt02_fechacreacion = c.cnt02_fechacreacion,
                cnt02_ultimaactualizacion = c.cnt02_ultimaactualizacion
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
            cnt02_tipocuenta  cnt02_tipocuenta  = db.cnt02_tipocuenta .Find(id);
            if (cnt02_tipocuenta  == null)
            {
                return HttpNotFound();
            }
            return View(cnt02_tipocuenta );
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
        public ActionResult Create([Bind(Include = "cnt02_nombre,cnt02_descripcion")] cnt02_tipocuenta  cnt02_tipocuenta )
        {
            if (ModelState.IsValid)
            {

                cnt02_tipocuenta .cnt02_estado = 1;
                cnt02_tipocuenta .cnt02_fechacreacion = DateTime.Now;
                cnt02_tipocuenta .cnt02_ultimaactualizacion = DateTime.Now;

                db.cnt02_tipocuenta .Add(cnt02_tipocuenta );
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(cnt02_tipocuenta );
        }

        // GET: configuracion/tipoplan/Edit/5
        [Authorization(UserRoles.Admin)]
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cnt02_tipocuenta  cnt02_tipocuenta  = db.cnt02_tipocuenta .Find(id);
            if (cnt02_tipocuenta  == null)
            {
                return HttpNotFound();
            }
            return View(cnt02_tipocuenta );
        }

        // POST: configuracion/tipoplan/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorization(UserRoles.Admin)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cnt02_id,cnt02_nombre,cnt02_descripcion,cnt02_estado")] cnt02_tipocuenta  cnt02_tipocuenta )
        {
            if (ModelState.IsValid)
            {

                db.cnt02_tipocuenta .Attach(cnt02_tipocuenta );
                cnt02_tipocuenta .cnt02_ultimaactualizacion = DateTime.Now;

                db.Entry(cnt02_tipocuenta ).Property(x => x.cnt02_nombre).IsModified = true;
                db.Entry(cnt02_tipocuenta ).Property(x => x.cnt02_descripcion).IsModified = true;
                db.Entry(cnt02_tipocuenta ).Property(x => x.cnt02_estado).IsModified = true;
                db.Entry(cnt02_tipocuenta ).Property(x => x.cnt02_ultimaactualizacion).IsModified = true;
                db.SaveChanges();

                /*                
                db.Entry(pln02_tipoplan).State = EntityState.Modified;
                db.SaveChanges();
                 */
                return RedirectToAction("Index");
            }
            return View(cnt02_tipocuenta );
        }

        // GET: configuracion/tipoplan/Delete/5
        [Authorization(UserRoles.Admin)]
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            cnt02_tipocuenta  cnt02_tipocuenta  = db.cnt02_tipocuenta .Find(id);
            if (cnt02_tipocuenta  == null)
            {
                return HttpNotFound();
            }
            return View(cnt02_tipocuenta );
        }

        // POST: configuracion/tipoplan/Delete/5
        [Authorization(UserRoles.Admin)]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {

            var cnt02_tipocuenta  = new cnt02_tipocuenta  { cnt02_id = id };
            db.cnt02_tipocuenta .Attach(cnt02_tipocuenta );
            cnt02_tipocuenta .cnt02_estado = 2;
            db.Entry(cnt02_tipocuenta ).Property(x => x.cnt02_estado).IsModified = true;

            db.Configuration.ValidateOnSaveEnabled = false;
            db.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}
