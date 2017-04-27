namespace mksolucion.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class cam03_detallecampana
    {
        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal cam03_id { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? cam01_id { get; set; }

        [StringLength(500)]
        public string cam03_emailDe { get; set; }

        [StringLength(500)]
        public string cam03_from { get; set; }

        [StringLength(500)]
        public string cam03_direccion { get; set; }

        [StringLength(500)]
        public string cam03_ciudad { get; set; }

        [StringLength(500)]
        public string cam03_telefono { get; set; }

        [StringLength(500)]
        public string cam03_telefono2 { get; set; }

        [StringLength(500)]
        public string cam03_celular1 { get; set; }

        [StringLength(500)]
        public string cam03_celular2 { get; set; }

        [StringLength(500)]
        public string cam03_codigoZip { get; set; }

        public int? cam03_estado { get; set; }

        public DateTime? cam03_fechacreacion { get; set; }

        public DateTime? cam03_ultimaactualizacion { get; set; }

        public virtual cam01_campana cam01_campana { get; set; }

        public virtual gen01_estados gen01_estados { get; set; }
    }
}
