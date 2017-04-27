using System;
using System.ComponentModel.DataAnnotations;

namespace mksolucion.Models
{
    public class _cam02_tipocampana
    {
        [Key]
        public decimal cam02_id { get; set; }

        [Display(Name = "Nombre Tipo Campaña")]
        public string cam02_nombre { get; set; }

        [Display(Name = "Descripción")]
        public string cam02_descripcion { get; set; }

        [Display(Name = "Estado")]
        public int? cam02_estado { get; set; }

        public DateTime? cam02_fechacreacion { get; set; }

        public DateTime? cam02_ultimaactualizacion { get; set; }
    }
}