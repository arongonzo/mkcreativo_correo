namespace mksolucion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class actualizacion_remitente_contacto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.con01_contacto", "con01_destinatario", c => c.String(nullable: false, maxLength: 500));
            AddColumn("dbo.con01_contacto", "con01_emaildestinatario", c => c.String(nullable: false, maxLength: 500));
        }
        
        public override void Down()
        {
            DropColumn("dbo.con01_contacto", "con01_emaildestinatario");
            DropColumn("dbo.con01_contacto", "con01_destinatario");
        }
    }
}
