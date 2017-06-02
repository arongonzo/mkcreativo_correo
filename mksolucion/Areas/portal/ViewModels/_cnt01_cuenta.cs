using System;
using System.ComponentModel.DataAnnotations;

namespace mksolucion.Models
{
    public class _cnt01_cuenta
    {
        [Key]
        [Display(Name = "Cuenta Cliente")]
        public decimal cnt01_id { get; set; }

        [Display(Name = "Tipo Cuenta")]
        public decimal? cnt02_id { get; set; }

        [Display(Name = "Cuenta Cliente")]
        public string cnt01_nombre { get; set; }

        [Display(Name = "Estado")]
        public int? cnt01_estado { get; set; }

        [Display(Name = "Fecha creación")]
        public DateTime? cnt01_fechacreacion { get; set; }

        [Display(Name = "Fecha Actualización")]
        public DateTime? cnt01_ultimaactualizacion { get; set; }

        [UIHint("TipoCuenta")]
        public _cnt02_tipocuenta _tipocuenta
        {
            get;
            set;
        }

    }
}