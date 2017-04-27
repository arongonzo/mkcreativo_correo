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
    public class EstadosActivacionController : Controller
    {
        private ModelMK db = new ModelMK();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult gen01_estados_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<gen01_estados> gen01_estados = db.gen01_estados;
            DataSourceResult result = gen01_estados.ToDataSourceResult(request, c => new _gen01_estados 
            {
                gen01_id = c.gen01_id,
                gen01_nombre = c.gen01_nombre,
                gen01_descripcion = c.gen01_descripcion,
                gen01_fechacreacion = c.gen01_fechacreacion
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
    }
}
