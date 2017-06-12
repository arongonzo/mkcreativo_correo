using System;
using System.ComponentModel.DataAnnotations;

namespace mksolucion.Models
{
    public class _con03_importancia
    {
        [Key]
        [Display(Name = "Importancia")]
        public decimal con03_id { get; set; }

        [Display(Name = "Importancia")]
        public string con03_nombre { get; set; }

        [Display(Name = "Descripción")]
        public string con03_descripcion { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Estado")]
        public int? con03_estado { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Fecha creación")]
        public DateTime? con03_fechacreacion { get; set; }

        [Display(Name = "Fecha Actualización")]
        [ScaffoldColumn(false)]
        public DateTime? con03_ultimaactualizacion { get; set; }

    }
}