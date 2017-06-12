using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using mksolucion.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Kendo.Mvc;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using GooglereCAPTCHa.Models;
using System.IO;
using System.Web.Mail;

namespace mksolucion.Controllers
{
    public class HomeController : Controller
    {
        private ModelMK db = new ModelMK();
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult TimeoutRedirect()
        {
            return View();
        }
        
        public ActionResult Contact()
        {
            ViewBag.con02_id = new SelectList(db.con02_tipocontacto, "con02_id", "con02_nombre");
            ViewBag.con03_id = new SelectList(db.con03_importancia, "con03_id", "con03_nombre");
            ViewBag.con01_estado = new SelectList(db.gen01_estados, "gen01_id", "gen01_nombre");
            ViewBag.ser01_id = new SelectList(db.serv01_servicios, "ser01_id", "ser01_id");
            return View();
        }

        // POST: portal/pln02_tipoplan/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Contact(con01_contacto con01_contacto)
        {
            var response = Request["g-recaptcha-response"];
            const string secret = "6Lf45SQUAAAAAHC8cKMgOyqbdCfaOZnUW_Fy6ANu";

            var client = new WebClient();
            var reply =
                client.DownloadString(
                    string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secret, response));

            var captchaResponse = JsonConvert.DeserializeObject<CaptchaResponse>(reply);

            //when response is false check for the error message
            if (!captchaResponse.Success)
            {
                if (captchaResponse.ErrorCodes.Count <= 0) return View();

                var error = captchaResponse.ErrorCodes[0].ToLower();
                switch (error)
                {
                    case ("missing-input-secret"):
                        ViewBag.Message = "The secret parameter is missing.";
                        break;
                    case ("invalid-input-secret"):
                        ViewBag.Message = "The secret parameter is invalid or malformed.";
                        break;

                    case ("missing-input-response"):
                        ModelState.AddModelError("CustomError", "Debe indicar que no es un ROBOT");
                        break;
                    case ("invalid-input-response"):
                        ViewBag.Message = "The response parameter is invalid or malformed.";
                        break;

                    default:
                        ViewBag.Message = "Error occured. Please try again";
                        break;
                }
            }
            else
            {
                if (ModelState.IsValid)
                {
                    con01_contacto.con01_estado = 1;
                    con01_contacto.con01_fechacreacion = DateTime.Now;
                    con01_contacto.con01_ultimaactualizacion = DateTime.Now;

                    db.con01_contacto.Add(con01_contacto);
                    db.SaveChanges();
                    decimal llave_contacto = con01_contacto.con01_id;




                    if (Request.Files.Count > 0)
                    {
                        var file = Request.Files[0];

                        if (file != null && file.ContentLength > 0)
                        {
                            var fileName = Path.GetFileName(file.FileName);
                            var fileext = Path.GetExtension(file.FileName);
                            var path = Path.Combine(Server.MapPath("~/Images/"), llave_contacto.ToString() + fileext.ToString());
                            file.SaveAs(path);
                        }
                    }

                    //string textplain = "Gracias por ponerte en contacto con nuestro equipo de apoyo. Un ticket de soporte ahora se ha abierto para tu solicitud. Se te notificará cuando tengamos una respuesta vía correo electrónico";
                    //string html = string.Format("<table border='0' cellspacing='0' cellpadding='0' align='left' width='100%' style='width:100.0%;border-collapse:collapse;margin-left:-2.25pt;margin-right:-2.25pt;padding:0px 0px 0px 0px'><tr><td valign='top' style='padding:0px 0px 30.0px 0px' id='bodyContent'><h1 align='center' style='text-align:center;line-height:31.5pt;'>&nbsp; </h1><h1 align='center' style='text-align:center;line-height:31.5pt;'><span style='font-size:20px;font-family: Helvetica Neue;color:#626262;text-decoration:none;'>Bienvenido, {0}</span> </h1></td></tr><tr><td valign='top' style='padding:0px 0px 3.75px 0px'><div align='center'><table border='0' cellspacing='0' cellpadding='0' width='100%' style='width:100.0%;border-collapse:collapse;padding-alt:0px 0px 0px 0px'><tr><td style='padding:0px 0px 0px 0px'><div align='center'><table border='0' cellspacing='0' cellpadding='0' width='200' style='width:150.0pt;border-collapse:collapse;padding:0px 0px 0px 0px'><tr><td valign='top' style='background:#52BAD5;padding:15.0px 15.0px 15.0px 15.0px'><p align='center' style='text-align:center'> <span style='font-family:Times New Roman'> <a href='{1}' ='_blank' style='border-radius:3px;display:inline-block'> <b> <span style='font-family:Helvetica Neue; color:white;letter-spacing:.25pt;background:#52BAD5'>Activar Cuenta</span></b></a> </td></tr></table></div></td></tr></table></div></td></tr><tr><td valign='top' style='padding:0px 0px 30.0px 0px'><p align='center' style='margin:0px;margin-bottom:.0001pt;text-align:center;line-height:31.5pt;'> <span style='font-size:10.5pt;font-family:Helvetica Neue;color:#929292'>(Solo para confirmar que eres tu)</span></p></td></tr></table>", model.Email, callbackUrl);

                    //decimal dcm_tiponotificacion = 0;


                    //var query = from tiponotificacion in db.ntf02_tiponotificacioncorreo
                    //            where tiponotificacion.ntf02_nombre == "notificación"
                    //            select new
                    //            {
                    //                llaveNotificacion = tiponotificacion.ntf02_id
                    //            };

                    //if (query.Count() > 0)
                    //{
                    //    var datos = query.ToList();
                    //    foreach (var Row in datos)
                    //    {
                    //        dcm_tiponotificacion = (decimal)Row.llaveNotificacion;
                    //    }
                    //}

                    //var mail = mksolucion.Funtion.Mail.mkemail.Base_Mail_Cliente(message, html, textplain, user.Id, dcm_tiponotificacion);






                    return RedirectToAction("Index");
                }
            }

            ViewBag.con02_id = new SelectList(db.con02_tipocontacto, "con02_id", "con02_nombre", con01_contacto.con02_id);
            ViewBag.con03_id = new SelectList(db.con03_importancia, "con03_id", "con03_nombre", con01_contacto.con03_id);
            ViewBag.con01_estado = new SelectList(db.gen01_estados, "gen01_id", "gen01_nombre", con01_contacto.con01_estado);
            ViewBag.ser01_id = new SelectList(db.serv01_servicios, "ser01_id", "ser01_id", con01_contacto.ser01_id);
            return View(con01_contacto);
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
