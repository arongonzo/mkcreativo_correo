namespace mksolucion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ActualizacionEstadoCorreo : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("crr08_estadoCorreo");
            AddColumn("crr08_estadoCorreo", "crr08_estado", c => c.Int());
            AlterColumn("crr08_estadoCorreo", "crr08_id", c => c.Decimal(nullable: false, precision: 18, scale: 0, identity: true, storeType: "numeric"));
            AlterColumn("crr08_estadoCorreo", "crr08_nombre", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("crr08_estadoCorreo", "crr08_descripcion", c => c.String());
            AddPrimaryKey("crr08_estadoCorreo", "crr08_id");
            CreateIndex("crr08_estadoCorreo", "crr08_estado");
            AddForeignKey("crr08_estadoCorreo", "crr08_estado", "gen01_estados", "gen01_id");
        }
        
        public override void Down()
        {
            DropForeignKey("crr08_estadoCorreo", "crr08_estado", "gen01_estados");
            DropIndex("crr08_estadoCorreo", new[] { "crr08_estado" });
            DropPrimaryKey("crr08_estadoCorreo");
            AlterColumn("crr08_estadoCorreo", "crr08_descripcion", c => c.String(maxLength: 250));
            AlterColumn("crr08_estadoCorreo", "crr08_nombre", c => c.String(maxLength: 250));
            AlterColumn("crr08_estadoCorreo", "crr08_id", c => c.Int(nullable: false, identity: true));
            DropColumn("crr08_estadoCorreo", "crr08_estado");
            AddPrimaryKey("crr08_estadoCorreo", "crr08_id");
        }
    }
}
