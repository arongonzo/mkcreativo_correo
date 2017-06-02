namespace mksolucion.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class usr01_infopersonal
    {
        [ScaffoldColumn(false)]
        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal? usr01_id { get; set; }


        public string UserId { get; set; }

        [Display(Name = "Nombre")]
        [StringLength(500, ErrorMessage = "El registro {0} debe estar entre {2} y {1} caracteres", MinimumLength = 3)]
        [Required(ErrorMessage = "Debe ingresar un valor para {0}")]
        public string usr01_nombre { get; set; }

        [Display(Name = "Apellido")]
        [StringLength(500, ErrorMessage = "El registro {0} debe estar entre {2} y {1} caracteres", MinimumLength = 3)]
        [Required(ErrorMessage = "Debe ingresar un valor para {0}")]
        public string usr01_apellido { get; set; }

        [Display(Name = "Direccion 1")]
        [StringLength(500, ErrorMessage = "El registro {0} debe estar entre {2} y {1} caracteres", MinimumLength = 3)]
        [Required(ErrorMessage = "Debe ingresar un valor para {0}")]
        public string usr01_direccion1 { get; set; }

        [Display(Name = "Direccion 2")]
        public string usr01_direccion2 { get; set; }

        [Display(Name = "Ciudad")]
        public string usr01_ciudad { get; set; }

        [Display(Name = "Estado / Proviencia / Región")]
        public string usr01_region { get; set; }

        [Display(Name = "zip / codigo postal")]
        public string usr01_codigopostal { get; set; }

        [Display(Name = "Telefono Principal")]
        public string usr01_Telefono { get; set; }

        [Display(Name = "Telefono Secundario")]
        public string usr01_Telefono2 { get; set; }

        [Display(Name = "Celular Principal")]
        public string usr01_Celular { get; set; }

        [Display(Name = "Celular Secundario")]
        public string usr01_Celular2 { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Estado")]
        public int? usr01_estado { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Fecha creación")]
        [DisplayFormat(DataFormatString = "{0:dd-mm-yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? usr01_fechacreacion { get; set; }

        [Display(Name = "Fecha Actualización")]
        [DisplayFormat(DataFormatString = "{0:dd-mm-yyyy}", ApplyFormatInEditMode = true)]
        [ScaffoldColumn(false)]
        [DataType(DataType.Date)]
        public DateTime? usr01_ultimaactualizacion { get; set; }

        public virtual gen01_estados gen01_estados { get; set; }

        public virtual AspNetUsers AspNetUsers { get; set; }

        

    }
}