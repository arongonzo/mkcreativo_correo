namespace mksolucion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class actualizacionusuariocontacto_201707032 : DbMigration
    {
        public override void Up()
        {
            AddColumn("con01_contacto", "con05_id", c => c.Decimal(nullable: false, precision: 18, scale: 0, storeType: "numeric"));
            CreateIndex("con01_contacto", "con05_id");
            AddForeignKey("con01_contacto", "con05_id", "con05_EstadoMensaje", "con05_id");
        }
        
        public override void Down()
        {
            DropForeignKey("con01_contacto", "con05_id", "con05_EstadoMensaje");
            DropIndex("con01_contacto", new[] { "con05_id" });
            DropColumn("con01_contacto", "con05_id");
        }
    }
}
