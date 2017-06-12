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
    public class TipoSoporteController : Controller
    {
        private ModelMK db = new ModelMK();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult _con02_tipocontacto_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<con02_tipocontacto> con02_tipocontacto = db.con02_tipocontacto;
            request.Filters.Add(new FilterDescriptor() { Member = "con02_estado", MemberType = typeof(Int32), Operator = FilterOperator.IsEqualTo, Value = "1" });      

            DataSourceResult result = con02_tipocontacto.ToDataSourceResult(request, c => new _con02_tipocontacto 
            {
                con02_id = c.con02_id,
                con02_nombre = c.con02_nombre,
                con02_descripcion = c.con02_descripcion,
                con02_usuariocredencial = c.con02_usuariocredencial,
                con02_usuariocredencialclave = c.con02_usuariocredencialclave,
                con02_host = c.con02_host,
                con02_port = c.con02_port,
                con02_ssl = c.con02_ssl,
                con02_estado = c.con02_estado,
                con02_fechacreacion = c.con02_fechacreacion,
                con02_ultimaactualizacion = c.con02_ultimaactualizacion
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
            con02_tipocontacto con02_tipocontacto = db.con02_tipocontacto.Find(id);
            if (con02_tipocontacto == null)
            {
                return HttpNotFound();
            }
            return View(con02_tipocontacto);
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
        public ActionResult Create(FormCollection values)
        {
            if (ModelState.IsValid)
            {
                con02_tipocontacto con02_tipocontacto = new con02_tipocontacto();

                con02_tipocontacto.con02_nombre = values["con02_nombre"];
                con02_tipocontacto.con02_descripcion = values["con02_descripcion"];
                con02_tipocontacto.con02_host = values["con02_host"];
                con02_tipocontacto.con02_port = values["con02_port"];
                con02_tipocontacto.con02_ssl = Convert.ToInt32(values["cbx_ssl"]);
                con02_tipocontacto.con02_usuariocredencial = values["con02_usuariocredencial"];
                con02_tipocontacto.con02_usuariocredencialclave = values["con02_usuariocredencialclave"];

                con02_tipocontacto.con02_estado = 1;
                con02_tipocontacto.con02_fechacreacion = DateTime.Now;
                con02_tipocontacto.con02_ultimaactualizacion = DateTime.Now;

                db.con02_tipocontacto.Add(con02_tipocontacto);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(values);
        }

        // GET: configuracion/tipoplan/Edit/5
        [Authorization(UserRoles.Admin)]
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            con02_tipocontacto con02_tipocontacto = db.con02_tipocontacto.Find(id);
            if (con02_tipocontacto == null)
            {
                return HttpNotFound();
            }
            return View(con02_tipocontacto);
        }

        // POST: configuracion/tipoplan/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorization(UserRoles.Admin)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "con02_id,con02_nombre,con02_descripcion,con02_usuariocredencial,con02_usuariocredencialclave,con02_host,con02_port,con02_ssl,con02_estado")] con02_tipocontacto con02_tipocontacto)
        {
            if (ModelState.IsValid)
            {

                db.con02_tipocontacto.Attach(con02_tipocontacto);
                con02_tipocontacto.con02_ultimaactualizacion = DateTime.Now;

                db.Entry(con02_tipocontacto).Property(x => x.con02_nombre).IsModified = true;
                db.Entry(con02_tipocontacto).Property(x => x.con02_descripcion).IsModified = true;

                db.Entry(con02_tipocontacto).Property(x => x.con02_usuariocredencial).IsModified = true;
                db.Entry(con02_tipocontacto).Property(x => x.con02_usuariocredencialclave).IsModified = true;
                db.Entry(con02_tipocontacto).Property(x => x.con02_host).IsModified = true;
                db.Entry(con02_tipocontacto).Property(x => x.con02_port).IsModified = true;
                db.Entry(con02_tipocontacto).Property(x => x.con02_ssl).IsModified = true;

                db.Entry(con02_tipocontacto).Property(x => x.con02_estado).IsModified = true;
                db.Entry(con02_tipocontacto).Property(x => x.con02_ultimaactualizacion).IsModified = true;
                db.SaveChanges();

                /*                
                db.Entry(con02_tipocontacto).State = EntityState.Modified;
                db.SaveChanges();
                 */
                return RedirectToAction("Index");
            }
            return View(con02_tipocontacto);
        }
        // GET: configuracion/tipoplan/Delete/5
        [Authorization(UserRoles.Admin)]
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            con02_tipocontacto con02_tipocontacto = db.con02_tipocontacto.Find(id);
            if (con02_tipocontacto == null)
            {
                return HttpNotFound();
            }
            return View(con02_tipocontacto);
        }

        // POST: configuracion/tipoplan/Delete/5
        [Authorization(UserRoles.Admin)]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {

            var con02_tipocontacto = new con02_tipocontacto { con02_id = id };
            db.con02_tipocontacto.Attach(con02_tipocontacto);
            con02_tipocontacto.con02_estado = 2;
            db.Entry(con02_tipocontacto).Property(x => x.con02_estado).IsModified = true;

            db.Configuration.ValidateOnSaveEnabled = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
