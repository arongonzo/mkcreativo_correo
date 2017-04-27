using System;
using System.ComponentModel.DataAnnotations;

namespace mksolucion.Models
{
    public class _crr03_areasegmento
    {
        [ScaffoldColumn(false)]
        [Key]
        public decimal crr03_id { get; set; }

        [Display(Name = "Area o Segmento")]
        public string crr03_nombre { get; set; }

        [Display(Name = "Descripción")]
        public string crr03_descripcion { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Estado")]
        public int? crr03_estado { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Fecha creación")]
        public DateTime? crr03_fechacreacion { get; set; }

        [Display(Name = "Fecha Actualización")]
        [ScaffoldColumn(false)]
        public DateTime? crr03_ultimaactualizacion { get; set; }
    }
}