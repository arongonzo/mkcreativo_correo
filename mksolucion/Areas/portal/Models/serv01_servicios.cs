namespace mksolucion.Models
{
    using mksolucion.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class serv01_servicios
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public serv01_servicios()
        {
            con01_contacto = new HashSet<con01_contacto>();
        }

        [ScaffoldColumn(false)]
        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Servicio")]
        public decimal ser01_id { get; set; }

        [Display(Name = "Cuenta de Usuario")]
        [Column(TypeName = "numeric")]
        public decimal? cnt01_id { get; set; }

        [Display(Name = "Plan")]
        [Column(TypeName = "numeric")]
        public decimal? pnl01_id { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Estado")]
        public int? ser01_estado { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Fecha creación")]
        [DisplayFormat(DataFormatString = "{0:dd-mm-yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? ser01_fechacreacion { get; set; }

        [Display(Name = "Fecha Actualización")]
        [DisplayFormat(DataFormatString = "{0:dd-mm-yyyy}", ApplyFormatInEditMode = true)]
        [ScaffoldColumn(false)]
        [DataType(DataType.Date)]
        public DateTime? ser01_ultimaactualizacion { get; set; }

        public virtual cnt01_cuenta cnt01_cuenta { get; set; }

        public virtual pln01_planes pln01_planes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<con01_contacto> con01_contacto { get; set; }
    }
}
