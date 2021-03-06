namespace mksolucion.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using mksolucion.Models;

    public partial class gen01_estados
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public gen01_estados()
        {
            cam01_campana = new HashSet<cam01_campana>();
            cam02_tipocampana = new HashSet<cam02_tipocampana>();
            cnt02_tipocuenta = new HashSet<cnt02_tipocuenta>();
            cam03_detallecampana = new HashSet<cam03_detallecampana>();
            cam05_configuracionadiocional = new HashSet<cam05_configuracionadiocional>();
            crr04_intereses = new HashSet<crr04_intereses>();
            crr06_organizacion = new HashSet<crr06_organizacion>();
            lis01_lista = new HashSet<lis01_lista>();
            lis02_clasificacion = new HashSet<lis02_clasificacion>();
            
            crr08_estadoCorreo = new HashSet<crr08_estadoCorreo>();
            crr03_areasegmento = new HashSet<crr03_areasegmento>();
            ntf02_tiponotificacioncorreo = new HashSet<ntf02_tiponotificacioncorreo>();
            
            usr01_infopersonal = new HashSet<usr01_infopersonal>();
            pln03_tipocobro = new HashSet<pln03_tipocobro>();
            pln02_tipoplan = new HashSet<pln02_tipoplan>();
            pln01_planes = new HashSet<pln01_planes>();

            con01_contacto = new HashSet<con01_contacto>();
            con02_tipocontacto = new HashSet<con02_tipocontacto>();
            con03_importancia = new HashSet<con03_importancia>();
            ntf03_mensajepredef = new HashSet<ntf03_mensajepredef>();
            con05_EstadoMensaje = new HashSet<con05_EstadoMensaje>();

            ins01_inscripcion = new HashSet<ins01_inscripcion>();
            
            
        }
        
        [ScaffoldColumn(false)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int gen01_id { get; set; }

        [Display(Name = "Estado Activaci�n")]
        [StringLength(500, ErrorMessage = "El registro {0} debe estar entre {2} y {1} caracteres", MinimumLength = 3)]
        [Required(ErrorMessage = "Debe ingresar un valor para {0}")]
        public string gen01_nombre { get; set; }

        [Display(Name = "Descripci�n")]
        public string gen01_descripcion { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Fecha creaci�n")]
        [DisplayFormat(DataFormatString = "{0:dd-mm-yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? gen01_fechacreacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<crr02_tipoclasificacion> crr02_tipoclasificacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<crr03_areasegmento> crr03_areasegmento { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cam01_campana> cam01_campana { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cam02_tipocampana> cam02_tipocampana { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cnt02_tipocuenta> cnt02_tipocuenta { get; set; }
        
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cam03_detallecampana> cam03_detallecampana { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cam05_configuracionadiocional> cam05_configuracionadiocional { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<crr04_intereses> crr04_intereses { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<crr06_organizacion> crr06_organizacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<lis01_lista> lis01_lista { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<lis02_clasificacion> lis02_clasificacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<pln01_planes> pln01_planes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<crr08_estadoCorreo> crr08_estadoCorreo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ntf02_tiponotificacioncorreo> ntf02_tiponotificacioncorreo { get; set; }



        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<con01_contacto> con01_contacto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<con02_tipocontacto> con02_tipocontacto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<con03_importancia> con03_importancia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ntf03_mensajepredef> ntf03_mensajepredef { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<con05_EstadoMensaje> con05_EstadoMensaje { get; set; }

        
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<usr01_infopersonal> usr01_infopersonal { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<pln03_tipocobro> pln03_tipocobro { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<pln02_tipoplan> pln02_tipoplan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ins01_inscripcion> ins01_inscripcion { get; set; }
        
                

    }
}
