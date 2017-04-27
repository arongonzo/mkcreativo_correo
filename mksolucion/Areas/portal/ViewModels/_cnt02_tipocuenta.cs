using System;
using System.ComponentModel.DataAnnotations;

namespace mksolucion.Models
{
    public class _cnt02_tipocuenta
    {
        [ScaffoldColumn(false)]
        [Key]
        public decimal cnt02_id { get; set; }

        [Display(Name = "Tipo Cuenta")]
        public string cnt02_nombre { get; set; }

        [Display(Name = "Descripción")]
        public string cnt02_descripcion { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Estado")]
        public int? cnt02_estado { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Fecha creación")]
        public DateTime? cnt02_fechacreacion { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Fecha Actualización")]
        public DateTime? cnt02_ultimaactualizacion { get; set; }

    }
}