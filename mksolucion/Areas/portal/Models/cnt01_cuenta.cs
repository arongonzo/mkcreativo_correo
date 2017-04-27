namespace mksolucion.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class cnt01_cuenta
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public cnt01_cuenta()
        {
            cam01_campana = new HashSet<cam01_campana>();

            cnt03_cuenta_usuario = new HashSet<cnt03_cuenta_usuario>();

            serv01_servicios = new HashSet<serv01_servicios>();
        }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal cnt01_id { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? cnt02_id { get; set; }

        [StringLength(500)]
        public string cnt01_nombre { get; set; }

        public int? cnt01_estado { get; set; }

        public DateTime? cnt01_fechacreacion { get; set; }

        public DateTime? cnt01_ultimaactualizacion { get; set; }

        
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cam01_campana> cam01_campana { get; set; }

        public virtual cnt02_tipocuenta cnt02_tipocuenta { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cnt03_cuenta_usuario> cnt03_cuenta_usuario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<serv01_servicios> serv01_servicios { get; set; }
    }
}
