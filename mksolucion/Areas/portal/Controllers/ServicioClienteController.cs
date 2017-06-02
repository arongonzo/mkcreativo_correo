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
    public class ServicioClienteController : Controller
    {
        private ModelMK db = new ModelMK();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult serv01_servicios_Read([DataSourceRequest]DataSourceRequest request)
        {
            return Json(Read().ToDataSourceResult(request));
        }

        public IEnumerable<_serv01_servicios> Read()
        {
            return GetAll();
        }

        public IList<_serv01_servicios> GetAll()
        {
            IList<_serv01_servicios> result = new List<_serv01_servicios>();

            var dbserv = db.serv01_servicios.AsQueryable();

            dbserv = dbserv.Where(p => p.ser01_estado == 1);
            dbserv = dbserv.Where(p => p.cnt01_cuenta.cnt01_estado == 1);
            dbserv = dbserv.Where(p => p.cnt01_cuenta.cnt02_tipocuenta.cnt02_estado == 1);
            dbserv = dbserv.Where(p => p.pln01_planes.pln01_activo == 1);
            dbserv = dbserv.Where(p => p.pln01_planes.pln02_tipoplan.pln02_estado == 1);
            dbserv = dbserv.Where(p => p.pln01_planes.pln02_tipoplan.pln03_tipocobro.pln03_estado == 1);

            result = dbserv.Select(c => new _serv01_servicios
            {
                ser01_id = (decimal)c.ser01_id,
                ser01_estado = c.ser01_estado,
                ser01_ultimaactualizacion = c.ser01_ultimaactualizacion,
                ser01_fechacreacion = c.ser01_fechacreacion,
                _planes = new _pln01_planes()
                {
                    pln01_id = (decimal)c.pln01_planes.pln01_id,
                    pln01_nombre = c.pln01_planes.pln01_nombre,
                    _TipoPlan = new _pln02_tipoplan()
                    {
                        pln02_id = (decimal)c.pln01_planes.pln02_tipoplan.pln02_id,
                        pln02_nombre = c.pln01_planes.pln02_tipoplan.pln02_nombre,
                        _tipocobro = new _pln03_tipocobro()
                        {
                            pln03_id = (decimal)c.pln01_planes.pln02_tipoplan.pln03_id,
                            pln03_nombre = c.pln01_planes.pln02_tipoplan.pln03_tipocobro.pln03_nombre,
                        }
                    }
                },
                _cuentaCliente = new _cnt01_cuenta()
                {
                    cnt01_id = (decimal)c.cnt01_cuenta.cnt01_id,
                    cnt01_nombre = c.cnt01_cuenta.cnt01_nombre,
                    _tipocuenta = new _cnt02_tipocuenta()
                    {
                        cnt02_id = (decimal)c.cnt01_cuenta.cnt02_tipocuenta.cnt02_id,
                        cnt02_nombre = c.cnt01_cuenta.cnt02_tipocuenta.cnt02_nombre
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
