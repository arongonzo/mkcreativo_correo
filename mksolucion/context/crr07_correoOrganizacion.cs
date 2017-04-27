namespace mksolucion.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class crr07_correoOrganizacion
    {
        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        public decimal crr01_id { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "numeric")]
        public decimal crr06_id { get; set; }

        public virtual crr01_correos crr01_correos { get; set; }

        public virtual crr06_organizacion crr06_organizacion { get; set; }

        public virtual lis01_lista lis01_lista { get; set; }
    }
}
