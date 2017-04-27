namespace mksolucion.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class crr06_organizacion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public crr06_organizacion()
        {
            crr07_correoOrganizacion = new HashSet<crr07_correoOrganizacion>();
        }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal crr06_id { get; set; }

        [StringLength(500)]
        public string crr06_nombre { get; set; }

        [StringLength(500)]
        public string crr06_sector { get; set; }

        public int? crr06_estado { get; set; }

        public DateTime? crr06_fechacreacion { get; set; }

        public DateTime? crr06_ultimaactualizacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<crr07_correoOrganizacion> crr07_correoOrganizacion { get; set; }

        public virtual gen01_estados gen01_estados { get; set; }
    }
}
