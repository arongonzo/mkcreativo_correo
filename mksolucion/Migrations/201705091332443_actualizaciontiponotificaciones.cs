namespace mksolucion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class actualizaciontiponotificaciones : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "ntf02_tiponotificacioncorreo",
                c => new
                    {
                        ntf02_id = c.Decimal(nullable: false, precision: 18, scale: 0, identity: true, storeType: "numeric"),
                        ntf02_nombre = c.String(nullable: false, maxLength: 500),
                        ntf02_descripcion = c.String(),
                        ntf02_estado = c.Int(),
                        ntf02_fechacreacion = c.DateTime(),
                        ntf02_ultimaactualizacion = c.DateTime(),
                    })
                .PrimaryKey(t => t.ntf02_id)
                .ForeignKey("gen01_estados", t => t.ntf02_estado)
                .Index(t => t.ntf02_estado);
            
        }
        
        public override void Down()
        {
            DropForeignKey("ntf02_tiponotificacioncorreo", "ntf02_estado", "gen01_estados");
            DropIndex("ntf02_tiponotificacioncorreo", new[] { "ntf02_estado" });
            DropTable("ntf02_tiponotificacioncorreo");
        }
    }
}
