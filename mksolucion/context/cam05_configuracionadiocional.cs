namespace mksolucion.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class cam05_configuracionadiocional
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public cam05_configuracionadiocional()
        {
            cam01_campana = new HashSet<cam01_campana>();
        }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal cam05_id { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? cam06_id { get; set; }

        [StringLength(500)]
        public string cam05_nombre { get; set; }

        [StringLength(500)]
        public string cam05_descripcion { get; set; }

        public string cam05_valor { get; set; }

        public int? cam05_estado { get; set; }

        public DateTime? cam05_fechacreacion { get; set; }

        public virtual cam06_tipoconfiguracionadicional cam06_tipoconfiguracionadicional { get; set; }

        public virtual gen01_estados gen01_estados { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cam01_campana> cam01_campana { get; set; }
    }
}
