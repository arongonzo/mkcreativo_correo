namespace mksolucion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class actualizacionContacto : DbMigration
    {
        public override void Up()
        {
            AddColumn("con01_contacto", "ser01_id", c => c.Decimal(precision: 18, scale: 0, storeType: "numeric"));
            CreateIndex("con01_contacto", "ser01_id");
            AddForeignKey("con01_contacto", "ser01_id", "serv01_servicios", "ser01_id");
        }
        
        public override void Down()
        {
            DropForeignKey("con01_contacto", "ser01_id", "serv01_servicios");
            DropIndex("con01_contacto", new[] { "ser01_id" });
            DropColumn("con01_contacto", "ser01_id");
        }
    }
}
