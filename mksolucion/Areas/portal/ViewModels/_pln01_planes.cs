using System;
using System.ComponentModel.DataAnnotations;

namespace mksolucion.Models
{
    public class _pln01_planes
    {
        [Key]
        [Display(Name = "Planes")]
        public decimal pln01_id { get; set; }

        [Display(Name = "Tipo de Plan")]
        public decimal? pln02_id { get; set; }

        [Display(Name = "Nombre del Plan")]
        public string pln01_nombre { get; set; }

        [Display(Name = "Descripción")]
        public string pln01_detalle { get; set; }

        [Display(Name = "Descripción HTML")]
        public string pln01_html { get; set; }

        [Display(Name = "Estado")]
        public int? pln01_activo { get; set; }

        [Display(Name = "Fecha creación")]
        public DateTime? pln01_fechacreacion { get; set; }

        [Display(Name = "Fecha Actualización")]
        public DateTime? pln01_ultimaactualizacion { get; set; }

        [UIHint("TipoPlan")]
        public _pln02_tipoplan _TipoPlan
        {
            get;
            set;
        }

    }
}