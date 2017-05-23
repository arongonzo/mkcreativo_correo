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

        [ScaffoldColumn(false)]
        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Plan")]
        public decimal pln01_id { get; set; }

        [Display(Name = "Tipo de Plan")]
        [Column(TypeName = "numeric")]
        public decimal? pln02_id { get; set; }

        [Display(Name = "Nombre del Plan")]
        [StringLength(500, ErrorMessage = "El registro {0} debe estar entre {2} y {1} caracteres", MinimumLength = 3)]
        [Required(ErrorMessage = "Debe ingresar un valor para {0}")]
        public string pln01_nombre { get; set; }

        [Display(Name = "Detalle")]
        public string pln01_detalle { get; set; }

        [Display(Name = "Detalle Html")]
        public string pln01_html { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Estado")]
        public int? pln01_activo { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Fecha creación")]
        [DisplayFormat(DataFormatString = "{0:dd-mm-yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? pln01_fechacreacion { get; set; }

        [Display(Name = "Fecha Actualización")]
        [DisplayFormat(DataFormatString = "{0:dd-mm-yyyy}", ApplyFormatInEditMode = true)]
        [ScaffoldColumn(false)]
        [DataType(DataType.Date)]
        public DateTime? pln01_ultimaactualizacion { get; set; }

        public virtual gen01_estados gen01_estados { get; set; }

        public virtual pln02_tipoplan pln02_tipoplan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<serv01_servicios> serv01_servicios { get; set; }

        

    }
}
