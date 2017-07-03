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
using System.IO;
using mksolucion.Funtion.Mail;

namespace mksolucion.Areas.portal.Controllers
{
    public class SoporteController : Controller
    {
        private ModelMK db = new ModelMK();
        // GET: portal/Soporte
        public ActionResult Index()
        {
            return View();
        }

        // GET: portal/Soporte
        public ActionResult nuevo_soporte()
        {
            string stx_user = Session["UserId"].ToString();

            string Email = string.Empty;
            string nombreusuario = string.Empty;

            var querycuenta = from usrcnt in db.cnt03_cuenta_usuario
                              join usr2 in db.AspNetUsers on usrcnt.UserId equals usr2.Id
                              join usrinfo in db.usr01_infopersonal on usr2.Id equals usrinfo.UserId
                              join cnt in db.cnt01_cuenta on usrcnt.cnt01_id equals cnt.cnt01_id
                              where usr2.Id == stx_user
                              select new
                              {
                                  Email = usr2.Email,
                                  nombreusuario = usrinfo.usr01_nombre + "  " + usrinfo.usr01_apellido
                              };

            if (querycuenta.Count() > 0)
            {
                var datoscuenta = querycuenta.ToList();
                foreach (var Rowcuenta in datoscuenta)
                {
                    Email = Rowcuenta.Email.ToString();
                    nombreusuario = Rowcuenta.nombreusuario.ToString();
                }
            }

            ViewBag.email = Email;
            ViewBag.nombre = nombreusuario;

            if (Request.QueryString["idtpcnt"] != null) 
            {
                ViewBag.llave_tipocontacto = Request.QueryString["idtpcnt"].ToString();
            }

            ViewBag.llave_importancia = "2";

            return View();
        }

        // POST: portal/pln02_tipoplan/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult nuevo_soporte(FormCollection values)
        {
            var path = string.Empty;
            string Llave_usuario = Session["UserId"].ToString();


            if (ModelState.IsValid)
            {

                con01_contacto con01_contacto = new con01_contacto();

                con01_contacto.con01_nombre = values["con01_nombre"].ToString();
                con01_contacto.con01_email = values["con01_email"].ToString();
                con01_contacto.con01_asunto = values["con01_asunto"].ToString();
                con01_contacto.con02_id = Convert.ToDecimal(values["cbxtipoSoporte"].ToString());
                con01_contacto.con03_id = Convert.ToDecimal(values["cbximportancia"].ToString());
                con01_contacto.ser01_id = Convert.ToDecimal(values["cbxservicio"].ToString());
                con01_contacto.con01_mensaje = values["con01_mensaje"].ToString();
                con01_contacto.UserId = Llave_usuario;
                con01_contacto.con05_id= 1;
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
                        path = Path.Combine(Server.MapPath("~/Images/"), llave_contacto.ToString() + fileext.ToString());
                        file.SaveAs(path);
                    }
                }

                mkemail.Base_Mail_Ticket(Llave_usuario, llave_contacto.ToString(), con01_contacto.con01_nombre, con01_contacto.con01_email, con01_contacto.con01_asunto, con01_contacto.con01_mensaje, path, (decimal)con01_contacto.con02_id, (decimal)con01_contacto.con03_id, "ContactoInvitado");
                mkemail.Base_Mail_Ticket_administradores("", llave_contacto.ToString(), con01_contacto.con01_nombre, con01_contacto.con01_email, con01_contacto.con01_asunto, con01_contacto.con01_mensaje, path, (decimal)con01_contacto.con02_id, (decimal)con01_contacto.con03_id, "ContactoinvitadoAdministrador");

                return RedirectToAction("ContactFinish");
            }



            return View(values);
        }

        public ActionResult ContactFinish()
        {
            return View();
        }


        public ActionResult con01_contacto_Read([DataSourceRequest]DataSourceRequest request)
        {
            return Json(Read().ToDataSourceResult(request));
        }

        public IEnumerable<_con01_contacto> Read()
        {
            return GetAll();
        }

        public IList<_con01_contacto> GetAll()
        {

            string userid = Session["UserId"].ToString();

            IList<_con01_contacto> result = new List<_con01_contacto>();

            var dbContacto = db.con01_contacto.AsQueryable();
            dbContacto = dbContacto.Where(p => p.con01_estado == 1);
            dbContacto = dbContacto.Where(p => p.UserId == userid);

            result = dbContacto.Select(c => new _con01_contacto
            {
                con01_id = (decimal)c.con01_id,
                con01_nombre = c.con01_nombre,
                con01_email = c.con01_email,
                con01_asunto = c.con01_asunto,
                con01_estado = c.con01_estado,
                con01_mensaje = c.con01_mensaje,
                con01_fechacreacion = c.con01_fechacreacion,
                con01_ultimaactualizacion = c.con01_ultimaactualizacion,

                _TipoContacto = new _con02_tipocontacto()
                {
                    con02_id = (decimal)c.con02_tipocontacto.con02_id,
                    con02_nombre = c.con02_tipocontacto.con02_nombre,
                    con02_estado = c.con02_tipocontacto.con02_estado
                }
                ,
                _Importancia = new _con03_importancia()
                {
                    con03_id = (decimal)c.con03_importancia.con03_id,
                    con03_nombre = c.con03_importancia.con03_nombre
                }
                ,
                _EstadoMensaje = new _con05_EstadoMensaje()
                {
                    con05_id = (decimal)c.con05_EstadoMensaje.con05_id,
                    con05_nombre = c.con05_EstadoMensaje.con05_nombre
                }

            }).ToList();
            return result;
        }

    }
}