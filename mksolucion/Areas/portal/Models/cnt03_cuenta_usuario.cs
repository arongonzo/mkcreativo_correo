namespace mksolucion.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class cnt03_cuenta_usuario
    {
        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        public decimal cnt01_id { get; set; }

        [Key]
        [Column(Order = 1)]
        public string UserId { get; set; }
        
        public virtual cnt01_cuenta cnt01_cuenta { get; set; }
        public virtual AspNetUsers AspNetUsers { get; set; }
    }
}
