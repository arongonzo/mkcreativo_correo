using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mksolucion.Models;

namespace mksolucion.Areas.completarinformacion.Controllers
{
    public class InformacionUsuarioController : Controller
    {
        // GET: completarinformacion/InformacionUsuario
        public ActionResult Index()
        {
            return View();
        }

        // POST: configuracion/tipoplan/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(FormCollection values)
        {
            if (ModelState.IsValid)
            {
                ModelMK db = new ModelMK();
                string llave_usario = Session["UserId"].ToString();


                decimal stx_tipo = 0;
                var query = from tpcnt in db.cnt02_tipocuenta
                            where tpcnt.cnt02_nombre == "Invitados"
                            select new
                            {
                                cnt02_id = tpcnt.cnt02_id,
                                cnt02_nombre = tpcnt.cnt02_nombre
                            };
                if (query.Count() > 0)
                {
                    var datos = query.ToList();
                    foreach (var Row in datos)
                    {
                        stx_tipo = Row.cnt02_id;
                    }
                }
                else 
                {
                    cnt02_tipocuenta cnt02_tipocuenta = new cnt02_tipocuenta();
                    cnt02_tipocuenta.cnt02_nombre = "Invitados";
                    cnt02_tipocuenta.cnt02_descripcion = "solo para usuarios que se han inscritos en el sistema";
                    cnt02_tipocuenta.cnt02_estado = 1;
                    cnt02_tipocuenta.cnt02_fechacreacion = DateTime.Now;
                    cnt02_tipocuenta.cnt02_ultimaactualizacion = DateTime.Now;
                    db.cnt02_tipocuenta.Add(cnt02_tipocuenta);
                    db.SaveChanges();
                    stx_tipo = cnt02_tipocuenta.cnt02_id;
                }

                decimal stx_cliente = 0;
                var queryCliente = from usr in db.AspNetUsers
                                   join cntusr in db.cnt03_cuenta_usuario on usr.Id equals cntusr.UserId
                                   join cnt in db.cnt01_cuenta on cntusr.cnt01_id equals cnt.cnt01_id
                                   
                            select new
                            {
                                cnt01_id = cnt.cnt01_id
                            };
                if (queryCliente.Count() > 0)
                {
                    var datoscliente = queryCliente.ToList();
                    foreach (var RowC in datoscliente)
                    {
                        stx_cliente = RowC.cnt01_id;
                    }
                }
                else
                {
                    cnt01_cuenta cnt01_cuenta = new cnt01_cuenta();
                    cnt01_cuenta.cnt01_nombre = values["pln01_nombre"];
                    cnt01_cuenta.cnt02_id = stx_tipo;
                    cnt01_cuenta.cnt01_estado = 1;
                    cnt01_cuenta.cnt01_fechacreacion = DateTime.Now;
                    cnt01_cuenta.cnt01_ultimaactualizacion = DateTime.Now;

                    db.cnt01_cuenta.Add(cnt01_cuenta);
                    db.SaveChanges();
                    stx_cliente = cnt01_cuenta.cnt01_id;

                    cnt03_cuenta_usuario cnt03_cuenta_usuario =  new cnt03_cuenta_usuario()
                    cnt03_cuenta_usuario.cnt01_id = stx_cliente;
                    cnt03_cuenta_usuario.UserId = llave_usario;

                    db.cnt03_cuenta_usuario.Add(cnt03_cuenta_usuario);
                    db.SaveChanges();
                }



            }

            return View();
        }
    }
}