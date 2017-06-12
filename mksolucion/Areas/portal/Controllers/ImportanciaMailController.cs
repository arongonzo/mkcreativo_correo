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
    public class ImportanciaMailController : Controller
    {
        private ModelMK db = new ModelMK();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult con03_importancia_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<con03_importancia> con03_importancia = db.con03_importancia;
            DataSourceResult result = con03_importancia.ToDataSourceResult(request, c => new _con03_importancia 
            {
                con03_id = c.con03_id,
                con03_nombre = c.con03_nombre,
                con03_descripcion = c.con03_descripcion,
                con03_estado = c.con03_estado,
                con03_fechacreacion = c.con03_fechacreacion,
                con03_ultimaactualizacion = c.con03_ultimaactualizacion
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
