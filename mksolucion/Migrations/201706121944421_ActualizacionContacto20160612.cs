namespace mksolucion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ActualizacionContacto20160612 : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.con04_id)
                .ForeignKey("gen01_estados", t => t.con04_estado)
                .Index(t => t.con04_estado);
            
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
            DropForeignKey("con04_mensajepredef", "con04_estado", "gen01_estados");
            DropIndex("con05_EstadoMensaje", new[] { "con05_estado" });
            DropIndex("con04_mensajepredef", new[] { "con04_estado" });
            DropTable("con05_EstadoMensaje");
            DropTable("con04_mensajepredef");
        }
    }
}
