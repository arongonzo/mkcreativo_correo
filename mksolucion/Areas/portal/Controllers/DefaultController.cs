using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mksolucion.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace mksolucion.Areas.portal.Controllers
{
    [SessionExpire]
    public class DefaultController : Controller
    {
        private ModelMK db = new ModelMK();
        
        // GET: portal/Default
        public ActionResult Index()
        {
            
            string UserId = Session["UserId"].ToString();
            var cuentausuario = from cnt in db.cnt03_cuenta_usuario
                                where cnt.UserId == UserId
                                select cnt;
            if (cuentausuario != null)
            {
                if (cuentausuario.Count() <= 0)
                {

                    return RedirectToAction("Index", "estadocorreo");

                }
            }

            return View();
        }


        public ActionResult SessionTimeout()
        {

            Session.Timeout = 3;

            return Json("", JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}