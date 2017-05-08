using System;
using System.ComponentModel.DataAnnotations;


namespace mksolucion.Models
{
    public class _crr04_intereses
    {
        [Key]
        public decimal crr04_id { get; set; }

        [Display(Name = "Interes")]
        public string crr04_nombre { get; set; }

        [Display(Name = "Descripción")]
        public string crr04_descripcion { get; set; }

        [Display(Name = "Estado")]
        public int? crr04_estado { get; set; }

        [Display(Name = "Fecha creación")]
        public DateTime? crr04_fechacreacion { get; set; }

        [Display(Name = "Fecha Actualización")]
        public DateTime? crr04_ultimaactualizacion { get; set; }

    }
}