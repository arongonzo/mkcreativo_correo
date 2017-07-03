namespace mksolucion.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class v_ServicioUsuario
    {
        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        public decimal ser01_id { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? pnl01_id { get; set; }

        public int? ser01_estado { get; set; }

        public DateTime? ser01_fechacreacion { get; set; }

        public DateTime? ser01_ultimaactualizacion { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? pln02_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(500)]
        public string pln01_nombre { get; set; }

        public string pln01_detalle { get; set; }

        public string pln01_html { get; set; }

        public int? pln01_activo { get; set; }

        public DateTime? pln01_fechacreacion { get; set; }

        public DateTime? pln01_ultimaactualizacion { get; set; }

        [StringLength(500)]
        public string pln02_nombre { get; set; }

        public string pln02_descripcion { get; set; }

        public int? pln02_estado { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "numeric")]
        public decimal cnt01_id { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "numeric")]
        public decimal pln03_id { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(500)]
        public string pln03_nombre { get; set; }

        public int? pln03_estado { get; set; }

        [Key]
        [Column(Order = 5, TypeName = "numeric")]
        public decimal cnt02_id { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(500)]
        public string cnt02_nombre { get; set; }

        [Key]
        [Column(Order = 7)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int cnt02_estado { get; set; }

        [Key]
        [Column(Order = 8)]
        public string Id { get; set; }

        [Key]
        [Column(Order = 9)]
        [StringLength(256)]
        public string UserName { get; set; }
    }
}
