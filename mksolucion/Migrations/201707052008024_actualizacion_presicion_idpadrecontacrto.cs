namespace mksolucion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class actualizacion_presicion_idpadrecontacrto : DbMigration
    {
        public override void Up()
        {
            AlterColumn("con01_contacto", "con01_id_padre", c => c.Decimal(precision: 18, scale: 0));
        }
        
        public override void Down()
        {
            AlterColumn("con01_contacto", "con01_id_padre", c => c.Decimal(precision: 18, scale: 2));
        }
    }
}
