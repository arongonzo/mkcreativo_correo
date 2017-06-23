using System;
using System.ComponentModel.DataAnnotations;

namespace mksolucion.Models
{
    public class _ntf03_mensajepredef
    {

        [Display(Name = "Mensaje Predefinido")]
        [ScaffoldColumn(false)]
        [Key]
        public decimal ntf03_id { get; set; }

        [Display(Name = "Tipo Notificación")]
        public decimal ntf02_id { get; set; }

        [Display(Name = "Acceso Rapido")]
        public string ntf03_accesoRapido { get; set; }

        [Display(Name = "Descripción")]
        public string ntf03_descripcion { get; set; }

        [Display(Name = "Asunto")]
        public string ntf03_Asunto { get; set; }

        [Display(Name = "Mensaje Plano")]
        public string ntf03_mensajetxt { get; set; }

        [Display(Name = "Mensaje Html")]
        public string ntf03_mensajehtml { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Estado")]
        public int? ntf03_estado { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Fecha creación")]
        public DateTime? ntf03_fechacreacion { get; set; }

        [Display(Name = "Fecha Actualización")]
        [ScaffoldColumn(false)]
        public DateTime? ntf03_ultimaactualizacion { get; set; }

        [UIHint("TipoNotificacion")]
        public _ntf02_tiponotificacioncorreo _TipoNotificacion
        {
            get;
            set;
        }

    }
}