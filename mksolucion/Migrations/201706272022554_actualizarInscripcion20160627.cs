namespace mksolucion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class actualizarInscripcion20160627 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "ins01_inscripcion",
                c => new
                    {
                        ins01_id = c.Decimal(nullable: false, precision: 18, scale: 0, identity: true, storeType: "numeric"),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ins01_nombreusuario = c.String(),
                        ins01_claveacceso = c.String(),
                        ins01_estado = c.Int(),
                        ins01_fechacreacion = c.DateTime(),
                        ins01_fechaactivacion = c.DateTime(),
                    })
                .PrimaryKey(t => t.ins01_id)
                .ForeignKey("gen01_estados", t => t.ins01_estado)
                .ForeignKey("AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.ins01_estado);
            
        }
        
        public override void Down()
        {
            DropForeignKey("ins01_inscripcion", "UserId", "AspNetUsers");
            DropForeignKey("ins01_inscripcion", "ins01_estado", "gen01_estados");
            DropIndex("ins01_inscripcion", new[] { "ins01_estado" });
            DropIndex("ins01_inscripcion", new[] { "UserId" });
            DropTable("ins01_inscripcion");
        }
    }
}
