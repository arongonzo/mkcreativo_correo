namespace mksolucion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class actualizacion_remitente_contacto2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.con01_contacto", "con01_destinatario", c => c.String(maxLength: 500));
            AlterColumn("dbo.con01_contacto", "con01_emaildestinatario", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.con01_contacto", "con01_emaildestinatario", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.con01_contacto", "con01_destinatario", c => c.String(nullable: false, maxLength: 500));
        }
    }
}
