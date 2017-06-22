using System;
using System.ComponentModel.DataAnnotations;

namespace mksolucion.Models
{
    public class _con04_mensajepredef
    {

        [Display(Name = "Mensaje Predefinido")]
        [ScaffoldColumn(false)]
        [Key]
        public decimal con04_id { get; set; }

        [Display(Name = "Acceso Rapido")]
        public string con04_accesoRapido { get; set; }

        [Display(Name = "Descripción")]
        public string con04_descripcion { get; set; }

        [Display(Name = "Asunto")]
        public string con04_Asunto { get; set; }

        [Display(Name = "Mensaje Plano")]
        public string con04_mensajetxt { get; set; }

        [Display(Name = "Mensaje Html")]
        public string con04_mensajehtml { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Estado")]
        public int? con04_estado { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Fecha creación")]
        public DateTime? con04_fechacreacion { get; set; }

        [Display(Name = "Fecha Actualización")]
        [ScaffoldColumn(false)]
        public DateTime? con04_ultimaactualizacion { get; set; }

    }
}