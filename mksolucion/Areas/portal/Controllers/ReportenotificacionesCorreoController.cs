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
    public class ReportenotificacionesCorreoController : Controller
    {
        private ModelMK db = new ModelMK();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ntf01_notificaciones_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<ntf01_notificaciones> ntf01_notificaciones = db.ntf01_notificaciones;



            DataSourceResult result = ntf01_notificaciones.ToDataSourceResult(request, c => new _ntf01_notificaciones 
            {
                ntf01_id = c.ntf01_id,
                UserId = c.UserId,
                ntf02_id = c.ntf02_id,
                ntf02_fechaenvio = c.ntf02_fechaenvio,
                ntf01_asunto = c.ntf01_asunto,
                ntf01_remitente = c.ntf01_remitente,
                ntf01_destinatario = c.ntf01_destinatario,
                ntf01_destinatariocc = c.ntf01_destinatariocc,
                ntf02_idpadre = c.ntf02_idpadre,
                ntf01_contenido = c.ntf01_contenido,
                ntf01_adjuntourl = c.ntf01_adjuntourl,
                ntf01_estado = c.ntf01_estado,
                nombre_tiponotificacion = c.ntf02_tiponotificacioncorreo.ntf02_nombre,
                User_Name = c.AspNetUsers.UserName
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
