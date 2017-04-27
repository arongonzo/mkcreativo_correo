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
    public class TipoCampanaController : Controller
    {
        private ModelMK db = new ModelMK();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult cam02_tipocampana_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<cam02_tipocampana> cam02_tipocampana = db.cam02_tipocampana;

            request.Filters.Add(new FilterDescriptor() { Member = "cam02_estado", MemberType = typeof(Int32), Operator = FilterOperator.IsEqualTo, Value = "1" });

            DataSourceResult result = cam02_tipocampana.ToDataSourceResult(request, c => new _cam02_tipocampana 
            {
                cam02_id = c.cam02_id,
                cam02_nombre = c.cam02_nombre,
                cam02_descripcion = c.cam02_descripcion,
                cam02_estado = c.cam02_estado,
                cam02_fechacreacion = c.cam02_fechacreacion,
                cam02_ultimaactualizacion = c.cam02_ultimaactualizacion
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
            cam02_tipocampana cam02_tipocampana = db.cam02_tipocampana.Find(id);
            if (cam02_tipocampana == null)
            {
                return HttpNotFound();
            }
            return View(cam02_tipocampana);
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
        public ActionResult Create([Bind(Include = "cam02_nombre,cam02_descripcion")] cam02_tipocampana cam02_tipocampana)
        {
            if (ModelState.IsValid)
            {

                cam02_tipocampana.cam02_estado = 1;
                cam02_tipocampana.cam02_fechacreacion = DateTime.Now;
                cam02_tipocampana.cam02_ultimaactualizacion = DateTime.Now;

                db.cam02_tipocampana.Add(cam02_tipocampana);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(cam02_tipocampana);
        }

        // GET: configuracion/tipoplan/Edit/5
        [Authorization(UserRoles.Admin)]
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cam02_tipocampana cam02_tipocampana = db.cam02_tipocampana.Find(id);
            if (cam02_tipocampana == null)
            {
                return HttpNotFound();
            }
            return View(cam02_tipocampana);
        }

        // POST: configuracion/tipoplan/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorization(UserRoles.Admin)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cam02_id,cam02_nombre,cam02_descripcion,cam02_estado")] cam02_tipocampana cam02_tipocampana)
        {
            if (ModelState.IsValid)
            {

                db.cam02_tipocampana.Attach(cam02_tipocampana);
                cam02_tipocampana.cam02_ultimaactualizacion = DateTime.Now;

                db.Entry(cam02_tipocampana).Property(x => x.cam02_nombre).IsModified = true;
                db.Entry(cam02_tipocampana).Property(x => x.cam02_descripcion).IsModified = true;
                db.Entry(cam02_tipocampana).Property(x => x.cam02_estado).IsModified = true;
                db.Entry(cam02_tipocampana).Property(x => x.cam02_ultimaactualizacion).IsModified = true;
                db.SaveChanges();

                /*                
                db.Entry(pln02_tipoplan).State = EntityState.Modified;
                db.SaveChanges();
                 */
                return RedirectToAction("Index");
            }
            return View(cam02_tipocampana);
        }

        // GET: configuracion/tipoplan/Delete/5
        [Authorization(UserRoles.Admin)]
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            cam02_tipocampana cam02_tipocampana = db.cam02_tipocampana.Find(id);
            if (cam02_tipocampana == null)
            {
                return HttpNotFound();
            }
            return View(cam02_tipocampana);
        }

        // POST: configuracion/tipoplan/Delete/5
        [Authorization(UserRoles.Admin)]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {

            var cam02_tipocampana = new cam02_tipocampana { cam02_id = id };
            db.cam02_tipocampana.Attach(cam02_tipocampana);
            cam02_tipocampana.cam02_estado = 2;
            db.Entry(cam02_tipocampana).Property(x => x.cam02_estado).IsModified = true;

            db.Configuration.ValidateOnSaveEnabled = false;
            db.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}
