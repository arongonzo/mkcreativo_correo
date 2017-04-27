namespace mksolucion.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class cam07_datoSociales
    {
        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal cam01_id { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "numeric")]
        public decimal red01_id { get; set; }

        [StringLength(500)]
        public string cam07_url { get; set; }

        [StringLength(500)]
        public string cam07_usuario { get; set; }

        [StringLength(500)]
        public string cam07_pass { get; set; }

        public int? cam07_estado { get; set; }

        public DateTime? cam07_fechacreacion { get; set; }

        public DateTime? cam07_ultimaactualizacion { get; set; }

        public virtual cam01_campana cam01_campana { get; set; }
    }
}
