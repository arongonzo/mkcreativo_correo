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
using mksolucion.Funtion.Mail;
using System.Linq;

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

        public ActionResult ContactFinish()
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
        // Para protegerse de ataques de publicaci�n excesiva, habilite las propiedades espec�ficas a las que desea enlazarse. Para obtener 
        // m�s informaci�n vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Contact(FormCollection values)
        {
            var response = Request["g-recaptcha-response"];
            const string secret = "6Lf45SQUAAAAAHC8cKMgOyqbdCfaOZnUW_Fy6ANu";
            var path = string.Empty;

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
                    con01_contacto con01_contacto = new con01_contacto();

                    con01_contacto.con01_nombre = values["con01_nombre"].ToString();
                    con01_contacto.con01_email = values["con01_email"].ToString();
                    con01_contacto.con01_asunto = values["con01_asunto"].ToString();
                    con01_contacto.con01_mensaje = values["edit_con01_mensaje"];
                    con01_contacto.con02_id = Int32.Parse(values["con02_id"]);
                    con01_contacto.con03_id = Int32.Parse(values["con03_id"]);
                    con01_contacto.con05_id = 1;
                    

                    con01_contacto.con01_estado = 1;
                    con01_contacto.con01_fechacreacion = DateTime.Now;
                    con01_contacto.con01_ultimaactualizacion = DateTime.Now;

                    db.con01_contacto.Add(con01_contacto);
                    db.SaveChanges();
                    decimal llave_contacto = con01_contacto.con01_id;

                    string stx_tipocontacto = "";
                    string stx_Destinatariocorreo = "";
                    decimal id_tiposoporte = Int32.Parse(values["con02_id"]);

                    var querytc = from tc in db.con02_tipocontacto
                                  where tc.con02_id == id_tiposoporte

                                  select new
                                  {
                                      nombre = tc.con02_nombre,
                                      destinatariocorreo = tc.con02_usuariocredencial

                                  };

                    if (querytc.Count() > 0)
                    {
                        var datos = querytc.ToList();
                        foreach (var Row in datos)
                        {
                            stx_tipocontacto = Row.nombre.ToString();
                            stx_Destinatariocorreo = Row.destinatariocorreo.ToString();
                        }
                    }

                    con01_contacto.con01_destinatario = stx_tipocontacto;
                    con01_contacto.con01_emaildestinatario = stx_Destinatariocorreo;

                    con01_contacto.con01_asunto = "[Ticket ID: "+llave_contacto+" ] " + values["con01_asunto"].ToString();
                    db.Entry(con01_contacto).State = EntityState.Modified;
                    db.SaveChanges();

                    if (Request.Files.Count > 0)
                    {
                        var file = Request.Files[0];

                        if (file != null && file.ContentLength > 0)
                        {
                            var fileName = Path.GetFileName(file.FileName);
                            var fileext = Path.GetExtension(file.FileName);
                            path = Path.Combine(Server.MapPath("~/Images/"), llave_contacto.ToString() + fileext.ToString());
                            file.SaveAs(path);
                        }
                    }





                    mkemail.Base_Mail_Ticket("", llave_contacto.ToString(), con01_contacto.con01_nombre, con01_contacto.con01_email, con01_contacto.con01_asunto, con01_contacto.con01_mensaje, path, (decimal)con01_contacto.con02_id, (decimal)con01_contacto.con03_id, "ContactoInvitado");
                    mkemail.Base_Mail_Ticket_administradores("", llave_contacto.ToString(), con01_contacto.con01_nombre, con01_contacto.con01_email, con01_contacto.con01_asunto, con01_contacto.con01_mensaje, path, (decimal)con01_contacto.con02_id, (decimal)con01_contacto.con03_id, "ContactoinvitadoAdministrador");

                    return RedirectToAction("ContactFinish");
                }
            }


            return View(values);
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
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       