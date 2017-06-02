namespace mksolucion.Models.completarinfo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class completarinfo
    {
        [Display(Name = "Nombre")]
        [StringLength(500, ErrorMessage = "El registro {0} debe estar entre {2} y {1} caracteres", MinimumLength = 3)]
        [Required(ErrorMessage = "Debe ingresar un valor para {0}")]
        public string Nombre { get; set; }


        [Display(Name = "Apellido")]
        [StringLength(500, ErrorMessage = "El registro {0} debe estar entre {2} y {1} caracteres", MinimumLength = 3)]
        [Required(ErrorMessage = "Debe ingresar un valor para {0}")]
        public string Apellido { get; set; }

        [Display(Name = "Empresa")]
        [StringLength(500, ErrorMessage = "El registro {0} debe estar entre {2} y {1} caracteres", MinimumLength = 3)]
        [Required(ErrorMessage = "Debe ingresar un valor para {0}")]
        public string Empresa { get; set; }

        [Display(Name = "Sitio web")]
        [StringLength(500, ErrorMessage = "El registro {0} debe estar entre {2} y {1} caracteres", MinimumLength = 3)]
        public string Sitioweb { get; set; }

        [Display(Name = "Direccion Linea 1")]
        [StringLength(500, ErrorMessage = "El registro {0} debe estar entre {2} y {1} caracteres", MinimumLength = 3)]
        [Required(ErrorMessage = "Debe ingresar un valor para {0}")]
        public string direccion1 { get; set; }

        [Display(Name = "Direccion Linea 2")]
        [StringLength(500, ErrorMessage = "El registro {0} debe estar entre {2} y {1} caracteres", MinimumLength = 3)]
        public string direccion2 { get; set; }

        [Display(Name = "Ciudad")]
        [StringLength(500, ErrorMessage = "El registro {0} debe estar entre {2} y {1} caracteres", MinimumLength = 3)]
        [Required(ErrorMessage = "Debe ingresar un valor para {0}")]
        public string Ciudad { get; set; }

        [Display(Name = "Zip code")]
        [StringLength(500, ErrorMessage = "El registro {0} debe estar entre {2} y {1} caracteres", MinimumLength = 3)]
        public string Zipcode { get; set; }

        [Display(Name = "Pais")]
        [StringLength(500, ErrorMessage = "El registro {0} debe estar entre {2} y {1} caracteres", MinimumLength = 3)]
        [Required(ErrorMessage = "Debe ingresar un valor para {0}")]
        public string Pais { get; set; }

    }
}