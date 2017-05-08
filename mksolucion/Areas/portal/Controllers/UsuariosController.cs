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
    [SessionExpire]
    public class UsuariosController : Controller
    {
        private ModelMK db = new ModelMK();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AspNetUsers_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<AspNetUsers> aspnetusers = db.AspNetUsers;
            DataSourceResult result = aspnetusers.ToDataSourceResult(request, c => new _AspNetUsers 
            {
                Id = c.Id,
                Email = c.Email,
                EmailConfirmed = c.EmailConfirmed,
                PasswordHash = c.PasswordHash,
                SecurityStamp = c.SecurityStamp,
                PhoneNumber = c.PhoneNumber,
                PhoneNumberConfirmed = c.PhoneNumberConfirmed,
                TwoFactorEnabled = c.TwoFactorEnabled,
                LockoutEndDateUtc = c.LockoutEndDateUtc,
                LockoutEnabled = c.LockoutEnabled,
                AccessFailedCount = c.AccessFailedCount,
                UserName = c.UserName
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
