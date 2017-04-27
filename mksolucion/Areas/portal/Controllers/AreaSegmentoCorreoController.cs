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
    public class AreaSegmentoCorreoController : Controller
    {
        private ModelMK db = new ModelMK();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult crr03_areasegmento_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<crr03_areasegmento> crr03_areasegmento = db.crr03_areasegmento;

            request.Filters.Add(new FilterDescriptor() { Member = "crr03_estado", MemberType = typeof(Int32), Operator = FilterOperator.IsEqualTo, Value = "1" });

            DataSourceResult result = crr03_areasegmento.ToDataSourceResult(request, c => new _crr03_areasegmento 
            {
                crr03_id = c.crr03_id,
                crr03_nombre = c.crr03_nombre,
                crr03_descripcion = c.crr03_descripcion,
                crr03_estado = c.crr03_estado,
                crr03_fechacreacion = c.crr03_fechacreacion,
                crr03_ultimaactualizacion = c.crr03_ultimaactualizacion
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
            crr03_areasegmento crr03_areasegmento = db.crr03_areasegmento.Find(id);
            if (crr03_areasegmento == null)
            {
                return HttpNotFound();
            }
            return View(crr03_areasegmento);
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
        public ActionResult Create([Bind(Include = "crr03_nombre,crr03_descripcion")] crr03_areasegmento crr03_areasegmento)
        {
            if (ModelState.IsValid)
            {

                crr03_areasegmento.crr03_estado = 1;
                crr03_areasegmento.crr03_fechacreacion = DateTime.Now;
                crr03_areasegmento.crr03_ultimaactualizacion = DateTime.Now;

                db.crr03_areasegmento.Add(crr03_areasegmento);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(crr03_areasegmento);
        }

        // GET: configuracion/tipoplan/Edit/5
        [Authorization(UserRoles.Admin)]
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            crr03_areasegmento crr03_areasegmento = db.crr03_areasegmento.Find(id);
            if (crr03_areasegmento == null)
            {
                return HttpNotFound();
            }
            return View(crr03_areasegmento);
        }

        // POST: configuracion/tipoplan/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorization(UserRoles.Admin)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "crr03_id,crr03_nombre,crr03_descripcion,crr03_estado")] crr03_areasegmento crr03_areasegmento)
        {
            if (ModelState.IsValid)
            {

                db.crr03_areasegmento.Attach(crr03_areasegmento);
                crr03_areasegmento.crr03_ultimaactualizacion = DateTime.Now;

                db.Entry(crr03_areasegmento).Property(x => x.crr03_nombre).IsModified = true;
                db.Entry(crr03_areasegmento).Property(x => x.crr03_descripcion).IsModified = true;
                db.Entry(crr03_areasegmento).Property(x => x.crr03_estado).IsModified = true;
                db.Entry(crr03_areasegmento).Property(x => x.crr03_ultimaactualizacion).IsModified = true;
                db.SaveChanges();

                /*                
                db.Entry(pln02_tipoplan).State = EntityState.Modified;
                db.SaveChanges();
                 */
                return RedirectToAction("Index");
            }
            return View(crr03_areasegmento);
        }

        // GET: configuracion/tipoplan/Delete/5
        [Authorization(UserRoles.Admin)]
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            crr03_areasegmento crr03_areasegmento = db.crr03_areasegmento.Find(id);
            if (crr03_areasegmento == null)
            {
                return HttpNotFound();
            }
            return View(crr03_areasegmento);
        }

        // POST: configuracion/tipoplan/Delete/5
        [Authorization(UserRoles.Admin)]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {

            var crr03_areasegmento = new crr03_areasegmento { crr03_id = id };
            db.crr03_areasegmento.Attach(crr03_areasegmento);
            crr03_areasegmento.crr03_estado = 2;
            db.Entry(crr03_areasegmento).Property(x => x.crr03_estado).IsModified = true;

            db.Configuration.ValidateOnSaveEnabled = false;
            db.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}
