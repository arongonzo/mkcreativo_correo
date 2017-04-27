namespace mksolucion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ActualizacionCuentaUsuario : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("cnt03_cuenta_usuario");
            AlterColumn("cnt03_cuenta_usuario", "UserId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("cnt03_cuenta_usuario", new[] { "cnt01_id", "UserId" });
            CreateIndex("cnt03_cuenta_usuario", "UserId");
            AddForeignKey("cnt03_cuenta_usuario", "UserId", "AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("cnt03_cuenta_usuario", "UserId", "AspNetUsers");
            DropIndex("cnt03_cuenta_usuario", new[] { "UserId" });
            DropPrimaryKey("cnt03_cuenta_usuario");
            AlterColumn("cnt03_cuenta_usuario", "UserId", c => c.Guid(nullable: false));
            AddPrimaryKey("cnt03_cuenta_usuario", new[] { "cnt01_id", "UserId" });
        }
    }
}
