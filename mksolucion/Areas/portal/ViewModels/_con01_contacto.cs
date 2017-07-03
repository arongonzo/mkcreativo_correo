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

        [ScaffoldColumn(false)]
        [Display(Name = "Fecha creación")]
        public DateTime? con01_fechacreacion { get; set; }

        [Display(Name = "Fecha Actualización")]
        [ScaffoldColumn(false)]
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