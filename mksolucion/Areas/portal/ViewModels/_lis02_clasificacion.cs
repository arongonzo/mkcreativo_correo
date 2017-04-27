using System;
using System.ComponentModel.DataAnnotations;

namespace mksolucion.Models
{
    public class _lis02_clasificacion
    {
        [Key]
        public decimal? lis02_id { get; set; }

        [Display(Name = "Tipo Lista")]
        
        public string lis02_nombre { get; set; }

        [Display(Name = "Descripción")]
        public string lis02_descripcion { get; set; }

        [Display(Name = "Estado")]
        public int? lis02_estado { get; set; }

        [Display(Name = "Fecha creación")]
         public DateTime? lis02_fechacreacion { get; set; }

        [Display(Name = "Fecha Actualización")]
        public DateTime? lis02_ultimaactualizacion { get; set; }
    }
}