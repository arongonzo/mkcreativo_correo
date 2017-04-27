namespace mksolucion.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class crr01_correos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public crr01_correos()
        {
            crr05_interesCorreo = new HashSet<crr05_interesCorreo>();
            crr07_correoOrganizacion = new HashSet<crr07_correoOrganizacion>();
            crr02_tipoclasificacion = new HashSet<crr02_tipoclasificacion>();
            lis01_lista = new HashSet<lis01_lista>();
        }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal crr01_id { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? crr01_rut { get; set; }

        [StringLength(500)]
        public string crr01_nombre { get; set; }

        [StringLength(500)]
        public string crr02_apellido1 { get; set; }

        [StringLength(500)]
        public string crr01_nombrecompleto { get; set; }

        [StringLength(500)]
        public string crr01_direccion { get; set; }

        [StringLength(500)]
        public string crr01_region { get; set; }

        [StringLength(500)]
        public string crr01_comuna { get; set; }

        [StringLength(500)]
        public string crr01_pais { get; set; }

        [StringLength(500)]
        public string crr01_area { get; set; }

        [StringLength(500)]
        public string crr01_mail { get; set; }

        [StringLength(500)]
        public string crr01_mail2 { get; set; }

        [StringLength(500)]
        public string crr01_empresa { get; set; }

        [StringLength(500)]
        public string crr01_celular1 { get; set; }

        [StringLength(500)]
        public string crr01_celular2 { get; set; }

        [StringLength(500)]
        public string crr01_telefono1 { get; set; }

        [StringLength(500)]
        public string crr01_telefono2 { get; set; }

        [StringLength(500)]
        public string crr01_edad { get; set; }

        [StringLength(500)]
        public string crr01_sexo { get; set; }

        [StringLength(500)]
        public string crr01_sitioweb { get; set; }

        public int? crr01_estado { get; set; }

        public int? crr01_estadoenvio { get; set; }

        public DateTime? crr01_fechacreacion { get; set; }

        public DateTime? crr01_ultimaactualizacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<crr05_interesCorreo> crr05_interesCorreo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<crr07_correoOrganizacion> crr07_correoOrganizacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<crr02_tipoclasificacion> crr02_tipoclasificacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<lis01_lista> lis01_lista { get; set; }
    }
}
