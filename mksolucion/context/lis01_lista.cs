namespace mksolucion.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class lis01_lista
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public lis01_lista()
        {
            crr05_interesCorreo = new HashSet<crr05_interesCorreo>();
            crr07_correoOrganizacion = new HashSet<crr07_correoOrganizacion>();
            cam01_campana = new HashSet<cam01_campana>();
            crr01_correos = new HashSet<crr01_correos>();
        }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal lis01_id { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? lis04_id { get; set; }

        [StringLength(250)]
        public string lis01_nombre { get; set; }

        public string lis01_descripcion { get; set; }

        public int? lis01_estado { get; set; }

        public DateTime? lis01_fechacreacion { get; set; }

        public DateTime? lis01_ultimaactualizacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<crr05_interesCorreo> crr05_interesCorreo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<crr07_correoOrganizacion> crr07_correoOrganizacion { get; set; }

        public virtual gen01_estados gen01_estados { get; set; }

        public virtual lis04_tipolista lis04_tipolista { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cam01_campana> cam01_campana { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<crr01_correos> crr01_correos { get; set; }
    }
}
