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
    public class EstadoCorreoController : Controller
    {
        private ModelMK db = new ModelMK();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult crr08_estadoCorreo_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<crr08_estadoCorreo> crr08_estadocorreo = db.crr08_estadoCorreo;

            request.Filters.Add(new FilterDescriptor() { Member = "crr08_estado", MemberType = typeof(Int32), Operator = FilterOperator.IsEqualTo, Value = "1" });

            DataSourceResult result = crr08_estadocorreo.ToDataSourceResult(request, c => new _crr08_estadoCorreo 
            {
                crr08_id = c.crr08_id,
                crr08_nombre = c.crr08_nombre,
                crr08_descripcion = c.crr08_descripcion,
                crr08_estado = c.crr08_estado,
                crr08_fechacreacion = c.crr08_fechacreacion,
                crr08_ultimaactualizacion = c.crr08_ultimaactualizacion
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
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            crr08_estadoCorreo crr08_estadoCorreo = db.crr08_estadoCorreo.Find(id);
            if (crr08_estadoCorreo == null)
            {
                return HttpNotFound();
            }
            return View(crr08_estadoCorreo);
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
        public ActionResult Create([Bind(Include = "crr08_nombre,crr08_descripcion")] crr08_estadoCorreo crr08_estadoCorreo)
        {
            if (ModelState.IsValid)
            {

                crr08_estadoCorreo.crr08_estado = 1;
                crr08_estadoCorreo.crr08_fechacreacion = DateTime.Now;
                crr08_estadoCorreo.crr08_ultimaactualizacion = DateTime.Now;

                db.crr08_estadoCorreo.Add(crr08_estadoCorreo);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(crr08_estadoCorreo);
        }

        // GET: configuracion/tipoplan/Edit/5
        [Authorization(UserRoles.Admin)]
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            crr08_estadoCorreo crr08_estadoCorreo = db.crr08_estadoCorreo.Find(id);
            if (crr08_estadoCorreo == null)
            {
                return HttpNotFound();
            }
            return View(crr08_estadoCorreo);
        }

        // POST: configuracion/tipoplan/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorization(UserRoles.Admin)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "crr08_id,crr08_nombre,crr08_descripcion,crr08_estado")] crr08_estadoCorreo crr08_estadoCorreo)
        {
            if (ModelState.IsValid)
            {

                db.crr08_estadoCorreo.Attach(crr08_estadoCorreo);
                crr08_estadoCorreo.crr08_ultimaactualizacion = DateTime.Now;

                db.Entry(crr08_estadoCorreo).Property(x => x.crr08_nombre).IsModified = true;
                db.Entry(crr08_estadoCorreo).Property(x => x.crr08_descripcion).IsModified = true;
                db.Entry(crr08_estadoCorreo).Property(x => x.crr08_estado).IsModified = true;
                db.Entry(crr08_estadoCorreo).Property(x => x.crr08_ultimaactualizacion).IsModified = true;
                db.SaveChanges();

                /*                
                db.Entry(pln02_tipoplan).State = EntityState.Modified;
                db.SaveChanges();
                 */
                return RedirectToAction("Index");
            }
            return View(crr08_estadoCorreo);
        }

        // GET: configuracion/tipoplan/Delete/5
        [Authorization(UserRoles.Admin)]
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            crr08_estadoCorreo crr08_estadoCorreo = db.crr08_estadoCorreo.Find(id);
            if (crr08_estadoCorreo == null)
            {
                return HttpNotFound();
            }
            return View(crr08_estadoCorreo);
        }

        // POST: configuracion/tipoplan/Delete/5
        [Authorization(UserRoles.Admin)]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            var crr08_estadoCorreo = new crr08_estadoCorreo { crr08_id = id };
            db.crr08_estadoCorreo.Attach(crr08_estadoCorreo);
            crr08_estadoCorreo.crr08_estado = 2;
            db.Entry(crr08_estadoCorreo).Property(x => x.crr08_estado).IsModified = true;

            db.Configuration.ValidateOnSaveEnabled = false;
            db.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}
