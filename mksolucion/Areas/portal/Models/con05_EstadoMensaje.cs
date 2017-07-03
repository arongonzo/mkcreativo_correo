﻿namespace mksolucion.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    public class con05_EstadoMensaje
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public con05_EstadoMensaje()
        {
            con01_contacto = new HashSet<con01_contacto>();
        }

        [Display(Name = "Estado Mensaje")]
        [ScaffoldColumn(false)]
        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal con05_id { get; set; }

        [Display(Name = "Estado Mensaje")]
        [Required(ErrorMessage = "Debe ingresar un valor para {0}")]
        [StringLength(500, ErrorMessage = "El registro {0} debe estar entre {2} y {1} caracteres", MinimumLength = 3)]
        public string con05_nombre { get; set; }

        [Display(Name = "Descripción")]
        public string con05_descripcion { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Estado")]
        public int? con05_estado { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Fecha creación")]
        [DisplayFormat(DataFormatString = "{0:dd-mm-yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? con05_fechacreacion { get; set; }

        [Display(Name = "Fecha Actualización")]
        [DisplayFormat(DataFormatString = "{0:dd-mm-yyyy}", ApplyFormatInEditMode = true)]
        [ScaffoldColumn(false)]
        [DataType(DataType.Date)]
        public DateTime? con05_ultimaactualizacion { get; set; }

        public virtual gen01_estados gen01_estados { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<con01_contacto> con01_contacto { get; set; }
    }
}