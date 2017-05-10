using System;
using System.ComponentModel.DataAnnotations;

namespace mksolucion.Models
{
    public class _ntf02_tiponotificacioncorreo
    {
        [Key]
        public decimal? ntf02_id { get; set; }

        [Display(Name = "Tipo Notificación Coreo")]
        public string ntf02_nombre { get; set; }

        [Display(Name = "Descripción")]
        public string ntf02_descripcion { get; set; }

        [Display(Name = "Estado")]
        public int? ntf02_estado { get; set; }

        [Display(Name = "Fecha creación")]
        public DateTime? ntf02_fechacreacion { get; set; }

        [Display(Name = "Fecha Actualización")]
        public DateTime? ntf02_ultimaactualizacion { get; set; }
    }
}