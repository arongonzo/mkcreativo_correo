using System;
using System;
using System.ComponentModel.DataAnnotations;

namespace mksolucion.Models
{
    public class _gen01_estados
    {
        public int gen01_id { get; set; }

        [Display(Name = "Estado Activación")]
        public string gen01_nombre { get; set; }

        [Display(Name = "Descripción")]
        public string gen01_descripcion { get; set; }

        public DateTime? gen01_fechacreacion { get; set; }
    }
}