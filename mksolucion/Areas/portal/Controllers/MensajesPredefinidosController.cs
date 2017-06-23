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

        public ActionResult ntf03_mensajepredef_Read([DataSourceRequest]DataSourceRequest request)
        {
            return Json(Read().ToDataSourceResult(request));
        }

        public IEnumerable<_ntf03_mensajepredef> Read()
        {
            return GetAll();
        }

        public IList<_ntf03_mensajepredef> GetAll()
        {
            IList<_ntf03_mensajepredef> result = new List<_ntf03_mensajepredef>();

            var dbDatos = db.ntf03_mensajepredef.AsQueryable();
            dbDatos = dbDatos.Where(p => p.ntf03_estado == 1);
            dbDatos = dbDatos.Where(p => p.ntf02_tiponotificacioncorreo.ntf02_estado == 1);
            
            result = dbDatos.Select(c => new _ntf03_mensajepredef
            {
                ntf03_id = (decimal)c.ntf03_id,
                ntf02_id = (decimal)c.ntf02_id,
                ntf03_accesoRapido = c.ntf03_accesoRapido,
                ntf03_descripcion = c.ntf03_descripcion,
                ntf03_Asunto = c.ntf03_Asunto,
                ntf03_mensajetxt = c.ntf03_mensajetxt,
                ntf03_mensajehtml = c.ntf03_mensajehtml,
                ntf03_estado = c.ntf03_estado,
                ntf03_fechacreacion = c.ntf03_fechacreacion,
                ntf03_ultimaactualizacion = c.ntf03_ultimaactualizacion,
                _TipoNotificacion = new _ntf02_tiponotificacioncorreo()
                {
                    ntf02_id = (decimal)c.ntf02_tiponotificacioncorreo.ntf02_id,
                    ntf02_nombre = c.ntf02_tiponotificacioncorreo.ntf02_nombre,
                    ntf02_estado = c.ntf02_tiponotificacioncorreo.ntf02_estado,
                }
            }).ToList();
            return result;
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
            ntf03_mensajepredef ntf03_mensajepredef = db.ntf03_mensajepredef.Find(id);
            if (ntf03_mensajepredef == null)
            {
                return HttpNotFound();
            }
            return View(ntf03_mensajepredef);
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

                ntf03_mensajepredef ntf03_mensajepredef = new ntf03_mensajepredef();
                
                ntf03_mensajepredef.ntf03_accesoRapido = values["ntf03_accesoRapido"];
                ntf03_mensajepredef.ntf03_descripcion = values["ntf03_descripcion"];
                ntf03_mensajepredef.ntf03_Asunto = values["ntf03_Asunto"];

                ntf03_mensajepredef.ntf03_Asunto = values["ntf03_Asunto"];

                ntf03_mensajepredef.ntf02_id = Convert.ToDecimal(values["cbxtiponotificacion"].ToString());

                ntf03_mensajepredef.ntf03_mensajehtml = values["edit_ntf03_mensajehtml"];
                ntf03_mensajepredef.ntf03_mensajetxt = values["ntf03_mensajetxt"];

                ntf03_mensajepredef.ntf03_estado = 1;
                ntf03_mensajepredef.ntf03_fechacreacion = DateTime.Now;
                ntf03_mensajepredef.ntf03_ultimaactualizacion = DateTime.Now;

                db.ntf03_mensajepredef.Add(ntf03_mensajepredef);
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
            ntf03_mensajepredef ntf03_mensajepredef = db.ntf03_mensajepredef.Find(id);
            if (ntf03_mensajepredef == null)
            {
                return HttpNotFound();
            }
            return View(ntf03_mensajepredef);
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

                ntf03_mensajepredef ntf03_mensajepredef = db.ntf03_mensajepredef.Find(int.Parse(values["ntf03_id"]));


                ntf03_mensajepredef.ntf03_accesoRapido = values["ntf03_accesoRapido"];
                ntf03_mensajepredef.ntf03_descripcion = values["ntf03_descripcion"];
                ntf03_mensajepredef.ntf03_Asunto = values["ntf03_Asunto"];
                ntf03_mensajepredef.ntf02_id = Convert.ToDecimal(values["cbxtiponotificacion"].ToString());
                ntf03_mensajepredef.ntf03_mensajehtml = values["edit_ntf03_mensajehtml"];
                ntf03_mensajepredef.ntf03_mensajetxt = values["ntf03_mensajetxt"];
                ntf03_mensajepredef.ntf03_estado = Int32.Parse(values["ntf03_estado"]);
                ntf03_mensajepredef.ntf03_ultimaactualizacion = DateTime.Now;

                db.Entry(ntf03_mensajepredef).State = EntityState.Modified;
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

            ntf03_mensajepredef ntf03_mensajepredef = db.ntf03_mensajepredef.Find(id);
            if (ntf03_mensajepredef == null)
            {
                return HttpNotFound();
            }
            return View(ntf03_mensajepredef);
        }

        // POST: configuracion/tipoplan/Delete/5
        [Authorization(UserRoles.Admin)]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {

            var ntf03_mensajepredef = new ntf03_mensajepredef { ntf03_id = id };
            db.ntf03_mensajepredef.Attach(ntf03_mensajepredef);
            ntf03_mensajepredef.ntf03_estado = 2;
            db.Entry(ntf03_mensajepredef).Property(x => x.ntf03_estado).IsModified = true;

            db.Configuration.ValidateOnSaveEnabled = false;
            db.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}
