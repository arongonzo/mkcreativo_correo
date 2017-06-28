using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using mksolucion.Models;

namespace mksolucion.Models
{
    public class ins01_inscripcion
    {
        [ScaffoldColumn(false)]
        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal? ins01_id { get; set; }

        
        public string UserId { get; set; }

        [Display(Name = "Descripción")]
        public string ins01_nombreusuario { get; set; }

        [Display(Name = "Descripción")]
        public string ins01_claveacceso { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Estado")]
        public int? ins01_estado { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Fecha creación")]
        [DisplayFormat(DataFormatString = "{0:dd-mm-yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? ins01_fechacreacion { get; set; }

        [Display(Name = "Fecha Activación")]
        [DisplayFormat(DataFormatString = "{0:dd-mm-yyyy}", ApplyFormatInEditMode = true)]
        [ScaffoldColumn(false)]
        [DataType(DataType.Date)]
        public DateTime? ins01_fechaactivacion { get; set; }

        public virtual gen01_estados gen01_estados { get; set; }

        public virtual AspNetUsers AspNetUsers { get; set; }
    }
}