namespace mksolucion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class creacionareasegmento : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "crr03_areasegmento",
                c => new
                    {
                        crr03_id = c.Decimal(nullable: false, precision: 18, scale: 0, identity: true, storeType: "numeric"),
                        crr03_nombre = c.String(nullable: false, maxLength: 500),
                        crr03_descripcion = c.String(),
                        crr03_estado = c.Int(),
                        crr03_fechacreacion = c.DateTime(),
                        crr03_ultimaactualizacion = c.DateTime(),
                    })
                .PrimaryKey(t => t.crr03_id)
                .ForeignKey("gen01_estados", t => t.crr03_estado)
                .Index(t => t.crr03_estado);
            
        }
        
        public override void Down()
        {
            DropForeignKey("crr03_areasegmento", "crr03_estado", "gen01_estados");
            DropIndex("crr03_areasegmento", new[] { "crr03_estado" });
            DropTable("crr03_areasegmento");
        }
    }
}
