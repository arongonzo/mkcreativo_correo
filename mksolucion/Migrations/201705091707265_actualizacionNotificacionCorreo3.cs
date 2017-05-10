namespace mksolucion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class actualizacionNotificacionCorreo3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ntf01_notificaciones", "ntf01_remitente", c => c.String(nullable: false, maxLength: 500));
            AddColumn("dbo.ntf01_notificaciones", "ntf01_destinatario", c => c.String(nullable: false, maxLength: 500));
            AddColumn("dbo.ntf01_notificaciones", "ntf01_destinatariocc", c => c.String(nullable: false, maxLength: 500));
            AddColumn("dbo.ntf01_notificaciones", "ntf02_idpadre", c => c.Decimal(precision: 18, scale: 2, storeType: "numeric"));
            AddColumn("dbo.ntf01_notificaciones", "ntf01_adjuntourl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ntf01_notificaciones", "ntf01_adjuntourl");
            DropColumn("dbo.ntf01_notificaciones", "ntf02_idpadre");
            DropColumn("dbo.ntf01_notificaciones", "ntf01_destinatariocc");
            DropColumn("dbo.ntf01_notificaciones", "ntf01_destinatario");
            DropColumn("dbo.ntf01_notificaciones", "ntf01_remitente");
        }
    }
}
