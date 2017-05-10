using mksolucion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Web;

namespace mksolucion.Funtion.Mail
{
    public class mkemail
    {
        
        public mkemail() 
        { 
        }


        public static string Base_Mail_ServicioCliente(MailMessage message, string stx_Contenido_html, string Stx_Contenido_Text, string Llave_usuario, decimal tiponotificacion)
        {

            ModelMK db = new ModelMK();
            string stx_To = String.Empty;
            string feedback = String.Empty;
            string Respuesta = "Error en el Envio del correo electronico";

            string body = "<div style='width:100%' align='center'><table border='0' cellspacing='0' cellpadding='0' width='100%' style='width:100.0%;border-collapse:collapse;padding:0px'><tr><td width='100%' valign='top' style='width:100.0%;padding:0px'><div align='center'><table border='0' cellspacing='0' cellpadding='0' width='100%' style='width:100.0%;border-collapse:collapse;padding:0px 0px 0px 0px;max-width:400px'><tr><td valign='top' style='background:#fff;padding:0cm 22.5pt 0cm 22.5pt'><div align='center'><table border='0' cellspacing='0' cellpadding='0' width='400' style='width:300.0pt;border-collapse:collapse;padding:0px'>  <tr><td width='400' valign='top' style='width:300.0pt;padding:0px' id='templateHeader'><div align='center'><table border='0' cellspacing='0' cellpadding='0' width='100%' style='width:100.0%;border-collapse:collapse;padding:0px'>  <tr><td valign='top' style='padding:30.0px 0px 30.0px 0px;max-width:400px'id=logoContainer><p align='center' style='text-align:center'>{0}</p></td>  </tr></table>  </div></td>  </tr></table>  </div></td></tr><tr><td valign='top' style='padding:0px 0px 0px 0px; border:none;padding:0px 0px 0px 0px' id=templateBody><div align=center><table border='0' cellspacing='0' cellpadding='0' width='100%' style='width:100.0%;border-collapse:collapse;padding-alt:0px 0px 0px 0px;max-width:700px'>  <tr><td valign='top' style='padding:0px 0px 0px 0px;max-width:700px; border-top:solid #F2F2F2 1.5pt;'><div align='center'><table border='0' cellspacing='0' cellpadding='0' width='700' style='width:525.0pt;border-collapse:collapse;padding:0px 0px 0px 0px;max-width:700px'>  <tr><td width='700' valign='top' style='width:525.0pt;padding:0px 0px 0px 0px'><div align='center'><table border='0' cellspacing='0' cellpadding='0' width='100%' style='width:100.0%;border-collapse:collapse;padding:0px 0px 0px 0px'>  <tr><td width='30' valign='top' style='width:22.5pt;padding:0px 0px 0px 0px'></td><td width='100%' valign=top style='width:100.0%;padding:0px 52.5px 0px 30.0px' id='bodyContainer'>{1}</td>  </tr></table>  </div></td>  </tr></table>  </div></td>  </tr></table>  </div></td></tr><tr><td valign='top' style='padding:0px 22.5px 0px 22.5px' id='templateFooter'><div align='center'><table border='0' cellspacing='0' cellpadding='0' width='640' style='width:480.0pt;border-collapse:collapse;padding:0px 0px 0px 0px;max-width:640px'>  <tr><td width='640' valign='top' style='width:480.0px;padding:0px 0px 0px 0px;max-width:640px' id='footerContent'><div align='center'><table border='0' cellspacing='0' cellpadding='0' width='100%' style='width:100.0%;border-collapse:collapse;padding:0px 0px 0px 0px;max-width:640px'>  <tr><td valign='top' style='border:none;border-top:solid #F2F2F2 1.5pt;padding:30.0px 0px 15.0px 0px'><p align='center' style='margin:0px;margin-bottom:.0001pt;text-align:center;line-height:18.0pt;'> <span style='font-size:9.0pt;font-family:Helvetica Neue;color:#484848'>© 2017 MKcreativo, Todos los derechosreservados.<br>Huerfanos 903 • Santiago • Chile<br>Telefono: +(56) 226 641 975 / +(56) 226 648 472 / +(56) 226 641 169</span></p></td>  </tr></table>  </div></td>  </tr></table>  </div></td></tr></table></div></td></tr></table></div>";
            string sbx_Contenido_final_html = string.Format(body, "<img alt=\"MIPNET\" src=\"cid:imagenTop\" width=\"150\" height=\"50\" border=\"0\" />", stx_Contenido_html);
            string sbx_Contenido = string.Format(body, "<img alt='MIPNET' src='http://localhost:13800/Content/assets/images/logomailcreativo.png' width='150' height='50' border='0' />", stx_Contenido_html);

            AlternateView plainView = AlternateView.CreateAlternateViewFromString(Stx_Contenido_Text, Encoding.UTF8, MediaTypeNames.Text.Plain);
            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(sbx_Contenido_final_html, Encoding.UTF8, MediaTypeNames.Text.Html);

            String Server_ruta = System.Web.HttpContext.Current.Server.MapPath("~");
            String top = System.Web.HttpContext.Current.Server.MapPath("~") + "Content\\assets\\images\\logomailcreativo.png";
            LinkedResource imgTop = new LinkedResource(top, MediaTypeNames.Image.Jpeg);
            imgTop.ContentId = "imagenTop";
            htmlView.LinkedResources.Add(imgTop);
            
            message.AlternateViews.Add(htmlView);
            message.AlternateViews.Add(plainView);
            message.Body = htmlView.ToString();
            message.From = new System.Net.Mail.MailAddress(System.Configuration.ConfigurationManager.AppSettings["mail:servicioalclientes"].ToString(), System.Configuration.ConfigurationManager.AppSettings["mail:servicioalclientesremitente"].ToString());

            int respuestaenvio = SendMail(message, Llave_usuario, tiponotificacion);

            ntf01_notificaciones ntf01_notificaciones = new Models.ntf01_notificaciones();

            foreach (var datos in message.To)
            {
                stx_To = stx_To + datos.ToString() + ", ";
            }

            ntf01_notificaciones.ntf02_fechaenvio = DateTime.Now;
            ntf01_notificaciones.ntf01_asunto = message.Subject;
            ntf01_notificaciones.ntf01_contenido = sbx_Contenido;
            ntf01_notificaciones.ntf01_destinatario = stx_To.ToString();
            ntf01_notificaciones.ntf01_remitente = message.From.ToString();
            ntf01_notificaciones.UserId = Llave_usuario;
            ntf01_notificaciones.ntf02_id = tiponotificacion;
            ntf01_notificaciones.ntf01_estado = (int)respuestaenvio;

            db.ntf01_notificaciones.Add(ntf01_notificaciones);
            db.SaveChanges();

            if (respuestaenvio == 1)
            {
                Respuesta = "Envio realizado con Exito";
            }
            
            return Respuesta;
        }

        private static int SendMail(MailMessage message, String llave_usuario, decimal tiponotificacion)
        {
            int estado = 0;
            var smtp = new System.Net.Mail.SmtpClient
            {
                Host = "mailcreativo.cl",
                Port = 25,
                Credentials = new System.Net.NetworkCredential("servicioalcliente@mailcreativo.cl", "9Pocg6#5"),
                EnableSsl = false
            };
            smtp.Timeout = 20000;
            try
            {
                smtp.Send(message);
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