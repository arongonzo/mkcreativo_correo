namespace mksolucion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ActualizacionTipoCuenta : DbMigration
    {
        public override void Up()
        {
            AlterColumn("cnt02_tipocuenta", "cnt02_estado", c => c.Int(nullable: false));
            CreateIndex("cnt02_tipocuenta", "cnt02_estado");
            AddForeignKey("cnt02_tipocuenta", "cnt02_estado", "gen01_estados", "gen01_id");
            
        }
        
        public override void Down()
        {
            
            DropForeignKey("cnt02_tipocuenta", "cnt02_estado", "gen01_estados");
            DropIndex("cnt02_tipocuenta", new[] { "cnt02_estado" });
            AlterColumn("cnt02_tipocuenta", "cnt02_estado", c => c.Int());
        }
    }
}
