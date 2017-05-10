using System;
using System.ComponentModel.DataAnnotations;

namespace mksolucion.Models
{
    public class _ntf01_notificaciones
    {
        [Key]
        public decimal? ntf01_id { get; set; }

        public string UserId { get; set; }

        public decimal? ntf02_id { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha envio")]
        public DateTime? ntf02_fechaenvio { get; set; }

        [Display(Name = "Asunto")]
        public string ntf01_asunto { get; set; }

        [Display(Name = "remitente")]
        public string ntf01_remitente { get; set; }

        [Display(Name = "destinatario")]
        public string ntf01_destinatario { get; set; }

        [Display(Name = "destinatariocc")]
        public string ntf01_destinatariocc { get; set; }

        public decimal? ntf02_idpadre { get; set; }

        [Display(Name = "Contenido")]
        public string ntf01_contenido { get; set; }

        [Display(Name = "adjuntourl")]
        public string ntf01_adjuntourl { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Estado")]
        public int? ntf01_estado { get; set; }

        [Display(Name = "Tipo Notificacion")]
        public string nombre_tiponotificacion { get; set; }

        [Display(Name = "Nombre de Usuario")]
        public string User_Name { get; set; }

    }
}