using System;
using System.ComponentModel.DataAnnotations;

namespace mksolucion.Models
{
    public class _crr08_estadoCorreo
    {
        [ScaffoldColumn(false)]
        [Key]
        public int crr08_id { get; set; }

        [Display(Name = "Estado de correos")]
        public string crr08_nombre { get; set; }

        [Display(Name = "Descripción")]
        public string crr08_descripcion { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Estado")]
        public int? crr08_estado { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Fecha creación")]
        public DateTime? crr08_fechacreacion { get; set; }

        [Display(Name = "Fecha Actualización")]
        [ScaffoldColumn(false)]
        public DateTime? crr08_ultimaactualizacion { get; set; }

    }
}