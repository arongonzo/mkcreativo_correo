namespace mksolucion.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using mksolucion.Models;

    public partial class pln01_planes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public pln01_planes()
        {
            serv01_servicios = new HashSet<serv01_servicios>();
        }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal pln01_id { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? pln02_id { get; set; }

        [StringLength(500)]
        public string pln01_nombre { get; set; }

        public string pln01_detalle { get; set; }

        public string pln01_html { get; set; }

        public int? pln01_activo { get; set; }

        public DateTime? pln01_fechacreacion { get; set; }

        public DateTime? pln01_ultimaactualizacion { get; set; }

        public virtual gen01_estados gen01_estados { get; set; }

        public virtual pln02_tipoplan pln02_tipoplan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<serv01_servicios> serv01_servicios { get; set; }

        

    }
}
