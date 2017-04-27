namespace mksolucion.Models
{
    using mksolucion.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class serv01_servicios
    {
        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal ser01_id { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? cnt01_id { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? pnl01_id { get; set; }

        public int? ser01_estado { get; set; }

        public DateTime? ser01_fechacreacion { get; set; }

        public DateTime? ser01_ultimaactualizacion { get; set; }

        public virtual cnt01_cuenta cnt01_cuenta { get; set; }

        public virtual pln01_planes pln01_planes { get; set; }
    }
}
