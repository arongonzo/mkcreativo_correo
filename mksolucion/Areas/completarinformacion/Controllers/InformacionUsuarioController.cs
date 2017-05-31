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
                decimal llave_servicio = 0;
                decimal llave_cliente = 0;
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
                        llave_cliente = RowC.cnt01_id;
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
                    llave_cliente = cnt01_cuenta.cnt01_id;

                    cnt03_cuenta_usuario cnt03_cuenta_usuario = new cnt03_cuenta_usuario();
                    cnt03_cuenta_usuario.cnt01_id = llave_cliente;
                    cnt03_cuenta_usuario.UserId = llave_usario;

                    db.cnt03_cuenta_usuario.Add(cnt03_cuenta_usuario);
                    db.SaveChanges();
                }

                decimal llave_plan = 0, llave_tipoplan = 0, llave_cobro = 0;
                var queryplanes = from pln in db.pln01_planes
                                  join tppln in db.pln02_tipoplan on pln.pln02_id equals tppln.pln02_id
                                  join tpcbr in db.pln03_tipocobro on tppln.pln03_id equals tpcbr.pln03_id
                                  where tpcbr.pln03_nombre == "Gratis"
                                  || tppln.pln02_nombre == "Invitado"
                                  || pln.pln01_nombre == "Plan Inicial"

                            select new
                            {
                                pln01_id = pln.pln01_id,
                                pln02_id = tppln.pln02_id,
                                pln03_id = tpcbr.pln03_id
                            };
                if (queryplanes.Count() > 0)
                {
                    var datosplanes = queryplanes.ToList();
                    foreach (var Rowplanes in datosplanes)
                    {
                        llave_plan = (decimal)Rowplanes.pln01_id;
                        llave_tipoplan = (decimal)Rowplanes.pln02_id;
                        llave_cobro = (decimal)Rowplanes.pln03_id;
                    }
                }
                else
                {
                    var querycobro = from tpcbr in db.pln03_tipocobro 
                                      where tpcbr.pln03_nombre == "Gratis"
                                      
                                      select new
                                      {
                                          pln03_id = tpcbr.pln03_id
                                      };
                    if (querycobro.Count() > 0)
                    {
                        var datoscobro = querycobro.ToList();
                        foreach (var Rowcobro in datoscobro)
                        {
                            llave_cobro = (decimal)Rowcobro.pln03_id;
                        }
                    }
                    else
                    {
                        pln03_tipocobro pln03_tipocobro = new pln03_tipocobro();
                        pln03_tipocobro.pln03_nombre = "Gratis";
                        pln03_tipocobro.pln03_descripcion = "Sin cobro para el cliente";
                        pln03_tipocobro.pln03_estado = 1;
                        pln03_tipocobro.pln03_fechacreacion = DateTime.Now;
                        pln03_tipocobro.pln03_ultimaactualizacion = DateTime.Now;
                        db.pln03_tipocobro.Add(pln03_tipocobro);
                        db.SaveChanges();
                        llave_cobro = (decimal)pln03_tipocobro.pln03_id;
                    }


                    var querytipoplan = from tppln in db.pln02_tipoplan
                                        where tppln.pln02_nombre == "Invitado"

                                        select new
                                        {
                                            pln02_id = tppln.pln02_id
                                        };

                    if (querytipoplan.Count() > 0)
                    {
                        var datostipoplan = querytipoplan.ToList();
                        foreach (var Rowtipoplan in datostipoplan)
                        {
                            llave_tipoplan = (decimal)Rowtipoplan.pln02_id;
                        }
                    }
                    else
                    {
                        pln02_tipoplan pln02_tipoplan = new pln02_tipoplan();
                        pln02_tipoplan.pln02_nombre = "Invitado";
                        pln02_tipoplan.pln02_descripcion = "para usuarios que se han registrado en el sistema";
                        pln02_tipoplan.pln03_id = llave_cobro;
                        pln02_tipoplan.pln02_estado = 1;
                        pln02_tipoplan.pln02_fechacreacion = DateTime.Now;
                        pln02_tipoplan.pln02_ultimaactualizacion = DateTime.Now;
                        db.pln02_tipoplan.Add(pln02_tipoplan);
                        db.SaveChanges();
                        llave_tipoplan = (decimal)pln02_tipoplan.pln02_id;
                    }

                    var queryplan = from pln in db.pln01_planes
                                    where pln.pln01_nombre == "Plan Inicial"

                                        select new
                                        {
                                            pln01_id = pln.pln01_id
                                        };
                    if (queryplan.Count() > 0)
                    {
                        var datosplan = queryplan.ToList();
                        foreach (var Rowplan in datosplan)
                        {
                            llave_plan = (decimal)Rowplan.pln01_id;
                        }
                    }
                    else
                    {
                        pln01_planes pln01_planes = new pln01_planes();
                        pln01_planes.pln01_nombre = "Plan Inicial";
                        pln01_planes.pln01_detalle = "Plan inicial";
                        pln01_planes.pln02_id = (decimal)llave_tipoplan;
                        pln01_planes.pln01_activo = 1;
                        pln01_planes.pln01_fechacreacion = DateTime.Now;
                        pln01_planes.pln01_ultimaactualizacion = DateTime.Now;
                        db.pln01_planes.Add(pln01_planes);
                        db.SaveChanges();
                        llave_plan = (decimal)pln01_planes.pln01_id;
                    }

                }

                serv01_servicios serv01_servicios = new serv01_servicios();
                serv01_servicios.cnt01_id = llave_cliente;
                serv01_servicios.pnl01_id = llave_plan;
                serv01_servicios.ser01_estado = 1;
                serv01_servicios.ser01_fechacreacion = DateTime.Now;
                serv01_servicios.ser01_ultimaactualizacion = DateTime.Now;
                db.serv01_servicios.Add(serv01_servicios);
                db.SaveChanges();
                llave_servicio = (decimal)serv01_servicios.ser01_id;



            }

            return View();
        }
    }
}