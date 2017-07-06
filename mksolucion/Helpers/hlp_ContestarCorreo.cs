using mksolucion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Helpers.Helpers
{
    public static class hlp_FowardEmail
    {

        public static MvcHtmlString FowardEmail(object IDticket) 
        {
            var result = "";
            try
            {

                int id = Convert.ToInt32(IDticket);
                

                ModelMK db = new ModelMK();

                var query = from con01 in db.con01_contacto
                            join con02 in db.con02_tipocontacto on con01.con02_id equals con02.con02_id
                            join con03 in db.con03_importancia on con01.con03_id equals con03.con03_id
                            join con05 in db.con05_EstadoMensaje on con01.con05_id equals con05.con05_id
                            where (con05.con05_estado == 1) && (con02.con02_estado == 1) && (con03.con03_estado == 1)
                            && (con01.con01_id_padre == id)
                            select new
                            {
                                id = con01.con01_id,
                                asunto = con01.con01_asunto,
                                Mensaje = con01.con01_mensaje,
                                ultimaactualizacion = con01.con01_ultimaactualizacion,
                                departamento = con02.con02_nombre,
                                importancia = con03.con03_nombre,
                                estado = con05.con05_nombre,
                                nombre = con01.con01_nombre,
                                fecha = con01.con01_fechacreacion,
                                padre = con01.con01_id_padre


                            };

                if (query.Count() > 0)
                {
                    var datos = query.ToList().Distinct();
                    foreach (var Row in datos)
                    {

                        result = "<div class=\"panel-heading small panel-middle\"><div class=\"row\"><div class=\"col-md-6\"><span class=\"font-blue\"><span class=\"font-strong\">" + Row.nombre.ToString() + "</span>" +
                        "</span></div><div class=\"col-md-6 text-right\"><span class=\"font-blue\"><span class=\"font-strong\">"+ Row.fecha.ToString() + "</span></span></div></div></div><div class=\"panel-body small panel-middle\">" +
                        "<div>"+System.Net.WebUtility.HtmlDecode(Row.Mensaje.ToString())+"</div></div>" + result ;

                        if (Row.padre.ToString() != "")
                        {
                            result =  FowardEmail(Row.id.ToString())+ result;
                        }
                        else
                        {
                            result = result + "<input type=\"hidden\" id=\"hdd_llavepadre\" name=\"hdd_llavepadre\" value=\"" + Row.id.ToString() + "\">";

                        }
                        
                    }
                }
                else
                {
                    result =  "<input type=\"hidden\" id=\"hdd_llavepadre\" name=\"hdd_llavepadre\" value=\"" + IDticket + "\">" + result;
                }
            }
            catch (Exception e)
            {
 
            }

            return new MvcHtmlString(result);
        }

    }
}