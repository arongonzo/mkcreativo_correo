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


        public JsonResult GetTipoContacto()
        {
            var Tipo = db.con02_tipocontacto.AsQueryable();
            Tipo = Tipo.Where(p => p.con02_estado == 1);
            return Json(Tipo.Select(p => new { con02_id = p.con02_id, con02_nombre = p.con02_nombre }), JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetImportancia()
        {
            var Tipo = db.con03_importancia.AsQueryable();
            Tipo = Tipo.Where(p => p.con03_estado == 1);
            return Json(Tipo.Select(p => new { con03_id = p.con03_id, con03_nombre = p.con03_nombre }), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetServicioCliente()
        {

            string userid = Session["UserId"].ToString();

            var query = from serv01 in db.serv01_servicios 
                        join pln01 in  db.pln01_planes on serv01.pnl01_id equals pln01.pln01_id
                        join cnt01 in db.cnt01_cuenta on serv01.cnt01_id equals cnt01.cnt01_id 
                        join cnt03 in db.cnt03_cuenta_usuario on cnt01.cnt01_id equals cnt03.cnt01_id 
                        join Users in db.AspNetUsers on cnt03.UserId equals Users.Id 
                        join pln02 in db.pln02_tipoplan on pln01.pln02_id equals pln02.pln02_id 
                        join pln03 in db.pln03_tipocobro on pln02.pln03_id equals pln03.pln03_id 
                        join cnt02 in db.cnt02_tipocuenta on cnt01.cnt02_id equals cnt02.cnt02_id
                        where  (serv01.ser01_estado == 1) && (pln01.pln01_activo == 1) && (pln02.pln02_estado == 1) 
                        && (pln03.pln03_estado == 1)  && (cnt02.cnt02_estado == 1) 
                        && (Users.Id == userid)
            select new
            {
                ser01_id = serv01.ser01_id,
                pln01_nombre = pln01.pln01_nombre
                
            };

            var datos = query.ToList().Distinct();
            return Json(datos.Select(p => new { ser01_id = p.ser01_id, ser01_nombre = p.pln01_nombre }), JsonRequestBehavior.AllowGet);
        }
    }
}