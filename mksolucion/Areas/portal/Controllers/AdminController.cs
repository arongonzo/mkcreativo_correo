using mksolucion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace mksolucion.Areas.portal.Controllers
{
    public class AdminController : Controller
    {
        private ModelMK db = new ModelMK();
        // GET: portal/Admin
        public ActionResult Index()
        {
            return View();
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}