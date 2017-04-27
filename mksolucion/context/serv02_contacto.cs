namespace mksolucion.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class serv02_contacto
    {
        [Key]
        public int serv02_id { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ser01_id { get; set; }

        [StringLength(250)]
        public string serv02_nombre { get; set; }

        [StringLength(250)]
        public string serv02_apellido { get; set; }

        [StringLength(250)]
        public string serv02_email { get; set; }

        [StringLength(250)]
        public string serv02_direccion { get; set; }

        [StringLength(250)]
        public string serv02_ciudad { get; set; }

        [StringLength(250)]
        public string serv02_region { get; set; }

        public int? loc01_id { get; set; }

        [StringLength(50)]
        public string serv02_codigoPostal { get; set; }

        [StringLength(50)]
        public string serv02_telefono { get; set; }

        [StringLength(50)]
        public string serv02_celular { get; set; }

        [StringLength(10)]
        public string serv02_rut { get; set; }

        public DateTime? serv02_fechanacimiento { get; set; }

        public int? red01_id { get; set; }

        public int? serv02_estado { get; set; }

        public DateTime? serv02_fechaCreacion { get; set; }

        public DateTime? serv02_ultimaactualizacion { get; set; }
    }
}
