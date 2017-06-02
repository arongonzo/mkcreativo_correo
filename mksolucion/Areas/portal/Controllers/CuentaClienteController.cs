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
    public class CuentaClienteController : Controller
    {
        private ModelMK db = new ModelMK();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult cnt01_cuenta_Read([DataSourceRequest]DataSourceRequest request)
        {
            return Json(Read().ToDataSourceResult(request));
        }

        public IEnumerable<_cnt01_cuenta> Read()
        {
            return GetAll();
        }

        public IList<_cnt01_cuenta> GetAll()
        {
            IList<_cnt01_cuenta> result = new List<_cnt01_cuenta>();

            var dbcuenta = db.cnt01_cuenta.AsQueryable();
            dbcuenta = dbcuenta.Where(p => p.cnt01_estado == 1);
            dbcuenta = dbcuenta.Where(p => p.cnt02_tipocuenta.cnt02_estado == 1);
            
            result = dbcuenta.Select(c => new _cnt01_cuenta
            {
                cnt01_id = (decimal)c.cnt01_id,
                cnt02_id = (decimal)c.cnt02_id,
                cnt01_nombre = c.cnt01_nombre,
                cnt01_estado = c.cnt01_estado,
                cnt01_ultimaactualizacion = c.cnt01_ultimaactualizacion,
                cnt01_fechacreacion = c.cnt01_fechacreacion,
                _tipocuenta = new _cnt02_tipocuenta()
                {
                    cnt02_id = (decimal)c.cnt02_tipocuenta.cnt02_id,
                    cnt02_nombre = c.cnt02_tipocuenta.cnt02_nombre,
                    cnt02_estado = c.cnt02_tipocuenta.cnt02_estado
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
