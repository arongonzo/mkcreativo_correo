namespace mksolucion.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    public class ntf01_notificaciones
    {
       
        [ScaffoldColumn(false)]
        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal? ntf01_id { get; set; }

        public string UserId { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ntf02_id { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Fecha envio")]
        [DisplayFormat(DataFormatString = "{0:dd-mm-yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? ntf02_fechaenvio { get; set; }

        [Display(Name = "Asunto")]
        [StringLength(500, ErrorMessage = "El registro {0} debe estar entre {2} y {1} caracteres", MinimumLength = 3)]
        [Required(ErrorMessage = "Debe ingresar un valor para {0}")]
        public string ntf01_asunto { get; set; }

        [Display(Name = "remitente")]
        [StringLength(500, ErrorMessage = "El registro {0} debe estar entre {2} y {1} caracteres", MinimumLength = 3)]
        public string ntf01_remitente { get; set; }

        [Display(Name = "destinatario")]
        [StringLength(500, ErrorMessage = "El registro {0} debe estar entre {2} y {1} caracteres", MinimumLength = 3)]
        public string ntf01_destinatario { get; set; }

        [Display(Name = "destinatariocc")]
        [StringLength(500, ErrorMessage = "El registro {0} debe estar entre {2} y {1} caracteres", MinimumLength = 3)]
         public string ntf01_destinatariocc { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ntf02_idpadre { get; set; }

        [Display(Name = "Contenido")]
        public string ntf01_contenido { get; set; }

        [Display(Name = "adjuntourl")]
        public string ntf01_adjuntourl { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Estado")]
        public int? ntf01_estado { get; set; }

        public virtual ntf02_tiponotificacioncorreo ntf02_tiponotificacioncorreo { get; set; }

        public virtual AspNetUsers AspNetUsers { get; set; }

    }
}