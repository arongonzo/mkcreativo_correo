using mksolucion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;


using System.Text;
using System.Web;
using System.IO;

using MailKit.Net.Smtp;
using MimeKit;
using System.Net.Mail;
using System.Net.Mime;
using MimeKit.Utils;



namespace mksolucion.Funtion.Mail
{
    public class mkemail
    {
        public static ModelMK db = new ModelMK();
        public mkemail() 
        { 
        }

        public static string Base_Mail_Ticket(string llave_usuario, string NumeroTicket, string Nombre, string mail, string asunto, string Mensaje, string archivo, decimal TipoSoporte, decimal tipoImportancia, string AccesoRapido)
        {

            string stx_To = String.Empty;
            string feedback = String.Empty;
            string Respuesta = "Error en el Envio del correo electronico";
            string stx_tipocontacto = string.Empty;
            string stx_Destinatariocorreo = string.Empty;

            string stx_importancia = string.Empty;

            string stx_asunto = string.Empty;
            string stx_html = string.Empty;
            string stx_txt = string.Empty;

            var querytc = from tc in db.con02_tipocontacto
                          where tc.con02_id == TipoSoporte

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

            var queryimp = from tc in db.con03_importancia
                           where tc.con03_id == tipoImportancia

                           select new
                           {
                               nombre = tc.con03_nombre
                           };

            if (queryimp.Count() > 0)
            {
                var datos = queryimp.ToList();
                foreach (var Row in datos)
                {
                    stx_importancia = Row.nombre.ToString();
                }
            }

            var query = from msn in db.ntf03_mensajepredef
                        where msn.ntf03_accesoRapido == AccesoRapido

                        select new
                        {
                            Asunto = msn.ntf03_Asunto,
                            Mensajetxt = msn.ntf03_mensajetxt,
                            Mensajehtml = msn.ntf03_mensajehtml
                        };

            if (query.Count() > 0)
            {
                var datos = query.ToList();
                foreach (var Row in datos)
                {
                    stx_asunto = Row.Asunto.ToString();
                    stx_html = Row.Mensajehtml.ToString();
                    stx_txt = Row.Mensajetxt.ToString();
                }
            }

            stx_asunto = String.Format(stx_asunto, NumeroTicket, asunto);
            stx_html = String.Format(stx_html, Nombre, asunto, stx_importancia, "Activo");



            string body = bodymail();
            var builder = new BodyBuilder();


            string sbx_Contenido_final_html = string.Format(body, "<img alt=\"Mail Creativo\" src=\"cid:{0}\" width=\"150\" height=\"50\" border=\"0\" />", HttpUtility.HtmlDecode(stx_html));
            string sbx_Contenido = HttpUtility.HtmlDecode(stx_html);

            String Server_ruta = System.Web.HttpContext.Current.Server.MapPath("~");
            String top = System.Web.HttpContext.Current.Server.MapPath("~") + "Content\\assets\\images\\logomailcreativo.png";
            

            var image = builder.LinkedResources.Add(top);
            image.ContentId = MimeUtils.GenerateMessageId();
            builder.HtmlBody = string.Format(sbx_Contenido_final_html, image.ContentId);

            var mimeMessage = new MimeMessage();
            mimeMessage.To.Add(new MailboxAddress(Nombre, mail));
            mimeMessage.Subject = stx_asunto;
            mimeMessage.Body = builder.ToMessageBody();
            

            int respuestaenvio = SendMail(mimeMessage, TipoSoporte);

            if (respuestaenvio == 1)
            {
                Respuesta = "Envio realizado con Exito";


                if (!String.IsNullOrEmpty(llave_usuario)) { 
                    ntf01_notificaciones ntf01_notificaciones = new Models.ntf01_notificaciones();

                    ntf01_notificaciones.ntf02_fechaenvio = DateTime.Now;
                    ntf01_notificaciones.ntf01_asunto = stx_asunto;
                    ntf01_notificaciones.ntf01_contenido = HttpUtility.HtmlEncode(sbx_Contenido);
                    ntf01_notificaciones.ntf01_destinatario = mail;
                    ntf01_notificaciones.ntf01_remitente = stx_Destinatariocorreo;
                    ntf01_notificaciones.UserId = llave_usuario;
                    ntf01_notificaciones.ntf02_id = 2;
                    ntf01_notificaciones.ntf01_estado = (int)respuestaenvio;

                    db.ntf01_notificaciones.Add(ntf01_notificaciones);
                    db.SaveChanges();
                }

            }

            return Respuesta;
        }

        public static string Base_Mail_Ticket_administradores(string llave_usuario,string NumeroTicket, string Nombre, string mail, string asunto, string Mensaje, string archivo, decimal TipoSoporte, decimal tipoImportancia, string AccesoRapido)
        {

           string stx_To = String.Empty;
            string feedback = String.Empty;
            string Respuesta = "Error en el Envio del correo electronico";
            string stx_tipocontacto = string.Empty;
            string stx_Destinatariocorreo = string.Empty;

            string stx_importancia = string.Empty;
            
            string stx_asunto = string.Empty;
            string stx_html = string.Empty;
            string stx_txt = string.Empty;

             var querytc = from tc in db.con02_tipocontacto
                          where tc.con02_id == TipoSoporte

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

            var queryimp = from tc in db.con03_importancia
                           where tc.con03_id == tipoImportancia

                           select new
                           {
                               nombre = tc.con03_nombre
                           };

            if (queryimp.Count() > 0)
            {
                var datos = queryimp.ToList();
                foreach (var Row in datos)
                {
                    stx_importancia = Row.nombre.ToString();
                }
            }

            var query = from msn in db.ntf03_mensajepredef
                        where msn.ntf03_accesoRapido == AccesoRapido

                        select new
                        {
                            Asunto = msn.ntf03_Asunto,
                            Mensajetxt = msn.ntf03_mensajetxt,
                            Mensajehtml = msn.ntf03_mensajehtml
                        };

           if (query.Count() > 0)
           {
               var datos = query.ToList();
               foreach (var Row in datos)
               {
                   stx_asunto = Row.Asunto.ToString();
                   stx_html = Row.Mensajehtml.ToString();
                   stx_txt = Row.Mensajetxt.ToString();
               }
           }

           stx_asunto = String.Format(stx_asunto, NumeroTicket);


            string body = bodymail();
            var builder = new BodyBuilder();

            
            

            String Server_ruta = System.Web.HttpContext.Current.Server.MapPath("~");
            String top = System.Web.HttpContext.Current.Server.MapPath("~") + "Content\\assets\\images\\logomailcreativo.png";
            LinkedResource imgTop = new LinkedResource(top, MediaTypeNames.Image.Jpeg);

            var image = builder.LinkedResources.Add(top);
            image.ContentId = MimeUtils.GenerateMessageId();
            

                        
            var queryadmin = from usr in db.AspNetUsers
                            join usrrl in db.AspNetUserRoles on usr.Id equals usrrl.UserId
                            join rol in db.AspNetRoles on usrrl.RoleId equals rol.Id
                            join usinf in db.usr01_infopersonal on usr.Id equals usinf.UserId
                            where rol.Name == "Admin"

                            select new
                            {
                                UserId = usr.Id,
                                Email = usr.Email,
                                admin = usinf.usr01_nombre +" "+ usinf.usr01_apellido
                            };
            int respuestaenvio = 0;

            if (queryadmin.Count() > 0)
            {
                var datosquery = queryadmin.ToList();
                foreach (var Row in datosquery)
                {



                    String Email = Row.Email.ToString();
                    String Id_usuario = Row.UserId.ToString();
                    String nombreadmin = Row.admin.ToString();

                    stx_html = String.Format(stx_html, nombreadmin, asunto, Nombre, stx_tipocontacto, stx_importancia, Mensaje, "Activo");
                    string sbx_Contenido_final_html = string.Format(body, "<img alt=\"Mail Creativo\" src=\"cid:{0}\" width=\"150\" height=\"50\" border=\"0\" />", HttpUtility.HtmlDecode(stx_html));
                    string sbx_Contenido = string.Format(body, "<img alt='Mail Creativo' src='http://localhost:13800/Content/assets/images/logomailcreativo.png' width='150' height='50' border='0' />", HttpUtility.HtmlDecode(stx_html));
                    builder.HtmlBody = string.Format(sbx_Contenido_final_html, image.ContentId);

                    var mimeMessage = new MimeMessage();
                    mimeMessage.To.Add(new MailboxAddress(nombreadmin, Email));
                    mimeMessage.Subject = stx_asunto;
                    mimeMessage.Body = builder.ToMessageBody();
                    
                    respuestaenvio = SendMail(mimeMessage, TipoSoporte);

                    ntf01_notificaciones ntf01_notificaciones = new Models.ntf01_notificaciones();

                    ntf01_notificaciones.ntf02_fechaenvio = DateTime.Now;
                    ntf01_notificaciones.ntf01_asunto = stx_asunto;
                    ntf01_notificaciones.ntf01_contenido = HttpUtility.HtmlEncode(sbx_Contenido);
                    ntf01_notificaciones.ntf01_destinatario = stx_Destinatariocorreo;
                    ntf01_notificaciones.ntf01_remitente = nombreadmin;
                    ntf01_notificaciones.UserId = Id_usuario;
                    ntf01_notificaciones.ntf02_id = 2;
                    ntf01_notificaciones.ntf01_estado = (int)respuestaenvio;

                    db.ntf01_notificaciones.Add(ntf01_notificaciones);
                    db.SaveChanges();
                }
            }
            
            if (respuestaenvio == 1)
            {
                Respuesta = "Envio realizado con Exito";
            }
           
            return Respuesta;
        }

        public static string bodymail() 
        {

            string body = "<div style='width:100%' align='center'><table border='0' cellspacing='0' cellpadding='0' width='100%' style='width:100.0%;border-collapse:collapse;padding:0px'><tr><td width='100%' valign='top' style='width:100.0%;padding:0px'><div align='center'><table border='0' cellspacing='0' cellpadding='0' width='100%' style='width:100.0%;border-collapse:collapse;padding:0px 0px 0px 0px;max-width:400px'><tr><td valign='top' style='background:#fff;padding:0cm 22.5pt 0cm 22.5pt'><div align='center'><table border='0' cellspacing='0' cellpadding='0' width='400' style='width:300.0pt;border-collapse:collapse;padding:0px'>  <tr><td width='400' valign='top' style='width:300.0pt;padding:0px' id='templateHeader'><div align='center'><table border='0' cellspacing='0' cellpadding='0' width='100%' style='width:100.0%;border-collapse:collapse;padding:0px'>  <tr><td valign='top' style='padding:30.0px 0px 30.0px 0px;max-width:400px'id=logoContainer><p align='center' style='text-align:center'>{0}</p></td>  </tr></table>  </div></td>  </tr></table>  </div></td></tr><tr><td valign='top' style='padding:0px 0px 0px 0px; border:none;padding:0px 0px 0px 0px' id=templateBody><div align=center><table border='0' cellspacing='0' cellpadding='0' width='100%' style='width:100.0%;border-collapse:collapse;padding-alt:0px 0px 0px 0px;max-width:700px'>  <tr><td valign='top' style='padding:0px 0px 0px 0px;max-width:700px; border-top:solid #F2F2F2 1.5pt;'><div align='center'><table border='0' cellspacing='0' cellpadding='0' width='700' style='width:525.0pt;border-collapse:collapse;padding:0px 0px 0px 0px;max-width:700px'>  <tr><td width='700' valign='top' style='width:525.0pt;padding:0px 0px 0px 0px'><div align='center'><table border='0' cellspacing='0' cellpadding='0' width='100%' style='width:100.0%;border-collapse:collapse;padding:0px 0px 0px 0px'>  <tr><td width='30' valign='top' style='width:22.5pt;padding:0px 0px 0px 0px'></td><td width='100%' valign=top style='width:100.0%;padding:0px 52.5px 0px 30.0px' id='bodyContainer'>{1}</td>  </tr></table>  </div></td>  </tr></table>  </div></td>  </tr></table>  </div></td></tr><tr><td valign='top' style='padding:0px 22.5px 0px 22.5px' id='templateFooter'><div align='center'><table border='0' cellspacing='0' cellpadding='0' width='640' style='width:480.0pt;border-collapse:collapse;padding:0px 0px 0px 0px;max-width:640px'>  <tr><td width='640' valign='top' style='width:480.0px;padding:0px 0px 0px 0px;max-width:640px' id='footerContent'><div align='center'><table border='0' cellspacing='0' cellpadding='0' width='100%' style='width:100.0%;border-collapse:collapse;padding:0px 0px 0px 0px;max-width:640px'>  <tr><td valign='top' style='border:none;border-top:solid #F2F2F2 1.5pt;padding:30.0px 0px 15.0px 0px'><p align='center' style='margin:0px;margin-bottom:.0001pt;text-align:center;line-height:18.0pt;'> <span style='font-size:9.0pt;font-family:Helvetica Neue;color:#484848'>© 2017 MKcreativo, Todos los derechosreservados.<br>Huerfanos 903 • Santiago • Chile<br>Telefono: +(56) 226 641 975 / +(56) 226 648 472 / +(56) 226 641 169</span></p></td>  </tr></table>  </div></td>  </tr></table>  </div></td></tr></table></div></td></tr></table></div>";
            return body;
        }


        public static string Base_Mail(string llave_usuario,string Nombre_usuario, string Email, string asunto, string[] Mensaje, decimal TipoSoporte, decimal tipoImportancia, string AccesoRapido)
        {

            string stx_To = String.Empty;
            string feedback = String.Empty;
            string Respuesta = "Error en el Envio del correo electronico";
            string stx_tipocontacto = string.Empty;
            string stx_Destinatariocorreo = string.Empty;

            string stx_importancia = string.Empty;

            string stx_asunto = string.Empty;
            string stx_html = string.Empty;
            string stx_txt = string.Empty;

            var querytc = from tc in db.con02_tipocontacto
                          where tc.con02_id == TipoSoporte

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

            var queryimp = from tc in db.con03_importancia
                           where tc.con03_id == tipoImportancia

                           select new
                           {
                               nombre = tc.con03_nombre
                           };

            if (queryimp.Count() > 0)
            {
                var datos = queryimp.ToList();
                foreach (var Row in datos)
                {
                    stx_importancia = Row.nombre.ToString();
                }
            }

            var query = from msn in db.ntf03_mensajepredef
                        where msn.ntf03_accesoRapido == AccesoRapido

                        select new
                        {
                            Asunto = msn.ntf03_Asunto,
                            Mensajetxt = msn.ntf03_mensajetxt,
                            Mensajehtml = msn.ntf03_mensajehtml
                        };

            if (query.Count() > 0)
            {
                var datos = query.ToList();
                foreach (var Row in datos)
                {
                    stx_asunto = Row.Asunto.ToString();
                    stx_html = Row.Mensajehtml.ToString();
                    stx_txt = Row.Mensajetxt.ToString();
                }
            }

            stx_asunto = String.Format(stx_asunto, asunto);
            stx_html = String.Format(stx_html, Mensaje);



            string body = bodymail();
            var builder = new BodyBuilder();


            string sbx_Contenido_final_html = string.Format(body, "<img alt=\"Mail Creativo\" src=\"cid:{0}\" width=\"150\" height=\"50\" border=\"0\" />", HttpUtility.HtmlDecode(stx_html));
            string sbx_Contenido = string.Format(body, "<img alt='Mail Creativo' src='http://localhost:13800/Content/assets/images/logomailcreativo.png' width='150' height='50' border='0' />", stx_html);

            String Server_ruta = System.Web.HttpContext.Current.Server.MapPath("~");
            String top = System.Web.HttpContext.Current.Server.MapPath("~") + "Content\\assets\\images\\logomailcreativo.png";


            var image = builder.LinkedResources.Add(top);
            image.ContentId = MimeUtils.GenerateMessageId();
            builder.HtmlBody = string.Format(sbx_Contenido_final_html, image.ContentId);

            var mimeMessage = new MimeMessage();
            mimeMessage.To.Add(new MailboxAddress(Nombre_usuario, Email));
            mimeMessage.Subject = stx_asunto;
            mimeMessage.Body = builder.ToMessageBody();


            int respuestaenvio = SendMail(mimeMessage, TipoSoporte);

            if (respuestaenvio == 1)
            {
                Respuesta = "Envio realizado con Exito";


                if (!String.IsNullOrEmpty(llave_usuario))
                {
                    ntf01_notificaciones ntf01_notificaciones = new Models.ntf01_notificaciones();

                    ntf01_notificaciones.ntf02_fechaenvio = DateTime.Now;
                    ntf01_notificaciones.ntf01_asunto = stx_asunto;
                    ntf01_notificaciones.ntf01_contenido = HttpUtility.HtmlEncode(sbx_Contenido);
                    ntf01_notificaciones.ntf01_destinatario = Email;
                    ntf01_notificaciones.ntf01_remitente = stx_Destinatariocorreo;
                    ntf01_notificaciones.UserId = llave_usuario;
                    ntf01_notificaciones.ntf02_id = 2;
                    ntf01_notificaciones.ntf01_estado = (int)respuestaenvio;

                    db.ntf01_notificaciones.Add(ntf01_notificaciones);
                    db.SaveChanges();
                }

            }

            return Respuesta;
        }

        public static string Base_Mail_Admin(string asunto, string[] Mensaje, decimal TipoSoporte, decimal tipoImportancia, string AccesoRapido)
        {

            string stx_To = String.Empty;
            string feedback = String.Empty;
            string Respuesta = "Error en el Envio del correo electronico";
            string stx_tipocontacto = string.Empty;
            string stx_Destinatariocorreo = string.Empty;

            string stx_importancia = string.Empty;

            string stx_asunto = string.Empty;
            string stx_html = string.Empty;
            string stx_txt = string.Empty;

            var querytc = from tc in db.con02_tipocontacto
                          where tc.con02_id == TipoSoporte

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

            var queryimp = from tc in db.con03_importancia
                           where tc.con03_id == tipoImportancia

                           select new
                           {
                               nombre = tc.con03_nombre
                           };

            if (queryimp.Count() > 0)
            {
                var datos = queryimp.ToList();
                foreach (var Row in datos)
                {
                    stx_importancia = Row.nombre.ToString();
                }
            }

            var query = from msn in db.ntf03_mensajepredef
                        where msn.ntf03_accesoRapido == AccesoRapido

                        select new
                        {
                            Asunto = msn.ntf03_Asunto,
                            Mensajetxt = msn.ntf03_mensajetxt,
                            Mensajehtml = msn.ntf03_mensajehtml
                        };

            if (query.Count() > 0)
            {
                var datos = query.ToList();
                foreach (var Row in datos)
                {
                    stx_asunto = Row.Asunto.ToString();
                    stx_html = Row.Mensajehtml.ToString();
                    stx_txt = Row.Mensajetxt.ToString();
                }
            }

            int respuestaenvio = 0;

            var queryadmin = from usr in db.AspNetUsers
                            join usrrl in db.AspNetUserRoles on usr.Id equals usrrl.UserId
                            join rol in db.AspNetRoles on usrrl.RoleId equals rol.Id
                            join usinf in db.usr01_infopersonal on usr.Id equals usinf.UserId
                            where rol.Name == "Admin"

                            select new
                            {
                                UserId = usr.Id,
                                Email = usr.Email,
                                admin = usinf.usr01_nombre +" "+ usinf.usr01_apellido
                            };
            

            if (queryadmin.Count() > 0)
            {
                var datosquery = queryadmin.ToList();
                foreach (var Row in datosquery)
                {

                    String Email = Row.Email.ToString();
                    String Id_usuario = Row.UserId.ToString();
                    String nombreadmin = Row.admin.ToString();


                    stx_asunto = String.Format(stx_asunto, asunto);
                    stx_html = String.Format(stx_html,  Mensaje);
                    stx_html = String.Format(stx_html, nombreadmin);

                    string body = bodymail();
                    var builder = new BodyBuilder();


                    string sbx_Contenido_final_html = string.Format(body, "<img alt=\"Mail Creativo\" src=\"cid:{0}\" width=\"150\" height=\"50\" border=\"0\" />", HttpUtility.HtmlDecode(stx_html));
                    string sbx_Contenido = string.Format(body, "<img alt='Mail Creativo' src='http://localhost:13800/Content/assets/images/logomailcreativo.png' width='150' height='50' border='0' />", stx_html);

                    String Server_ruta = System.Web.HttpContext.Current.Server.MapPath("~");
                    String top = System.Web.HttpContext.Current.Server.MapPath("~") + "Content\\assets\\images\\logomailcreativo.png";


                    var image = builder.LinkedResources.Add(top);
                    image.ContentId = MimeUtils.GenerateMessageId();
                    builder.HtmlBody = string.Format(sbx_Contenido_final_html, image.ContentId);

                    var mimeMessage = new MimeMessage();
                    mimeMessage.To.Add(new MailboxAddress(nombreadmin, Email));
                    mimeMessage.Subject = stx_asunto;
                    mimeMessage.Body = builder.ToMessageBody();


                    respuestaenvio = SendMail(mimeMessage, TipoSoporte);

                    if (respuestaenvio == 1)
                    {
                        Respuesta = "Envio realizado con Exito";


                        if (!String.IsNullOrEmpty(Id_usuario))
                        {
                            ntf01_notificaciones ntf01_notificaciones = new Models.ntf01_notificaciones();

                            ntf01_notificaciones.ntf02_fechaenvio = DateTime.Now;
                            ntf01_notificaciones.ntf01_asunto = stx_asunto;
                            ntf01_notificaciones.ntf01_contenido = HttpUtility.HtmlEncode(sbx_Contenido);
                            ntf01_notificaciones.ntf01_destinatario = Email;
                            ntf01_notificaciones.ntf01_remitente = stx_Destinatariocorreo;
                            ntf01_notificaciones.UserId = Id_usuario;
                            ntf01_notificaciones.ntf02_id = 2;
                            ntf01_notificaciones.ntf01_estado = (int)respuestaenvio;

                            db.ntf01_notificaciones.Add(ntf01_notificaciones);
                            db.SaveChanges();
                        }

                    }
                }
            }

            return Respuesta;
        }

        /*private static int SendMail(MailMessage message, decimal TipoSoporte)*/
        private static int SendMail(MimeMessage message, decimal TipoSoporte)
        {
            String stx_fromadresstitle = string.Empty;
            String stx_Host = string.Empty;
            int stx_Port = 25;
            String stx_usuariocredencial = string.Empty;
            String stx_usuariocredencialclave = string.Empty;
            Boolean btx_EnableSsl = false;

            var querytc = from tc in db.con02_tipocontacto
                          where tc.con02_id == TipoSoporte

                          select new
                          {
                              FromAdressTitle = tc.con02_nombre,
                              Host = tc.con02_host,
                              Port = tc.con02_port,
                              usuariocredencial = tc.con02_usuariocredencial,
                              usuariocredencialclave = tc.con02_usuariocredencialclave
                          };

            if (querytc.Count() > 0)
            {
                var datos = querytc.ToList();
                foreach (var Row in datos)
                {
                    stx_fromadresstitle = Row.FromAdressTitle.ToString(); 
                    stx_Host = Row.Host.ToString();
                    stx_Port = int.Parse(Row.Port.ToString());
                    stx_usuariocredencial = Row.usuariocredencial.ToString();
                    stx_usuariocredencialclave = Row.usuariocredencialclave.ToString();
                }
            }

            int estado = 0;

            message.From.Add(new MailboxAddress(stx_fromadresstitle, stx_usuariocredencial));

            /*Host = stx_Host,
                Port = int.Parse(stx_Port),
                Credentials = new System.Net.NetworkCredential(stx_usuariocredencial, stx_usuariocredencialclave),
                EnableSsl = false,
                UseDefaultCredentials = false,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Timeout = 10000*/
            try
            {

                using (var client = new MailKit.Net.Smtp.SmtpClient())
                {

                    client.Connect(stx_Host, stx_Port, false);
                    // Note: only needed if the SMTP server requires authentication
                    // Error 5.5.1 Authentication 
                    client.Authenticate(stx_usuariocredencial, stx_usuariocredencialclave);
                    client.Send(message);
                
                    client.Disconnect(true);

                };
                estado = 1;
            }
            catch (Exception e)
            {
                estado = 2;
            }

            return estado;
        }

    }
}