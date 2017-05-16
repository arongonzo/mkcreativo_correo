using System;
using System.ComponentModel.DataAnnotations;

namespace mksolucion.Models
{
    public class _coninf01_pasocominfo
    {
        [Key]
        public decimal coninf01_id { get; set; }

        [Display(Name = "Pasos Completar Información")]
        public string coninf01_nombre { get; set; }

        [Display(Name = "Estado")]
        public int? pln01_estado { get; set; }

        [Display(Name = "Fecha creación")]
        public DateTime? pln01_fechacreacion { get; set; }

        [Display(Name = "Fecha Actualización")]
        public DateTime? pln01_ultimaactualizacion { get; set; }
    }
}