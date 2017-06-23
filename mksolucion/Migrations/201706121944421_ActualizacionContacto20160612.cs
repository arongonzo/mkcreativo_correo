namespace mksolucion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ActualizacionContacto20160612 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "ntf03_mensajepredef",
                c => new
                    {
                        ntf03_id = c.Decimal(nullable: false, precision: 18, scale: 0, identity: true, storeType: "numeric"),
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
                .ForeignKey("gen01_estados", t => t.ntf03_estado)
                .Index(t => t.ntf03_estado);
            
            CreateTable(
                "con05_EstadoMensaje",
                c => new
                    {
                        con05_id = c.Decimal(nullable: false, precision: 18, scale: 0, identity: true, storeType: "numeric"),
                        con05_nombre = c.String(nullable: false, maxLength: 500),
                        con05_descripcion = c.String(),
                        con05_estado = c.Int(),
                        con05_fechacreacion = c.DateTime(),
                        con05_ultimaactualizacion = c.DateTime(),
                    })
                .PrimaryKey(t => t.con05_id)
                .ForeignKey("gen01_estados", t => t.con05_estado)
                .Index(t => t.con05_estado);
            
        }
        
        public override void Down()
        {
            DropForeignKey("con05_EstadoMensaje", "con05_estado", "gen01_estados");
            DropForeignKey("ntf03_mensajepredef", "ntf03_estado", "gen01_estados");
            DropIndex("con05_EstadoMensaje", new[] { "con05_estado" });
            DropIndex("ntf03_mensajepredef", new[] { "ntf03_estado" });
            DropTable("con05_EstadoMensaje");
            DropTable("ntf03_mensajepredef");
        }
    }
}
