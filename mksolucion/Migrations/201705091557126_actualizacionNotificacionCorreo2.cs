namespace mksolucion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class actualizacionNotificacionCorreo2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "ntf01_notificaciones", name: "UserId_nft01", newName: "UserId");
            RenameColumn(table: "ntf01_notificaciones", name: "ntf02_id_nft01", newName: "ntf02_id");
            RenameIndex(table: "ntf01_notificaciones", name: "IX_UserId_nft01", newName: "IX_UserId");
            RenameIndex(table: "ntf01_notificaciones", name: "IX_ntf02_id_nft01", newName: "IX_ntf02_id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "ntf01_notificaciones", name: "IX_ntf02_id", newName: "IX_ntf02_id_nft01");
            RenameIndex(table: "ntf01_notificaciones", name: "IX_UserId", newName: "IX_UserId_nft01");
            RenameColumn(table: "ntf01_notificaciones", name: "ntf02_id", newName: "ntf02_id_nft01");
            RenameColumn(table: "ntf01_notificaciones", name: "UserId", newName: "UserId_nft01");
        }
    }
}
