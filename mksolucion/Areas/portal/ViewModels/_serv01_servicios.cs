using System;
using System.ComponentModel.DataAnnotations;

namespace mksolucion.Models
{
    public class _serv01_servicios
    {

        [Display(Name = "Servicio")]
        public decimal ser01_id { get; set; }

        [Display(Name = "Cuenta de Usuario")]
        public decimal? cnt01_id { get; set; }

        [Display(Name = "Plan")]
        public decimal? pnl01_id { get; set; }

        [Display(Name = "Estado")]
        public int? ser01_estado { get; set; }

        [Display(Name = "Fecha creación")]
        public DateTime? ser01_fechacreacion { get; set; }

        [Display(Name = "Fecha Actualización")]
        public DateTime? ser01_ultimaactualizacion { get; set; }

        [UIHint("cuentaCliente")]
        public _cnt01_cuenta _cuentaCliente
        {
            get;
            set;
        }

        [UIHint("Planes")]
        public _pln01_planes _planes
        {
            get;
            set;
        }

    }
}