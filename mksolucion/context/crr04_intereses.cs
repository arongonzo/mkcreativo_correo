namespace mksolucion.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class crr04_intereses
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public crr04_intereses()
        {
            crr05_interesCorreo = new HashSet<crr05_interesCorreo>();
        }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal crr04_id { get; set; }

        [StringLength(500)]
        public string crr04_nombre { get; set; }

        public string crr04_descripcion { get; set; }

        public int? crr04_estado { get; set; }

        public DateTime? crr04_fechacreacion { get; set; }

        public DateTime? crr04_ultimaactualizacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<crr05_interesCorreo> crr05_interesCorreo { get; set; }

        public virtual gen01_estados gen01_estados { get; set; }
    }
}
