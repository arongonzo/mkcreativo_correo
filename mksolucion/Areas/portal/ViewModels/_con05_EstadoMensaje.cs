using System;
using System.ComponentModel.DataAnnotations;

namespace mksolucion.Models
{
    public class _con05_EstadoMensaje
    {
        
        [Key]
        [Display(Name = "Estado Mensaje")]
        public decimal con05_id { get; set; }

        [Display(Name = "Estado Mensaje")]
        public string con05_nombre { get; set; }

        [Display(Name = "Descripción")]
        public string con05_descripcion { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Estado")]
        public int? con05_estado { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Fecha creación")]
        public DateTime? con05_fechacreacion { get; set; }

        [Display(Name = "Fecha Actualización")]
        [ScaffoldColumn(false)]
        public DateTime? con05_ultimaactualizacion { get; set; }

    }
}