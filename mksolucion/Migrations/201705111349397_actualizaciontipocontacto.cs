namespace mksolucion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class actualizaciontipocontacto : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "con02_tipocontacto",
                c => new
                    {
                        con02_id = c.Decimal(nullable: false, precision: 18, scale: 0, identity: true, storeType: "numeric"),
                        con02_nombre = c.String(nullable: false, maxLength: 500),
                        con02_descripcion = c.String(),
                        con02_usuariocredencial = c.String(),
                        con02_usuariocredencialclave = c.String(),
                        con02_host = c.String(),
                        con02_port = c.String(),
                        con02_ssl = c.Int(),
                        con02_estado = c.Int(),
                        con02_fechacreacion = c.DateTime(),
                        con02_ultimaactualizacion = c.DateTime(),
                    })
                .PrimaryKey(t => t.con02_id)
                .ForeignKey("gen01_estados", t => t.con02_estado)
                .Index(t => t.con02_estado);
            
        }
        
        public override void Down()
        {
            DropForeignKey("con02_tipocontacto", "con02_estado", "gen01_estados");
            DropIndex("con02_tipocontacto", new[] { "con02_estado" });
            DropTable("con02_tipocontacto");
        }
    }
}
