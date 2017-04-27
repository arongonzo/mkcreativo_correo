namespace mksolucion.Models
{
    using mksolucion.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class pln04_tipoconfiguracion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public pln04_tipoconfiguracion()
        {
            pln01_planes = new HashSet<pln01_planes>();
        }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal pln04_id { get; set; }

        [StringLength(500)]
        public string pln04_nombre { get; set; }

        public string pln04_descripcion { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? pln04_valor { get; set; }

        [StringLength(50)]
        public string pln04_operador { get; set; }

        [StringLength(50)]
        public string pln04_orden { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? pln04_padre { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? pln04_estado { get; set; }

        public DateTime? pln04_fechacreacion { get; set; }

        public DateTime? pln04_ultimaactualizacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<pln01_planes> pln01_planes { get; set; }
    }
}
