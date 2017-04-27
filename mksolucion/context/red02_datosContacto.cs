namespace mksolucion.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class red02_datosContacto
    {
        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        public decimal red01_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int serv04_id { get; set; }

        public DateTime? red02_fechacreacion { get; set; }

        public virtual red01_social red01_social { get; set; }

        public virtual red03_acceso red03_acceso { get; set; }
    }
}
