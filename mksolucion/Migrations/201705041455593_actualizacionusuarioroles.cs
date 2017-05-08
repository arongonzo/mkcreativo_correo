namespace mksolucion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class actualizacionusuarioroles : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("AspNetUserRoles", "RoleId", "AspNetRoles");
            DropForeignKey("AspNetUserRoles", "UserId", "AspNetUsers");
            DropTable("AspNetUserRoles");
            CreateTable(
                "AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("AspNetUsers", t => t.UserId)
                .ForeignKey("AspNetRoles", t => t.RoleId);
            
           
        }
        
        public override void Down()
        {
            DropForeignKey("AspNetUserRoles", "RoleId", "AspNetRoles");
            DropForeignKey("AspNetUserRoles", "UserId", "AspNetUsers");
            DropTable("AspNetUserRoles");
            CreateTable(
                "AspNetUserRoles",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId });
            
            
            AddForeignKey("AspNetUserRoles", "UserId", "AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("AspNetUserRoles", "RoleId", "AspNetRoles", "Id", cascadeDelete: true);
        }
    }
}
