using System;
using System.ComponentModel.DataAnnotations;

namespace mksolucion.Models
{
    public class _pnl02_tipoplan
    {
        [Key]
        public decimal pln02_id { get; set; }

        [Display(Name="Nombre")]
        public string pln02_nombre { get; set; }

        [Display(Name="Descripción")]
        public string pln02_descripcion { get; set; }

        public int? pln02_estado { get; set; }

        public DateTime? pln02_ultimaactualizacion { get; set; }

        public DateTime? pln02_fechacreacion { get; set; }
    }
}