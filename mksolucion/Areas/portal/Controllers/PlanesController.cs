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
            result = db.pln01_planes.Select(c => new _pln01_planes
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


    }
}
