namespace mksolucion.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class con01_contacto
    {
        [Display(Name = "Soporte")]
        [ScaffoldColumn(false)]
        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal con01_id { get; set; }

        public string UserId { get; set; }

        public decimal? con01_id_padre { get; set; }

        [Display(Name = "nombre")]
        [Required(ErrorMessage = "Debe ingresar un valor para {0}")]
        [StringLength(500, ErrorMessage = "El registro {0} debe estar entre {2} y {1} caracteres", MinimumLength = 3)]
        public string con01_nombre { get; set; }
        
        [Display(Name = "Direccion email")]
        [Required(ErrorMessage = "Debe ingresar un valor para {0}")]
        [StringLength(500, ErrorMessage = "El registro {0} debe estar entre {2} y {1} caracteres", MinimumLength = 3)]
        public string con01_email { get; set; }

        [Display(Name = "Asunto")]
        [Required(ErrorMessage = "Debe ingresar un valor para {0}")]
        [StringLength(500, ErrorMessage = "El registro {0} debe estar entre {2} y {1} caracteres", MinimumLength = 3)]
        public string con01_asunto { get; set; }

        [Display(Name = "Tipo Soporte")]
        [Column(TypeName = "numeric")]
        public decimal? con02_id { get; set; }

        [Display(Name = "importancia")]
        [Column(TypeName = "numeric")]
        public decimal? con03_id { get; set; }

        [Display(Name = "Servicio")]
        [Column(TypeName = "numeric")]
        public decimal? ser01_id { get; set; }

        [Display(Name = "Estado")]
        [Column(TypeName = "numeric")]
        public decimal? con05_id { get; set; }

        [Display(Name = "Mensaje")]
        public string con01_mensaje { get; set; }

        [Display(Name = "Adjunto")]
        public string con01_adjunto { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Estado")]
        public int? con01_estado { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Fecha creación")]
        [DisplayFormat(DataFormatString = "{0:dd-mm-yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? con01_fechacreacion { get; set; }

        [Display(Name = "Fecha Actualización")]
        [DisplayFormat(DataFormatString = "{0:dd-mm-yyyy}", ApplyFormatInEditMode = true)]
        [ScaffoldColumn(false)]
        [DataType(DataType.Date)]
        public DateTime? con01_ultimaactualizacion { get; set; }

        public virtual serv01_servicios serv01_servicios { get; set; }
        public virtual con02_tipocontacto con02_tipocontacto { get; set; }

        public virtual con05_EstadoMensaje con05_EstadoMensaje { get; set; }

        public virtual con03_importancia con03_importancia { get; set; }

        public virtual gen01_estados gen01_estados { get; set; }

    }
}