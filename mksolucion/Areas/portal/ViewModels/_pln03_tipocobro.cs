using System;
using System.ComponentModel.DataAnnotations;

namespace mksolucion.Models
{
    public class _pln03_tipocobro
    {
        [Key]
        public decimal? pln03_id { get; set; }

        [Display(Name = "Tipo Cobro de Planes")]
        public string pln03_nombre { get; set; }

        [Display(Name = "Descripción")]
        public string pln03_descripcion { get; set; }

        [Display(Name = "Estado")]
        public int? pln03_estado { get; set; }

        [Display(Name = "Fecha creación")]
        public DateTime? pln03_fechacreacion { get; set; }

        [Display(Name = "Fecha Actualización")]
        public DateTime? pln03_ultimaactualizacion { get; set; }
    }
}