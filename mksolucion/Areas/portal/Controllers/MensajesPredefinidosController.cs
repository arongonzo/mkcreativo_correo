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
    public class MensajesPredefinidosController : Controller
    {
        private ModelMK db = new ModelMK();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult con04_mensajepredef_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<con04_mensajepredef> con04_mensajepredef = db.con04_mensajepredef;
            DataSourceResult result = con04_mensajepredef.ToDataSourceResult(request, c => new _con04_mensajepredef 
            {
                con04_id = c.con04_id,
                con04_accesoRapido = c.con04_accesoRapido,
                con04_descripcion = c.con04_descripcion,
                con04_Asunto = c.con04_Asunto,
                con04_mensajetxt = c.con04_mensajetxt,
                con04_mensajehtml = c.con04_mensajehtml,
                con04_estado = c.con04_estado,
                con04_fechacreacion = c.con04_fechacreacion,
                con04_ultimaactualizacion = c.con04_ultimaactualizacion
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
            con04_mensajepredef con04_mensajepredef = db.con04_mensajepredef.Find(id);
            if (con04_mensajepredef == null)
            {
                return HttpNotFound();
            }
            return View(con04_mensajepredef);
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
        public ActionResult Create([Bind(Include = "con04_accesoRapido,con04_descripcion,con04_Asunto, con04_mensajetxt, con04_mensajehtml")] con04_mensajepredef con04_mensajepredef)
        {
            if (ModelState.IsValid)
            {

                con04_mensajepredef.con04_estado = 1;
                con04_mensajepredef.con04_fechacreacion = DateTime.Now;
                con04_mensajepredef.con04_ultimaactualizacion = DateTime.Now;

                db.con04_mensajepredef.Add(con04_mensajepredef);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(con04_mensajepredef);
        }

        // GET: configuracion/tipoplan/Edit/5
        [Authorization(UserRoles.Admin)]
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            con04_mensajepredef con04_mensajepredef = db.con04_mensajepredef.Find(id);
            if (con04_mensajepredef == null)
            {
                return HttpNotFound();
            }
            return View(con04_mensajepredef);
        }

        // POST: configuracion/tipoplan/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorization(UserRoles.Admin)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FormCollection values)
        {
            if (ModelState.IsValid)
            {

                con04_mensajepredef con04_mensajepredef = db.con04_mensajepredef.Find(int.Parse(values["con04_id"]));


                con04_mensajepredef.con04_accesoRapido = values["con04_accesoRapido"];
                con04_mensajepredef.con04_descripcion = values["con04_descripcion"];
                con04_mensajepredef.con04_Asunto = values["con04_Asunto"];
                con04_mensajepredef.con04_mensajehtml = values["con04_mensajehtml"];
                con04_mensajepredef.con04_mensajetxt = values["con04_mensajetxt"];
                con04_mensajepredef.con04_estado = Int32.Parse(values["con04_estado"]);
                con04_mensajepredef.con04_ultimaactualizacion = DateTime.Now;

                db.Entry(con04_mensajepredef).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(values);
        }

        // GET: configuracion/tipoplan/Delete/5
        [Authorization(UserRoles.Admin)]
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            con04_mensajepredef con04_mensajepredef = db.con04_mensajepredef.Find(id);
            if (con04_mensajepredef == null)
            {
                return HttpNotFound();
            }
            return View(con04_mensajepredef);
        }

        // POST: configuracion/tipoplan/Delete/5
        [Authorization(UserRoles.Admin)]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {

            var con04_mensajepredef = new con04_mensajepredef { con04_id = id };
            db.con04_mensajepredef.Attach(con04_mensajepredef);
            con04_mensajepredef.con04_estado = 2;
            db.Entry(con04_mensajepredef).Property(x => x.con04_estado).IsModified = true;

            db.Configuration.ValidateOnSaveEnabled = false;
            db.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}
