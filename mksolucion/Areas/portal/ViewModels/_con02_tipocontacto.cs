using System;
using System.ComponentModel.DataAnnotations;

namespace mksolucion.Models
{
    public class _con02_tipocontacto
    {
        [Key]
        public decimal con02_id { get; set; }

        [Display(Name = "Tipo Campaña")]
        public string con02_nombre { get; set; }

        [Display(Name = "Descripción")]
        public string con02_descripcion { get; set; }

        [Display(Name = "credencial")]
        public string con02_usuariocredencial { get; set; }

        [Display(Name = "credencial clave")]
        public string con02_usuariocredencialclave { get; set; }

        [Display(Name = "credencial host")]
        public string con02_host { get; set; }

        [Display(Name = "credencial port")]
        public string con02_port { get; set; }

        [Display(Name = "credencial ssl")]
        public int? con02_ssl { get; set; }

        [Display(Name = "Estado")]
        public int? con02_estado { get; set; }

         public DateTime? con02_fechacreacion { get; set; }

         public DateTime? con02_ultimaactualizacion { get; set; }

    }
}