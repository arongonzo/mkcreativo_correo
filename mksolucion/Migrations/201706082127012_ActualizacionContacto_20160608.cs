namespace mksolucion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ActualizacionContacto_20160608 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "con03_importancia",
                c => new
                {
                    con03_id = c.Decimal(nullable: false, precision: 18, scale: 0, identity: true, storeType: "numeric"),
                    con03_nombre = c.String(nullable: false, maxLength: 500),
                    con03_descripcion = c.String(),
                    con03_estado = c.Int(),
                    con03_fechacreacion = c.DateTime(),
                    con03_ultimaactualizacion = c.DateTime(),
                })
                .PrimaryKey(t => t.con03_id)
                .ForeignKey("gen01_estados", t => t.con03_estado)
                .Index(t => t.con03_estado);

            CreateTable(
                "con01_contacto",
                c => new
                    {
                        con01_id = c.Decimal(nullable: false, precision: 18, scale: 0, identity: true, storeType: "numeric"),
                        con01_nombre = c.String(nullable: false, maxLength: 500),
                        con01_email = c.String(nullable: false, maxLength: 500),
                        con01_asunto = c.String(nullable: false, maxLength: 500),
                        con02_id = c.Decimal(nullable: false, precision: 18, scale: 0, storeType: "numeric"),
                        con03_id = c.Decimal(nullable: false, precision: 18, scale: 0, storeType: "numeric"),
                        con01_mensaje = c.String(),
                        con01_adjunto = c.String(),
                        con01_estado = c.Int(),
                        con01_fechacreacion = c.DateTime(),
                        con01_ultimaactualizacion = c.DateTime(),
                    })
                .PrimaryKey(t => t.con01_id)
                .ForeignKey("con02_tipocontacto", t => t.con02_id)
                .ForeignKey("con03_importancia", t => t.con03_id)
                .ForeignKey("gen01_estados", t => t.con01_estado)
                .Index(t => t.con02_id)
                .Index(t => t.con03_id)
                .Index(t => t.con01_estado);
            
            
            
        }
        
        public override void Down()
        {
            DropForeignKey("con03_importancia", "con03_estado", "gen01_estados");
            DropForeignKey("con01_contacto", "con01_estado", "gen01_estados");
            DropForeignKey("con01_contacto", "con03_id", "con03_importancia");
            DropForeignKey("con01_contacto", "con02_id", "con02_tipocontacto");
            DropIndex("con03_importancia", new[] { "con03_estado" });
            DropIndex("con01_contacto", new[] { "con01_estado" });
            DropIndex("con01_contacto", new[] { "con03_id" });
            DropIndex("con01_contacto", new[] { "con02_id" });
            DropTable("con03_importancia");
            DropTable("con01_contacto");
        }
    }
}
