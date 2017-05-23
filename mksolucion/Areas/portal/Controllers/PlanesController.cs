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
    public class PlanesController : Controller
    {
        private ModelMK db = new ModelMK();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult pln01_planes_Read([DataSourceRequest]DataSourceRequest request)
        {
            return Json(Read().ToDataSourceResult(request));
        }

        public IEnumerable<_pln01_planes> Read()
        {
            return GetAll();
        }

        public IList<_pln01_planes> GetAll()
        {
            IList<_pln01_planes> result = new List<_pln01_planes>();

            var dbplan = db.pln01_planes.AsQueryable();
            dbplan = dbplan.Where(p => p.pln01_activo == 1);
            dbplan = dbplan.Where(p => p.pln02_tipoplan.pln02_estado == 1);
            dbplan = dbplan.Where(p => p.pln02_tipoplan.pln03_tipocobro.pln03_estado == 1);

            result = dbplan.Select(c => new _pln01_planes
            {
                pln01_id = (decimal)c.pln01_id,
                pln02_id = (decimal)c.pln02_id,
                pln01_nombre = c.pln01_nombre,
                pln01_detalle = c.pln01_detalle,
                pln01_html = c.pln01_html,
                pln01_activo = c.pln01_activo,
                pln01_ultimaactualizacion = c.pln01_ultimaactualizacion,
                pln01_fechacreacion = c.pln01_fechacreacion,
                _TipoPlan = new _pln02_tipoplan()
                {
                    pln02_id = (decimal)c.pln02_tipoplan.pln02_id,
                    pln02_nombre = c.pln02_tipoplan.pln02_nombre,
                    pln02_estado = c.pln02_tipoplan.pln02_estado,
                    _tipocobro = new _pln03_tipocobro()
                    {
                        pln03_id = (decimal)c.pln02_tipoplan.pln03_id,
                        pln03_nombre = c.pln02_tipoplan.pln03_tipocobro.pln03_nombre,
                        pln03_estado = c.pln02_tipoplan.pln03_tipocobro.pln03_estado
                    }
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

        // GET: portal/pln02_tipoplan/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pln01_planes pln01_planes = db.pln01_planes.Find(id);
            if (pln01_planes == null)
            {
                return HttpNotFound();
            }
            return View(pln01_planes);
        }

        // GET: portal/pln02_tipoplan/Create
        public ActionResult Create()
        {
            ViewBag.pln03_id = new SelectList(db.pln03_tipocobro, "pln03_id", "pln03_nombre");
            return View();
        }

        // POST: portal/pln02_tipoplan/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(FormCollection values)
        {
            if (ModelState.IsValid)
            {
                pln01_planes pln01_planes = new pln01_planes();
                pln01_planes.pln01_nombre = values["pln01_nombre"];
                pln01_planes.pln01_detalle = values["pln01_detalle"];
                pln01_planes.pln01_html = values["pln01_html"];
                pln01_planes.pln02_id = Convert.ToDecimal(values["cbxtipoplan"].ToString());
                pln01_planes.pln01_activo = 1;
                pln01_planes.pln01_fechacreacion = DateTime.Now;
                pln01_planes.pln01_ultimaactualizacion = DateTime.Now;

                db.pln01_planes.Add(pln01_planes);

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        public JsonResult GetTipoCobro()
        {
            var TipoCobro = db.pln03_tipocobro.AsQueryable();
            TipoCobro = TipoCobro.Where(p => p.pln03_estado == 1);
            return Json(TipoCobro.Select(p => new { pln03_id = p.pln03_id, pln03_nombre = p.pln03_nombre }), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetTipoPlan(int? tipocobro)
        {
            var TipoPlan = db.pln02_tipoplan.AsQueryable();
            TipoPlan = TipoPlan.Where(p => p.pln02_estado == 1);
            if (tipocobro != null)
            {
                TipoPlan = TipoPlan.Where(p => p.pln03_id == tipocobro);
                
            }

            return Json(TipoPlan.Select(p => new { pln02_id = p.pln02_id, pln02_nombre = p.pln02_nombre }), JsonRequestBehavior.AllowGet);
        }

        // GET: portal/pln01_plan/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pln01_planes pln01_planes = db.pln01_planes.Find(id);
            if (pln01_planes == null)
            {
                return HttpNotFound();
            }
            ViewBag.pln03_id = new SelectList(db.pln03_tipocobro, "pln03_id", "pln03_nombre", pln01_planes.pln02_tipoplan.pln03_id);
            return View(pln01_planes);
        }

        // POST: portal/pln02_tipoplan/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FormCollection values)
        {
            if (ModelState.IsValid)
            {
                pln01_planes pln01_planes = db.pln01_planes.Find(int.Parse(values["pln01_id"]));
                pln01_planes.pln01_nombre = values["pln01_nombre"];
                pln01_planes.pln01_detalle = values["pln01_detalle"];
                pln01_planes.pln01_html = values["pln01_html"];
                pln01_planes.pln02_id = Convert.ToDecimal(values["cbxtipoplan"].ToString());
                pln01_planes.pln01_activo = int.Parse(values["pln01_activo"]);
                pln01_planes.pln01_ultimaactualizacion = DateTime.Now;

                db.Entry(pln01_planes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(values);
        }

        // GET: portal/pln02_tipoplan/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pln01_planes pln01_planes = db.pln01_planes.Find(id);
            if (pln01_planes == null)
            {
                return HttpNotFound();
            }
            return View(pln01_planes);
        }

        // POST: portal/pln02_tipoplan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            pln01_planes pln01_planes = db.pln01_planes.Find(id);
            db.pln01_planes.Remove(pln01_planes);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
