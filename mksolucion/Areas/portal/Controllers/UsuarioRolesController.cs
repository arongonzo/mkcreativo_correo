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
    public class UsuarioRolesController : Controller
    {
        private ModelMK db = new ModelMK();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AspNetUserRoles_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<AspNetUserRoles> aspnetuserroles = db.AspNetUserRoles;
            DataSourceResult result = aspnetuserroles.ToDataSourceResult(request, c => new _AspNetUserRoles 
            {
                UserId = c.UserId,
                RoleId = c.RoleId,
                AspNetUsers = c.AspNetUsers,
                AspNetRoles = c.AspNetRoles
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
