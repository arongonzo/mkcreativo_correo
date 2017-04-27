namespace mksolucion.Models
{
    using mksolucion.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class cam01_campana
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public cam01_campana()
        {
            cam03_detallecampana = new HashSet<cam03_detallecampana>();
            cam07_datoSociales = new HashSet<cam07_datoSociales>();
            cam05_configuracionadiocional = new HashSet<cam05_configuracionadiocional>();
            lis01_lista = new HashSet<lis01_lista>();
        }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal cam01_id { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? cnt01_id { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? cam02_id { get; set; }

        [StringLength(500)]
        public string cam01_nombre { get; set; }

        public string cam01_descripcion { get; set; }

        public int? cam01_estado { get; set; }

        public DateTime? cam01_fechacreacion { get; set; }

        public DateTime? cam01_ultimaactualizacion { get; set; }

        public virtual cam02_tipocampana cam02_tipocampana { get; set; }

        public virtual cnt01_cuenta cnt01_cuenta { get; set; }

        public virtual gen01_estados gen01_estados { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cam03_detallecampana> cam03_detallecampana { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cam07_datoSociales> cam07_datoSociales { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cam05_configuracionadiocional> cam05_configuracionadiocional { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<lis01_lista> lis01_lista { get; set; }
    }
}
