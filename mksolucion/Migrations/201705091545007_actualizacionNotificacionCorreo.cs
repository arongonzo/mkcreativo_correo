namespace mksolucion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class actualizacionNotificacionCorreo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "ntf01_notificaciones",
                c => new
                    {
                        ntf01_id = c.Decimal(nullable: false, precision: 18, scale: 0, identity: true, storeType: "numeric"),
                        UserId_nft01 = c.String(nullable: false, maxLength: 128),
                        ntf02_id_nft01 = c.Decimal(nullable: false, precision: 18, scale: 0, storeType: "numeric"),
                        ntf02_fechaenvio = c.DateTime(),
                        ntf01_asunto = c.String(nullable: false, maxLength: 500),
                        ntf01_contenido = c.String(),
                        ntf01_estado = c.Int(),
                    })
                .PrimaryKey(t => t.ntf01_id)
                .ForeignKey("ntf02_tiponotificacioncorreo", t => t.ntf02_id_nft01)
                .ForeignKey("AspNetUsers", t => t.UserId_nft01)
                .Index(t => t.UserId_nft01)
                .Index(t => t.ntf02_id_nft01);
            
        }
        
        public override void Down()
        {
            DropForeignKey("ntf01_notificaciones", "UserId_nft01", "AspNetUsers");
            DropForeignKey("ntf01_notificaciones", "ntf02_id_nft01", "ntf02_tiponotificacioncorreo");
            DropIndex("ntf01_notificaciones", new[] { "ntf02_id_nft01" });
            DropIndex("ntf01_notificaciones", new[] { "UserId_nft01" });
            DropTable("ntf01_notificaciones");
        }
    }
}
