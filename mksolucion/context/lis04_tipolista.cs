namespace mksolucion.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class lis04_tipolista
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public lis04_tipolista()
        {
            lis01_lista = new HashSet<lis01_lista>();
        }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal lis04_id { get; set; }

        [Required]
        [StringLength(500)]
        public string lis04_nombre { get; set; }

        public string lis04_descripcion { get; set; }

        public int lis04_estado { get; set; }

        public DateTime? lis04_fechacreacion { get; set; }

        public DateTime? lis04_fechaactualizacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<lis01_lista> lis01_lista { get; set; }
    }
}
