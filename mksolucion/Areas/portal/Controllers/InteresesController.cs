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
    public class InteresesController : Controller
    {
        private ModelMK db = new ModelMK();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult crr04_intereses_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<crr04_intereses> crr04_intereses = db.crr04_intereses;
            request.Filters.Add(new FilterDescriptor() { Member = "crr04_estado", MemberType = typeof(Int32), Operator = FilterOperator.IsEqualTo, Value = "1" });
            DataSourceResult result = crr04_intereses.ToDataSourceResult(request, c => new _crr04_intereses 
            {
                crr04_id = c.crr04_id,
                crr04_nombre = c.crr04_nombre,
                crr04_descripcion = c.crr04_descripcion,
                crr04_estado = c.crr04_estado,
                crr04_fechacreacion = c.crr04_fechacreacion,
                crr04_ultimaactualizacion = c.crr04_ultimaactualizacion
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
            crr04_intereses crr04_intereses = db.crr04_intereses.Find(id);
            if (crr04_intereses == null)
            {
                return HttpNotFound();
            }
            return View(crr04_intereses);
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
        public ActionResult Create([Bind(Include = "crr04_nombre,crr04_descripcion")] crr04_intereses crr04_intereses)
        {
            if (ModelState.IsValid)
            {

                crr04_intereses.crr04_estado = 1;
                crr04_intereses.crr04_fechacreacion = DateTime.Now;
                crr04_intereses.crr04_ultimaactualizacion = DateTime.Now;

                db.crr04_intereses.Add(crr04_intereses);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(crr04_intereses);
        }

        // GET: configuracion/tipoplan/Edit/5
        [Authorization(UserRoles.Admin)]
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            crr04_intereses crr04_intereses = db.crr04_intereses.Find(id);
            if (crr04_intereses == null)
            {
                return HttpNotFound();
            }
            return View(crr04_intereses);
        }

        // POST: configuracion/tipoplan/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorization(UserRoles.Admin)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "crr04_id,crr04_nombre,crr04_descripcion,crr04_estado")] crr04_intereses crr04_intereses)
        {
            if (ModelState.IsValid)
            {

                db.crr04_intereses.Attach(crr04_intereses);
                crr04_intereses.crr04_ultimaactualizacion = DateTime.Now;

                db.Entry(crr04_intereses).Property(x => x.crr04_nombre).IsModified = true;
                db.Entry(crr04_intereses).Property(x => x.crr04_descripcion).IsModified = true;
                db.Entry(crr04_intereses).Property(x => x.crr04_estado).IsModified = true;
                db.Entry(crr04_intereses).Property(x => x.crr04_ultimaactualizacion).IsModified = true;
                db.SaveChanges();

                /*                
                db.Entry(pln02_tipoplan).State = EntityState.Modified;
                db.SaveChanges();
                 */
                return RedirectToAction("Index");
            }
            return View(crr04_intereses);
        }

        // GET: configuracion/tipoplan/Delete/5
        [Authorization(UserRoles.Admin)]
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            crr04_intereses crr04_intereses = db.crr04_intereses.Find(id);
            if (crr04_intereses == null)
            {
                return HttpNotFound();
            }
            return View(crr04_intereses);
        }

        // POST: configuracion/tipoplan/Delete/5
        [Authorization(UserRoles.Admin)]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {

            var crr04_intereses = new crr04_intereses { crr04_id = id };
            db.crr04_intereses.Attach(crr04_intereses);
            crr04_intereses.crr04_estado = 2;
            db.Entry(crr04_intereses).Property(x => x.crr04_estado).IsModified = true;

            db.Configuration.ValidateOnSaveEnabled = false;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
