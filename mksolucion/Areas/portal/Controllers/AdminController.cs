using mksolucion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace mksolucion.Areas.portal.Controllers
{
    [SessionExpire]
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

        public ActionResult SetSession()
        {
            Session["Test"] = "Test Value";
            return View();
        }

        public ActionResult Keepalive()
        {
            return Json("OK", JsonRequestBehavior.AllowGet);
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return View();
        }

        public ActionResult AjaxClick()
        {
            return Json("OK", JsonRequestBehavior.AllowGet);
        }

    }
}