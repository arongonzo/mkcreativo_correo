using System;
using System.ComponentModel.DataAnnotations;

namespace mksolucion.Models
{
    public class _crr02_tipoclasificacion
    {
        [Key]
        public decimal crr02_id { get; set; }

        [Display(Name = "Clasificación de correo")]
        public string crr02_nombre { get; set; }

        [Display(Name = "Descripción")]
        public string crr02_descripcion { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Estado")]
        public int? crr02_estado { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Fecha creación")]
        public DateTime? crr02_fechacreacion { get; set; }

        [Display(Name = "Fecha Actualización")]
        [ScaffoldColumn(false)]
        public DateTime? crr02_ultimaactualizacion { get; set; }

    }
}