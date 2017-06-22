namespace mksolucion.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using mksolucion.Models;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public partial class ModelMK : DbContext
    {
        public ModelMK()
            : base("name=ModelMK")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<cam01_campana> cam01_campana { get; set; }
        public virtual DbSet<cam02_tipocampana> cam02_tipocampana { get; set; }
        public virtual DbSet<cam03_detallecampana> cam03_detallecampana { get; set; }
        public virtual DbSet<cam05_configuracionadiocional> cam05_configuracionadiocional { get; set; }
        public virtual DbSet<cam06_tipoconfiguracionadicional> cam06_tipoconfiguracionadicional { get; set; }
        public virtual DbSet<cam07_datoSociales> cam07_datoSociales { get; set; }
        public virtual DbSet<cnt01_cuenta> cnt01_cuenta { get; set; }
        public virtual DbSet<cnt02_tipocuenta> cnt02_tipocuenta { get; set; }


        public virtual DbSet<con01_contacto> con01_contacto { get; set; }
        public virtual DbSet<con02_tipocontacto> con02_tipocontacto { get; set; }
        public virtual DbSet<con03_importancia> con03_importancia { get; set; }
        public virtual DbSet<con04_mensajepredef> con04_mensajepredef { get; set; }
        public virtual DbSet<con05_EstadoMensaje> con05_EstadoMensaje { get; set; }
        

        public virtual DbSet<cnt03_cuenta_usuario> cnt03_cuenta_usuario { get; set; }
        public virtual DbSet<crr01_correos> crr01_correos { get; set; }
        public virtual DbSet<crr02_tipoclasificacion> crr02_tipoclasificacion { get; set; }
        public virtual DbSet<crr03_areasegmento> crr03_areasegmento { get; set; }
        public virtual DbSet<crr04_intereses> crr04_intereses { get; set; }
        public virtual DbSet<crr05_interesCorreo> crr05_interesCorreo { get; set; }
        public virtual DbSet<crr06_organizacion> crr06_organizacion { get; set; }
        public virtual DbSet<crr07_correoOrganizacion> crr07_correoOrganizacion { get; set; }
        public virtual DbSet<crr08_estadoCorreo> crr08_estadoCorreo { get; set; }
        public virtual DbSet<Ejemploes> Ejemploes { get; set; }
        public virtual DbSet<gen01_estados> gen01_estados { get; set; }
        public virtual DbSet<lis01_lista> lis01_lista { get; set; }
        public virtual DbSet<lis02_clasificacion> lis02_clasificacion { get; set; }
        public virtual DbSet<lis04_tipolista> lis04_tipolista { get; set; }
        public virtual DbSet<loc01_pais> loc01_pais { get; set; }
        public virtual DbSet<ntf01_notificaciones> ntf01_notificaciones { get; set; }
        public virtual DbSet<ntf02_tiponotificacioncorreo> ntf02_tiponotificacioncorreo { get; set; }
        public virtual DbSet<pln01_planes> pln01_planes { get; set; }
        public virtual DbSet<pln02_tipoplan> pln02_tipoplan { get; set; }
        public virtual DbSet<pln03_tipocobro> pln03_tipocobro { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<red01_social> red01_social { get; set; }
        public virtual DbSet<red02_datosContacto> red02_datosContacto { get; set; }
        public virtual DbSet<red03_acceso> red03_acceso { get; set; }
        public virtual DbSet<serv01_servicios> serv01_servicios { get; set; }
        public virtual DbSet<serv02_contacto> serv02_contacto { get; set; }
        public virtual DbSet<coninf01_pasocominfo> coninf01_pasocominfo { get; set; }
        public virtual DbSet<usr02_estadocompletado> usr02_estadocompletado { get; set; }
        public virtual DbSet<usr01_infopersonal> usr01_infopersonal { get; set; }

        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetRoles>()
              .HasMany(e => e.AspNetUserRoles)
              .WithRequired(e => e.AspNetRoles)
              .HasForeignKey(e => e.RoleId)
              .WillCascadeOnDelete(false);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.AspNetUserRoles)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.usr01_infopersonal)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<cam01_campana>()
                .HasMany(e => e.cam07_datoSociales)
                .WithRequired(e => e.cam01_campana)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<cam01_campana>()
                .HasMany(e => e.cam05_configuracionadiocional)
                .WithMany(e => e.cam01_campana)
                .Map(m => m.ToTable("cam04_configuracioncampana").MapLeftKey("cam01_id").MapRightKey("cam05_id"));

            modelBuilder.Entity<cam01_campana>()
                .HasMany(e => e.lis01_lista)
                .WithMany(e => e.cam01_campana)
                .Map(m => m.ToTable("cam08_campanalistas").MapLeftKey("cam01_id").MapRightKey("lis01_id"));

            modelBuilder.Entity<cnt01_cuenta>()
                .HasMany(e => e.cnt03_cuenta_usuario)
                .WithRequired(e => e.cnt01_cuenta)
                .HasForeignKey(e => e.cnt01_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.cnt03_cuenta_usuario)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.usr02_estadocompletado)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<crr01_correos>()
                .HasMany(e => e.crr05_interesCorreo)
                .WithRequired(e => e.crr01_correos)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<crr01_correos>()
                .HasMany(e => e.crr07_correoOrganizacion)
                .WithRequired(e => e.crr01_correos)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<crr01_correos>()
                .HasMany(e => e.lis01_lista)
                .WithMany(e => e.crr01_correos)
                .Map(m => m.ToTable("lis05_listacorreo").MapLeftKey("crr01_id").MapRightKey("lis01_id"));

            modelBuilder.Entity<crr04_intereses>()
                .HasMany(e => e.crr05_interesCorreo)
                .WithRequired(e => e.crr04_intereses)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<crr06_organizacion>()
                .HasMany(e => e.crr07_correoOrganizacion)
                .WithRequired(e => e.crr06_organizacion)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<gen01_estados>()
               .HasMany(e => e.usr01_infopersonal)
               .WithOptional(e => e.gen01_estados)
               .HasForeignKey(e => e.usr01_estado);

            modelBuilder.Entity<gen01_estados>()
               .HasMany(e => e.ntf02_tiponotificacioncorreo)
               .WithOptional(e => e.gen01_estados)
               .HasForeignKey(e => e.ntf02_estado);

            modelBuilder.Entity<gen01_estados>()
                .HasMany(e => e.crr08_estadoCorreo)
                .WithOptional(e => e.gen01_estados)
                .HasForeignKey(e => e.crr08_estado);

            modelBuilder.Entity<gen01_estados>()
                .HasMany(e => e.crr02_tipoclasificacion)
                .WithOptional(e => e.gen01_estados)
                .HasForeignKey(e => e.crr02_estado);

            modelBuilder.Entity<gen01_estados>()
                .HasMany(e => e.crr03_areasegmento)
                .WithOptional(e => e.gen01_estados)
                .HasForeignKey(e => e.crr03_estado);

            modelBuilder.Entity<gen01_estados>()
                .HasMany(e => e.cam01_campana)
                .WithOptional(e => e.gen01_estados)
                .HasForeignKey(e => e.cam01_estado);

            modelBuilder.Entity<gen01_estados>()
                .HasMany(e => e.cam02_tipocampana)
                .WithRequired(e => e.gen01_estados)
                .HasForeignKey(e => e.cam02_estado)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<gen01_estados>()
                .HasMany(e => e.cnt02_tipocuenta)
                .WithRequired(e => e.gen01_estados)
                .HasForeignKey(e => e.cnt02_estado)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<gen01_estados>()
                .HasMany(e => e.cam03_detallecampana)
                .WithOptional(e => e.gen01_estados)
                .HasForeignKey(e => e.cam03_estado);

            modelBuilder.Entity<gen01_estados>()
                .HasMany(e => e.cam05_configuracionadiocional)
                .WithOptional(e => e.gen01_estados)
                .HasForeignKey(e => e.cam05_estado);

            modelBuilder.Entity<gen01_estados>()
                .HasMany(e => e.crr04_intereses)
                .WithOptional(e => e.gen01_estados)
                .HasForeignKey(e => e.crr04_estado);

            modelBuilder.Entity<gen01_estados>()
                .HasMany(e => e.crr06_organizacion)
                .WithOptional(e => e.gen01_estados)
                .HasForeignKey(e => e.crr06_estado);

            modelBuilder.Entity<gen01_estados>()
                .HasMany(e => e.lis01_lista)
                .WithOptional(e => e.gen01_estados)
                .HasForeignKey(e => e.lis01_estado);

            modelBuilder.Entity<gen01_estados>()
                .HasMany(e => e.lis02_clasificacion)
                .WithOptional(e => e.gen01_estados)
                .HasForeignKey(e => e.lis02_estado);

            modelBuilder.Entity<gen01_estados>()
                .HasMany(e => e.pln01_planes)
                .WithOptional(e => e.gen01_estados)
                .HasForeignKey(e => e.pln01_activo);

            modelBuilder.Entity<gen01_estados>()
                .HasMany(e => e.pln03_tipocobro)
                .WithOptional(e => e.gen01_estados)
                .HasForeignKey(e => e.pln03_estado);

            modelBuilder.Entity<gen01_estados>()
                .HasMany(e => e.pln02_tipoplan)
                .WithOptional(e => e.gen01_estados)
                .HasForeignKey(e => e.pln02_estado);

            modelBuilder.Entity<gen01_estados>()
               .HasMany(e => e.con01_contacto)
               .WithOptional(e => e.gen01_estados)
               .HasForeignKey(e => e.con01_estado);

            modelBuilder.Entity<gen01_estados>()
               .HasMany(e => e.con02_tipocontacto)
               .WithOptional(e => e.gen01_estados)
               .HasForeignKey(e => e.con02_estado);


            modelBuilder.Entity<gen01_estados>()
               .HasMany(e => e.con03_importancia)
               .WithOptional(e => e.gen01_estados)
               .HasForeignKey(e => e.con03_estado);

             modelBuilder.Entity<gen01_estados>()
               .HasMany(e => e.con04_mensajepredef)
               .WithOptional(e => e.gen01_estados)
               .HasForeignKey(e => e.con04_estado);

             modelBuilder.Entity<gen01_estados>()
                .HasMany(e => e.con05_EstadoMensaje)
                .WithOptional(e => e.gen01_estados)
                .HasForeignKey(e => e.con05_estado);


            modelBuilder.Entity<ntf02_tiponotificacioncorreo>()
                .HasMany(e => e.ntf01_notificaciones)
                .WithRequired(e => e.ntf02_tiponotificacioncorreo)
                .HasForeignKey(e => e. ntf02_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.ntf01_notificaciones)
                .WithOptional(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<lis01_lista>()
                .HasMany(e => e.crr05_interesCorreo)
                .WithRequired(e => e.lis01_lista)
                .HasForeignKey(e => e.crr01_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<lis01_lista>()
                .HasMany(e => e.crr07_correoOrganizacion)
                .WithRequired(e => e.lis01_lista)
                .HasForeignKey(e => e.crr01_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<con02_tipocontacto>()
                .HasMany(e => e.con01_contacto)
                .WithRequired(e => e.con02_tipocontacto)
                .HasForeignKey(e => e.con02_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<serv01_servicios>()
                .HasMany(e => e.con01_contacto)
                .WithOptional(e => e.serv01_servicios)
                .HasForeignKey(e => e.ser01_id);


            modelBuilder.Entity<con03_importancia>()
                .HasMany(e => e.con01_contacto)
                .WithRequired(e => e.con03_importancia)
                .HasForeignKey(e => e.con03_id)
                .WillCascadeOnDelete(false);
            
            modelBuilder.Entity<usr01_infopersonal>()
              .Property(e => e.usr01_id)
              .HasPrecision(18, 0);

            modelBuilder.Entity<usr02_estadocompletado>()
              .Property(e => e.usr02_id)
              .HasPrecision(18, 0);

            modelBuilder.Entity<coninf01_pasocominfo>()
               .Property(e => e.coninf01_id)
               .HasPrecision(18, 0);

            modelBuilder.Entity<con01_contacto>()
               .Property(e => e.con01_id)
               .HasPrecision(18, 0);
            
            modelBuilder.Entity<con01_contacto>()
               .Property(e => e.con02_id)
               .HasPrecision(18, 0);
            
            modelBuilder.Entity<con01_contacto>()
               .Property(e => e.con03_id)
               .HasPrecision(18, 0);

            modelBuilder.Entity<con01_contacto>()
               .Property(e => e.ser01_id)
               .HasPrecision(18, 0);

            modelBuilder.Entity<con02_tipocontacto>()
               .Property(e => e.con02_id)
               .HasPrecision(18, 0);

            modelBuilder.Entity<con03_importancia>()
               .Property(e => e.con03_id)
               .HasPrecision(18, 0);

            modelBuilder.Entity<con04_mensajepredef>()
               .Property(e => e.con04_id)
               .HasPrecision(18, 0);

            modelBuilder.Entity<con05_EstadoMensaje>()
               .Property(e => e.con05_id)
               .HasPrecision(18, 0);
            
            modelBuilder.Entity<ntf01_notificaciones>()
                .Property(e => e.ntf01_id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<cam01_campana>()
                .Property(e => e.cam01_id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<cam01_campana>()
                .Property(e => e.cnt01_id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<cam01_campana>()
                .Property(e => e.cam02_id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<cam02_tipocampana>()
                .Property(e => e.cam02_id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<cam03_detallecampana>()
                .Property(e => e.cam03_id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<cam03_detallecampana>()
                .Property(e => e.cam01_id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<cam05_configuracionadiocional>()
                .Property(e => e.cam05_id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<cam05_configuracionadiocional>()
                .Property(e => e.cam06_id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<cam06_tipoconfiguracionadicional>()
                .Property(e => e.cam06_id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<cam06_tipoconfiguracionadicional>()
                .Property(e => e.cam06_tipoelemento)
                .HasPrecision(18, 0);

            modelBuilder.Entity<cam06_tipoconfiguracionadicional>()
                .Property(e => e.cam06_estado)
                .HasPrecision(18, 0);

            modelBuilder.Entity<cam06_tipoconfiguracionadicional>()
                .HasOptional(e => e.cam05_configuracionadiocional)
                .WithRequired(e => e.cam06_tipoconfiguracionadicional);

            modelBuilder.Entity<cam07_datoSociales>()
                .Property(e => e.cam01_id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<cam07_datoSociales>()
                .Property(e => e.red01_id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<cnt01_cuenta>()
                .Property(e => e.cnt01_id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<cnt01_cuenta>()
                .Property(e => e.cnt02_id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ntf02_tiponotificacioncorreo>()
                .Property(e => e.ntf02_id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<cnt02_tipocuenta>()
                .Property(e => e.cnt02_id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<cnt03_cuenta_usuario>()
                .Property(e => e.cnt01_id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<crr01_correos>()
                .Property(e => e.crr01_id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<crr01_correos>()
                .Property(e => e.crr01_rut)
                .HasPrecision(18, 0);

            modelBuilder.Entity<crr02_tipoclasificacion>()
                .Property(e => e.crr02_id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<crr04_intereses>()
                .Property(e => e.crr04_id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<crr05_interesCorreo>()
                .Property(e => e.crr01_id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<crr05_interesCorreo>()
                .Property(e => e.crr04_id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<crr06_organizacion>()
                .Property(e => e.crr06_id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<crr07_correoOrganizacion>()
                .Property(e => e.crr01_id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<crr07_correoOrganizacion>()
                .Property(e => e.crr06_id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<lis01_lista>()
                .Property(e => e.lis01_id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<lis01_lista>()
                .Property(e => e.lis04_id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<lis02_clasificacion>()
                .Property(e => e.lis02_id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<lis04_tipolista>()
                .Property(e => e.lis04_id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<pln01_planes>()
                .Property(e => e.pln01_id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<pln01_planes>()
                .Property(e => e.pln02_id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<pln01_planes>()
                .HasMany(e => e.serv01_servicios)
                .WithOptional(e => e.pln01_planes)
                .HasForeignKey(e => e.pnl01_id);

            modelBuilder.Entity<pln01_planes>()
                 .HasMany(e => e.serv01_servicios)
                 .WithOptional(e => e.pln01_planes)
                 .HasForeignKey(e => e.pnl01_id);

            modelBuilder.Entity<pln03_tipocobro>()
                 .HasMany(e => e.pln02_tipoplan)
                 .WithOptional(e => e.pln03_tipocobro)
                 .HasForeignKey(e => e.pln03_id);

            modelBuilder.Entity<pln02_tipoplan>()
                 .HasMany(e => e.pln01_planes)
                 .WithOptional(e => e.pln02_tipoplan)
                 .HasForeignKey(e => e.pln02_id);

            modelBuilder.Entity<pln02_tipoplan>()
                .Property(e => e.pln02_id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<pln02_tipoplan>()
                .Property(e => e.pln03_id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<pln03_tipocobro>()
                .Property(e => e.pln03_id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<red01_social>()
                .Property(e => e.red01_id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<red01_social>()
                .HasMany(e => e.red02_datosContacto)
                .WithRequired(e => e.red01_social)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<red02_datosContacto>()
                .Property(e => e.red01_id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<red03_acceso>()
                .Property(e => e.red01_id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<red03_acceso>()
                .HasOptional(e => e.red02_datosContacto)
                .WithRequired(e => e.red03_acceso);

            modelBuilder.Entity<serv01_servicios>()
                .Property(e => e.ser01_id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<serv01_servicios>()
                .Property(e => e.cnt01_id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<serv01_servicios>()
                .Property(e => e.pnl01_id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<serv02_contacto>()
                .Property(e => e.ser01_id)
                .HasPrecision(18, 0);
        }
     
    }
}
