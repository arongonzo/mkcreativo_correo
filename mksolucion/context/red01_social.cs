namespace mksolucion.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class red01_social
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public red01_social()
        {
            red02_datosContacto = new HashSet<red02_datosContacto>();
        }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal red01_id { get; set; }

        [StringLength(500)]
        public string red01_nombre { get; set; }

        public string red01_descripcion { get; set; }

        public int? red01_activo { get; set; }

        public DateTime? red01_fechacreacion { get; set; }

        public DateTime? red01_fechaactualizacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<red02_datosContacto> red02_datosContacto { get; set; }
    }
}
