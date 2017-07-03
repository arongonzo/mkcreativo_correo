namespace mksolucion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class actualizacionusuariocontacto_20170703 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.con01_contacto", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.con01_contacto", "UserId");
        }
    }
}
