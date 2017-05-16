namespace mksolucion.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using mksolucion.Models;

    public class usr02_estadocompletado
    {
        [ScaffoldColumn(false)]
        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal? usr02_id { get; set; }

        public string UserId { get; set; }

        [Display(Name = "Confirmado")]
        public int? usr02_confirmado { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Fecha corfirmado")]
        [DisplayFormat(DataFormatString = "{0:dd-mm-yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? usr02_fechacorfirmado { get; set; }

        [Display(Name = "completado")]
        public string usr02_completado { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Fecha completado")]
        [DisplayFormat(DataFormatString = "{0:dd-mm-yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? usr02_fechacompletado { get; set; }

        public virtual AspNetUsers AspNetUsers { get; set; }

    }
}