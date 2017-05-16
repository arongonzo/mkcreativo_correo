namespace mksolucion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class agregartabladatospersonales : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "usr01_infopersonal",
                c => new
                    {
                        usr01_id = c.Decimal(nullable: false, precision: 18, scale: 0, identity: true, storeType: "numeric"),
                        UserId = c.String(nullable: false, maxLength: 128),
                        usr01_nombre = c.String(nullable: false, maxLength: 500),
                        usr01_apellido = c.String(nullable: false, maxLength: 500),
                        usr01_direccion1 = c.String(nullable: false, maxLength: 500),
                        usr01_direccion2 = c.String(nullable: false, maxLength: 500),
                        usr01_ciudad = c.String(nullable: false, maxLength: 500),
                        usr01_region = c.String(nullable: false, maxLength: 500),
                        usr01_codigopostal = c.String(nullable: false, maxLength: 500),
                        usr01_Telefono = c.String(nullable: false, maxLength: 500),
                        usr01_Telefono2 = c.String(nullable: false, maxLength: 500),
                        usr01_Celular = c.String(nullable: false, maxLength: 500),
                        usr01_Celular2 = c.String(nullable: false, maxLength: 500),
                        usr01_estado = c.Int(),
                        usr01_fechacreacion = c.DateTime(),
                        usr01_ultimaactualizacion = c.DateTime(),
                    })
                .PrimaryKey(t => t.usr01_id)
                .ForeignKey("gen01_estados", t => t.usr01_estado)
                .ForeignKey("AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.usr01_estado);
            
        }
        
        public override void Down()
        {
            DropForeignKey("usr01_infopersonal", "UserId", "AspNetUsers");
            DropForeignKey("usr01_infopersonal", "usr01_estado", "gen01_estados");
            DropIndex("usr01_infopersonal", new[] { "usr01_estado" });
            DropIndex("usr01_infopersonal", new[] { "UserId" });
            DropTable("usr01_infopersonal");
        }
    }
}
