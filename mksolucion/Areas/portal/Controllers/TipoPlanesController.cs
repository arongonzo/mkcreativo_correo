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
    public class TipoPlanesController : Controller
    {
        private ModelMK db = new ModelMK();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult pln02_tipoplan_Read([DataSourceRequest]DataSourceRequest request)
        {
            return Json(Read().ToDataSourceResult(request));
        }

        public IEnumerable<_pln02_tipoplan> Read()
        {
            return GetAll();
        }

        public IList<_pln02_tipoplan> GetAll()
        {
            IList<_pln02_tipoplan> result = new List<_pln02_tipoplan>();
            result = db.pln02_tipoplan.Select(c => new _pln02_tipoplan
            {
                pln02_id = (decimal)c.pln02_id,
                 pln03_id = (decimal)c.pln03_id,
                pln02_nombre = c.pln02_nombre,
                pln02_descripcion = c.pln02_descripcion,
                pln02_estado = c.pln02_estado,
                pln02_ultimaactualizacion = c.pln02_ultimaactualizacion,
                pln02_fechacreacion = c.pln02_fechacreacion,
                pln03_nombre = c.pln03_tipocobro.pln03_nombre,
                _tipocobro = new _pln03_tipocobro()
                {
                    pln03_id = c.pln03_tipocobro.pln03_id,
                    pln03_nombre = c.pln03_tipocobro.pln03_nombre,
                    pln03_estado = c.pln03_tipocobro.pln03_estado
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
            pln02_tipoplan pln02_tipoplan = db.pln02_tipoplan.Find(id);
            if (pln02_tipoplan == null)
            {
                return HttpNotFound();
            }
            return View(pln02_tipoplan);
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
                pln02_tipoplan pln02_tipoplan = new pln02_tipoplan();
                pln02_tipoplan.pln02_nombre = values["pln02_nombre"];
                pln02_tipoplan.pln02_descripcion = values["pln02_nombre"];
                pln02_tipoplan.pln02_estado = 1;
                pln02_tipoplan.pln03_id = Convert.ToDecimal(values["cbxtipocobro"].ToString());

                db.pln02_tipoplan.Add(pln02_tipoplan);
                
                db.SaveChanges();
                return RedirectToAction("Index");
            }
 
            return View();
        }


        public JsonResult GetTipoCobro()
        {
            return Json(db.pln03_tipocobro.Select(p => new { pln03_id = p.pln03_id, pln03_nombre = p.pln03_nombre }), JsonRequestBehavior.AllowGet);
        }


        // GET: portal/pln02_tipoplan/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pln02_tipoplan pln02_tipoplan = db.pln02_tipoplan.Find(id);
            if (pln02_tipoplan == null)
            {
                return HttpNotFound();
            }
            ViewBag.pln02_estado = new SelectList(db.gen01_estados, "gen01_id", "gen01_nombre", pln02_tipoplan.pln02_estado);
            ViewBag.pln03_id = new SelectList(db.pln03_tipocobro, "pln03_id", "pln03_nombre", pln02_tipoplan.pln03_id);
            return View(pln02_tipoplan);
        }

        // POST: portal/pln02_tipoplan/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "pln02_id,pln03_id,pln02_nombre,pln02_descripcion,pln02_estado,pln02_fechacreacion,pln02_ultimaactualizacion")] pln02_tipoplan pln02_tipoplan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pln02_tipoplan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.pln02_estado = new SelectList(db.gen01_estados, "gen01_id", "gen01_nombre", pln02_tipoplan.pln02_estado);
            ViewBag.pln03_id = new SelectList(db.pln03_tipocobro, "pln03_id", "pln03_nombre", pln02_tipoplan.pln03_id);
            return View(pln02_tipoplan);
        }

        // GET: portal/pln02_tipoplan/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pln02_tipoplan pln02_tipoplan = db.pln02_tipoplan.Find(id);
            if (pln02_tipoplan == null)
            {
                return HttpNotFound();
            }
            return View(pln02_tipoplan);
        }

        // POST: portal/pln02_tipoplan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            pln02_tipoplan pln02_tipoplan = db.pln02_tipoplan.Find(id);
            db.pln02_tipoplan.Remove(pln02_tipoplan);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
