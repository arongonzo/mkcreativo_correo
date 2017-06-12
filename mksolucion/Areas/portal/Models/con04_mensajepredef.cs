namespace mksolucion.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    public class con04_mensajepredef
    {
        [Display(Name = "Mensaje Predefinido")]
        [ScaffoldColumn(false)]
        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal con04_id { get; set; }

        [Display(Name = "Acceso Rapido")]
        [Required(ErrorMessage = "Debe ingresar un valor para {0}")]
        [StringLength(500, ErrorMessage = "El registro {0} debe estar entre {2} y {1} caracteres", MinimumLength = 3)]
        public string con04_accesoRapido { get; set; }

        [Display(Name = "Descripción")]
        public string con04_descripcion { get; set; }

        [Display(Name = "Asunto")]
        public string con04_Asunto { get; set; }

        [Display(Name = "Mensaje Plano")]
        public string con04_mesnajetxt { get; set; }

        [Display(Name = "Mensaje Html")]
        public string con04_mesnajehtml { get; set; }
        
        [ScaffoldColumn(false)]
        [Display(Name = "Estado")]
        public int? con04_estado { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Fecha creación")]
        [DisplayFormat(DataFormatString = "{0:dd-mm-yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? con04_fechacreacion { get; set; }

        [Display(Name = "Fecha Actualización")]
        [DisplayFormat(DataFormatString = "{0:dd-mm-yyyy}", ApplyFormatInEditMode = true)]
        [ScaffoldColumn(false)]
        [DataType(DataType.Date)]
        public DateTime? con04_ultimaactualizacion { get; set; }

        public virtual gen01_estados gen01_estados { get; set; }

    }
}