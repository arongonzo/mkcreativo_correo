namespace mksolucion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class actualizacion_vista_serviciousuario_20170703 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.v_ServicioUsuario",
                c => new
                    {
                        ser01_id = c.Decimal(nullable: false, precision: 18, scale: 0, storeType: "numeric"),
                        pln01_nombre = c.String(nullable: false, maxLength: 500),
                        cnt01_id = c.Decimal(nullable: false, precision: 18, scale: 0, storeType: "numeric"),
                        pln03_id = c.Decimal(nullable: false, precision: 18, scale: 0, storeType: "numeric"),
                        pln03_nombre = c.String(nullable: false, maxLength: 500),
                        cnt02_id = c.Decimal(nullable: false, precision: 18, scale: 0, storeType: "numeric"),
                        cnt02_nombre = c.String(nullable: false, maxLength: 500),
                        cnt02_estado = c.Int(nullable: false),
                        Id = c.String(nullable: false, maxLength: 128),
                        UserName = c.String(nullable: false, maxLength: 256),
                        pnl01_id = c.Decimal(precision: 18, scale: 0, storeType: "numeric"),
                        ser01_estado = c.Int(),
                        ser01_fechacreacion = c.DateTime(),
                        ser01_ultimaactualizacion = c.DateTime(),
                        pln02_id = c.Decimal(precision: 18, scale: 0, storeType: "numeric"),
                        pln01_detalle = c.String(),
                        pln01_html = c.String(),
                        pln01_activo = c.Int(),
                        pln01_fechacreacion = c.DateTime(),
                        pln01_ultimaactualizacion = c.DateTime(),
                        pln02_nombre = c.String(maxLength: 500),
                        pln02_descripcion = c.String(),
                        pln02_estado = c.Int(),
                        pln03_estado = c.Int(),
                    })
                .PrimaryKey(t => new { t.ser01_id, t.pln01_nombre, t.cnt01_id, t.pln03_id, t.pln03_nombre, t.cnt02_id, t.cnt02_nombre, t.cnt02_estado, t.Id, t.UserName });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.v_ServicioUsuario");
        }
    }
}
