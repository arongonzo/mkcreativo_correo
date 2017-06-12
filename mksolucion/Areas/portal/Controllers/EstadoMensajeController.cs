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
    public class EstadoMensajeController : Controller
    {
        private ModelMK db = new ModelMK();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult con05_EstadoMensaje_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<con05_EstadoMensaje> con05_EstadoMensaje = db.con05_EstadoMensaje;
            DataSourceResult result = con05_EstadoMensaje.ToDataSourceResult(request, c => new _con05_EstadoMensaje 
            {
                con05_id = c.con05_id,
                con05_nombre = c.con05_nombre,
                con05_descripcion = c.con05_descripcion,
                con05_estado = c.con05_estado,
                con05_fechacreacion = c.con05_fechacreacion,
                con05_ultimaactualizacion = c.con05_ultimaactualizacion
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
            con05_EstadoMensaje con05_EstadoMensaje = db.con05_EstadoMensaje.Find(id);
            if (con05_EstadoMensaje == null)
            {
                return HttpNotFound();
            }
            return View(con05_EstadoMensaje);
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
        public ActionResult Create([Bind(Include = "con05_nombre,con05_descripcion")] con05_EstadoMensaje con05_EstadoMensaje)
        {
            if (ModelState.IsValid)
            {
                con05_EstadoMensaje.con05_estado = 1;
                con05_EstadoMensaje.con05_fechacreacion = DateTime.Now;
                con05_EstadoMensaje.con05_ultimaactualizacion = DateTime.Now;

                db.con05_EstadoMensaje.Add(con05_EstadoMensaje);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(con05_EstadoMensaje);
        }

        // GET: configuracion/tipoplan/Edit/5
        [Authorization(UserRoles.Admin)]
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            con05_EstadoMensaje con05_EstadoMensaje = db.con05_EstadoMensaje.Find(id);
            if (con05_EstadoMensaje == null)
            {
                return HttpNotFound();
            }
            return View(con05_EstadoMensaje);
        }

        // POST: configuracion/tipoplan/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorization(UserRoles.Admin)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "con05_id,con05_nombre,con05_descripcion,con05_estado")] con05_EstadoMensaje con05_EstadoMensaje)
        {
            if (ModelState.IsValid)
            {

                db.con05_EstadoMensaje.Attach(con05_EstadoMensaje);
                con05_EstadoMensaje.con05_ultimaactualizacion = DateTime.Now;

                db.Entry(con05_EstadoMensaje).Property(x => x.con05_nombre).IsModified = true;
                db.Entry(con05_EstadoMensaje).Property(x => x.con05_descripcion).IsModified = true;
                db.Entry(con05_EstadoMensaje).Property(x => x.con05_estado).IsModified = true;
                db.Entry(con05_EstadoMensaje).Property(x => x.con05_ultimaactualizacion).IsModified = true;
                db.SaveChanges();

                /*                
                db.Entry(pln02_tipoplan).State = EntityState.Modified;
                db.SaveChanges();
                 */
                return RedirectToAction("Index");
            }
            return View(con05_EstadoMensaje);
        }

        // GET: configuracion/tipoplan/Delete/5
        [Authorization(UserRoles.Admin)]
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            con05_EstadoMensaje con05_EstadoMensaje = db.con05_EstadoMensaje.Find(id);
            if (con05_EstadoMensaje == null)
            {
                return HttpNotFound();
            }
            return View(con05_EstadoMensaje);
        }

        // POST: configuracion/tipoplan/Delete/5
        [Authorization(UserRoles.Admin)]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {

            var con05_EstadoMensaje = new con05_EstadoMensaje { con05_id = id };
            db.con05_EstadoMensaje.Attach(con05_EstadoMensaje);
            con05_EstadoMensaje.con05_estado = 2;
            db.Entry(con05_EstadoMensaje).Property(x => x.con05_estado).IsModified = true;

            db.Configuration.ValidateOnSaveEnabled = false;
            db.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}
