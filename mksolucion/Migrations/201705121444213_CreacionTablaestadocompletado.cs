namespace mksolucion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreacionTablaestadocompletado : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "usr02_estadocompletado",
                c => new
                    {
                        usr02_id = c.Decimal(nullable: false, precision: 18, scale: 0, identity: true, storeType: "numeric"),
                        UserId = c.String(nullable: false, maxLength: 128),
                        usr02_confirmado = c.Int(),
                        usr02_fechacorfirmado = c.DateTime(),
                        usr02_completado = c.String(),
                        usr02_fechacompletado = c.DateTime(),
                    })
                .PrimaryKey(t => t.usr02_id)
                .ForeignKey("AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("usr02_estadocompletado", "UserId", "AspNetUsers");
            DropIndex("usr02_estadocompletado", new[] { "UserId" });
            DropTable("usr02_estadocompletado");
        }
    }
}
