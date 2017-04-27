namespace mksolucion.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class loc01_pais
    {
        [Key]
        public int loc01_id { get; set; }

        [Required]
        [StringLength(250)]
        public string loc01_nombre { get; set; }

        public int loc01_activo { get; set; }

        public DateTime? loc01_fechacreacion { get; set; }
    }
}
