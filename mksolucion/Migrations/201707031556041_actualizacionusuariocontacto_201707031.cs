namespace mksolucion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class actualizacionusuariocontacto_201707031 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.con01_contacto", "con01_id_padre", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.con01_contacto", "con01_id_padre");
        }
    }
}
