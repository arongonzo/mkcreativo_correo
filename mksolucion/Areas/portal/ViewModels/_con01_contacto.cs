using System;
using System.ComponentModel.DataAnnotations;

namespace mksolucion.Models
{
    public class _con01_contacto
    {

        [Display(Name = "Soporte")]
        [ScaffoldColumn(false)]
        [Key]
        public decimal con01_id { get; set; }

        [Display(Name = "nombre")]
        public string con01_nombre { get; set; }

        [Display(Name = "Direccion email")]
        public string con01_email { get; set; }

        [Display(Name = "Nombre Destinatario")]
        public string con01_destinatario { get; set; }

        [Display(Name = "Email destinatario")]
        public string con01_emaildestinatario { get; set; }

        [Display(Name = "Asunto")]
        public string con01_asunto { get; set; }

        [Display(Name = "Tipo Soporte")]
        public decimal? con02_id { get; set; }

        [Display(Name = "importancia")]
        public decimal? con03_id { get; set; }

        [Display(Name = "Servicio")]
        public decimal? ser01_id { get; set; }

        [Display(Name = "Mensaje")]
        public string con01_mensaje { get; set; }

        [Display(Name = "Adjunto")]
        public string con01_adjunto { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Estado")]
        public int? con01_estado { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy HH:mm}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha creación")]
        public DateTime? con01_fechacreacion { get; set; }

        [Display(Name = "Fecha Actualización")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime? con01_ultimaactualizacion { get; set; }

        public virtual serv01_servicios serv01_servicios { get; set; }

        [UIHint("Tipo Contacto")]
        public _con02_tipocontacto _TipoContacto
        {
            get;
            set;
        }

        [UIHint("Importancia")]
        public _con03_importancia _Importancia
        {
            get;
            set;
        }

        [UIHint("estado")]
        public _con05_EstadoMensaje _EstadoMensaje
        {
            get;
            set;
        }

    }
}