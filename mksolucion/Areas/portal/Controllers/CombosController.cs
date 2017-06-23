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
    public class CombosController : Controller
    {
        private ModelMK db = new ModelMK();
        // GET: portal/Combos
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetTipoNotificacion()
        {
            var Tipo = db.ntf02_tiponotificacioncorreo.AsQueryable();
            Tipo = Tipo.Where(p => p.ntf02_estado == 1);
            return Json(Tipo.Select(p => new { ntf02_id = p.ntf02_id, ntf02_nombre = p.ntf02_nombre }), JsonRequestBehavior.AllowGet);
        }
    }
}