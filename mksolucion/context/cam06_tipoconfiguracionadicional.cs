namespace mksolucion.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class cam06_tipoconfiguracionadicional
    {
        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal cam06_id { get; set; }

        [StringLength(500)]
        public string cam06_descripcion { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? cam06_tipoelemento { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? cam06_estado { get; set; }

        public DateTime? cam06_fechacreacion { get; set; }

        public DateTime? cam06_ultimaactualizacion { get; set; }

        public virtual cam05_configuracionadiocional cam05_configuracionadiocional { get; set; }
    }
}
