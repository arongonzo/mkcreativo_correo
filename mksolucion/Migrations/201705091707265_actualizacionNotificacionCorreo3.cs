namespace mksolucion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class actualizacionNotificacionCorreo3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("ntf01_notificaciones", "ntf01_remitente", c => c.String(nullable: false, maxLength: 500));
            AddColumn("ntf01_notificaciones", "ntf01_destinatario", c => c.String(nullable: false, maxLength: 500));
            AddColumn("ntf01_notificaciones", "ntf01_destinatariocc", c => c.String(nullable: false, maxLength: 500));
            AddColumn("ntf01_notificaciones", "ntf02_idpadre", c => c.Decimal(precision: 18, scale: 2, storeType: "numeric"));
            AddColumn("ntf01_notificaciones", "ntf01_adjuntourl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("ntf01_notificaciones", "ntf01_adjuntourl");
            DropColumn("ntf01_notificaciones", "ntf02_idpadre");
            DropColumn("ntf01_notificaciones", "ntf01_destinatariocc");
            DropColumn("ntf01_notificaciones", "ntf01_destinatario");
            DropColumn("ntf01_notificaciones", "ntf01_remitente");
        }
    }
}
