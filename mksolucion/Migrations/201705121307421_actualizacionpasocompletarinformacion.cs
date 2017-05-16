namespace mksolucion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class actualizacionpasocompletarinformacion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "coninf01_pasocominfo",
                c => new
                    {
                        coninf01_id = c.Decimal(nullable: false, precision: 18, scale: 0, identity: true, storeType: "numeric"),
                        coninf01_nombre = c.String(maxLength: 500),
                        pln01_estado = c.Int(),
                        pln01_fechacreacion = c.DateTime(),
                        pln01_ultimaactualizacion = c.DateTime(),
                    })
                .PrimaryKey(t => t.coninf01_id);
            
        }
        
        public override void Down()
        {
            DropTable("coninf01_pasocominfo");
        }
    }
}
