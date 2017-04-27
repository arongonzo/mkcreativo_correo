namespace mksolucion.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class crr05_interesCorreo
    {
        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        public decimal crr01_id { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "numeric")]
        public decimal crr04_id { get; set; }

        public virtual crr01_correos crr01_correos { get; set; }

        public virtual crr04_intereses crr04_intereses { get; set; }

        public virtual lis01_lista lis01_lista { get; set; }
    }
}
