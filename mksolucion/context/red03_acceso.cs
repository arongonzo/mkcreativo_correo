namespace mksolucion.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class red03_acceso
    {
        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        public decimal red01_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int serv04_id { get; set; }

        [Required]
        [StringLength(250)]
        public string red03_url { get; set; }

        [Required]
        [StringLength(250)]
        public string red03_usuario { get; set; }

        [Required]
        [StringLength(250)]
        public string red03_password { get; set; }

        public int red03_activo { get; set; }

        public DateTime? red03_fechacreacion { get; set; }

        public virtual red02_datosContacto red02_datosContacto { get; set; }
    }
}
