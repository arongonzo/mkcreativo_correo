namespace mksolucion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class actualizacion_cuentaCliente_20170601 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("cnt01_cuenta", "cnt01_nombre", c => c.String(nullable: false, maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("cnt01_cuenta", "cnt01_nombre", c => c.String(maxLength: 500));
        }
    }
}
