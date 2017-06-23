namespace mksolucion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class actualizacionMensajeRapidos20170622 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("con04_mensajepredef", "con04_estado", "gen01_estados");
            DropIndex("con04_mensajepredef", new[] { "con04_estado" });
            CreateTable(
                "ntf03_mensajepredef",
                c => new
                    {
                        ntf03_id = c.Decimal(nullable: false, precision: 18, scale: 0, identity: true, storeType: "numeric"),
                        ntf02_id = c.Decimal(nullable: false, precision: 18, scale: 0, storeType: "numeric"),
                        ntf03_accesoRapido = c.String(nullable: false, maxLength: 500),
                        ntf03_descripcion = c.String(),
                        ntf03_Asunto = c.String(),
                        ntf03_mensajetxt = c.String(),
                        ntf03_mensajehtml = c.String(),
                        ntf03_estado = c.Int(),
                        ntf03_fechacreacion = c.DateTime(),
                        ntf03_ultimaactualizacion = c.DateTime(),
                    })
                .PrimaryKey(t => t.ntf03_id)
                .ForeignKey("ntf02_tiponotificacioncorreo", t => t.ntf02_id)
                .ForeignKey("gen01_estados", t => t.ntf03_estado)
                .Index(t => t.ntf02_id)
                .Index(t => t.ntf03_estado);
            
            DropTable("con04_mensajepredef");
        }
        
        public override void Down()
        {
            CreateTable(
                "con04_mensajepredef",
                c => new
                    {
                        con04_id = c.Decimal(nullable: false, precision: 18, scale: 0, identity: true, storeType: "numeric"),
                        con04_accesoRapido = c.String(nullable: false, maxLength: 500),
                        con04_descripcion = c.String(),
                        con04_Asunto = c.String(),
                        con04_mensajetxt = c.String(),
                        con04_mensajehtml = c.String(),
                        con04_estado = c.Int(),
                        con04_fechacreacion = c.DateTime(),
                        con04_ultimaactualizacion = c.DateTime(),
                    })
                .PrimaryKey(t => t.con04_id);
            
            DropForeignKey("ntf03_mensajepredef", "ntf03_estado", "gen01_estados");
            DropForeignKey("ntf03_mensajepredef", "ntf02_id", "ntf02_tiponotificacioncorreo");
            DropIndex("ntf03_mensajepredef", new[] { "ntf03_estado" });
            DropIndex("ntf03_mensajepredef", new[] { "ntf02_id" });
            DropTable("ntf03_mensajepredef");
            CreateIndex("con04_mensajepredef", "con04_estado");
            AddForeignKey("con04_mensajepredef", "con04_estado", "gen01_estados", "gen01_id");
        }
    }
}
