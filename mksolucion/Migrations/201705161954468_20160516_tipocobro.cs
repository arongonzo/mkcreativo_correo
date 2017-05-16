namespace mksolucion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20160516_tipocobro : DbMigration
    {
        public override void Up()
        {
            
            CreateTable(
                "dbo.con02_tipocontacto",
                c => new
                    {
                        con02_id = c.Decimal(nullable: false, precision: 18, scale: 0, identity: true, storeType: "numeric"),
                        con02_nombre = c.String(nullable: false, maxLength: 500),
                        con02_descripcion = c.String(),
                        con02_usuariocredencial = c.String(),
                        con02_usuariocredencialclave = c.String(),
                        con02_host = c.String(),
                        con02_port = c.String(),
                        con02_ssl = c.Int(),
                        con02_estado = c.Int(),
                        con02_fechacreacion = c.DateTime(),
                        con02_ultimaactualizacion = c.DateTime(),
                    })
                .PrimaryKey(t => t.con02_id)
                .ForeignKey("dbo.gen01_estados", t => t.con02_estado)
                .Index(t => t.con02_estado);
            
            CreateTable(
                "dbo.pln03_tipocobro",
                c => new
                    {
                        pln03_id = c.Decimal(nullable: false, precision: 18, scale: 0, identity: true, storeType: "numeric"),
                        pln03_nombre = c.String(nullable: false, maxLength: 500),
                        pln03_descripcion = c.String(),
                        pln03_estado = c.Int(),
                        pln03_fechacreacion = c.DateTime(),
                        pln03_ultimaactualizacion = c.DateTime(),
                    })
                .PrimaryKey(t => t.pln03_id)
                .ForeignKey("dbo.gen01_estados", t => t.pln03_estado)
                .Index(t => t.pln03_estado);
            
            CreateTable(
                "dbo.usr01_infopersonal",
                c => new
                    {
                        usr01_id = c.Decimal(nullable: false, precision: 18, scale: 0, identity: true, storeType: "numeric"),
                        UserId = c.String(nullable: false, maxLength: 128),
                        usr01_nombre = c.String(nullable: false, maxLength: 500),
                        usr01_apellido = c.String(nullable: false, maxLength: 500),
                        usr01_direccion1 = c.String(nullable: false, maxLength: 500),
                        usr01_direccion2 = c.String(nullable: false, maxLength: 500),
                        usr01_ciudad = c.String(nullable: false, maxLength: 500),
                        usr01_region = c.String(nullable: false, maxLength: 500),
                        usr01_codigopostal = c.String(nullable: false, maxLength: 500),
                        usr01_Telefono = c.String(nullable: false, maxLength: 500),
                        usr01_Telefono2 = c.String(nullable: false, maxLength: 500),
                        usr01_Celular = c.String(nullable: false, maxLength: 500),
                        usr01_Celular2 = c.String(nullable: false, maxLength: 500),
                        usr01_estado = c.Int(),
                        usr01_fechacreacion = c.DateTime(),
                        usr01_ultimaactualizacion = c.DateTime(),
                    })
                .PrimaryKey(t => t.usr01_id)
                .ForeignKey("dbo.gen01_estados", t => t.usr01_estado)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.usr01_estado);
            
            CreateTable(
                "dbo.usr02_estadocompletado",
                c => new
                    {
                        usr02_id = c.Decimal(nullable: false, precision: 18, scale: 0, identity: true, storeType: "numeric"),
                        UserId = c.String(nullable: false, maxLength: 128),
                        usr02_confirmado = c.Int(),
                        usr02_fechacorfirmado = c.DateTime(),
                        usr02_completado = c.String(),
                        usr02_fechacompletado = c.DateTime(),
                    })
                .PrimaryKey(t => t.usr02_id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.coninf01_pasocominfo",
                c => new
                    {
                        coninf01_id = c.Decimal(nullable: false, precision: 18, scale: 0, identity: true, storeType: "numeric"),
                        coninf01_nombre = c.String(maxLength: 500),
                        coninf01_estado = c.Int(),
                        coninf01_fechacreacion = c.DateTime(),
                        coninf01_ultimaactualizacion = c.DateTime(),
                    })
                .PrimaryKey(t => t.coninf01_id);
            
            AddColumn("dbo.pln02_tipoplan", "pln03_id", c => c.Decimal(precision: 18, scale: 0, storeType: "numeric"));
            CreateIndex("dbo.pln02_tipoplan", "pln03_id");
            CreateIndex("dbo.pln02_tipoplan", "pln02_estado");
            AddForeignKey("dbo.pln02_tipoplan", "pln03_id", "dbo.pln03_tipocobro", "pln03_id");
            AddForeignKey("dbo.pln02_tipoplan", "pln02_estado", "dbo.gen01_estados", "gen01_id");
   
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.pln03_configuracion",
                c => new
                    {
                        pln01_id = c.Decimal(nullable: false, precision: 18, scale: 0, storeType: "numeric"),
                        pln04_id = c.Decimal(nullable: false, precision: 18, scale: 0, storeType: "numeric"),
                    })
                .PrimaryKey(t => new { t.pln01_id, t.pln04_id });
            
            CreateTable(
                "dbo.pln04_tipoconfiguracion",
                c => new
                    {
                        pln04_id = c.Decimal(nullable: false, precision: 18, scale: 0, identity: true, storeType: "numeric"),
                        pln04_nombre = c.String(maxLength: 500),
                        pln04_descripcion = c.String(),
                        pln04_valor = c.Decimal(precision: 18, scale: 2, storeType: "numeric"),
                        pln04_operador = c.String(maxLength: 50),
                        pln04_orden = c.String(maxLength: 50),
                        pln04_padre = c.Decimal(precision: 18, scale: 0, storeType: "numeric"),
                        pln04_estado = c.Decimal(precision: 18, scale: 0, storeType: "numeric"),
                        pln04_fechacreacion = c.DateTime(),
                        pln04_ultimaactualizacion = c.DateTime(),
                    })
                .PrimaryKey(t => t.pln04_id);
            
            DropForeignKey("dbo.usr02_estadocompletado", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.usr01_infopersonal", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.usr01_infopersonal", "usr01_estado", "dbo.gen01_estados");
            DropForeignKey("dbo.pln03_tipocobro", "pln03_estado", "dbo.gen01_estados");
            DropForeignKey("dbo.pln02_tipoplan", "pln02_estado", "dbo.gen01_estados");
            DropForeignKey("dbo.pln02_tipoplan", "pln03_id", "dbo.pln03_tipocobro");
            DropForeignKey("dbo.con02_tipocontacto", "con02_estado", "dbo.gen01_estados");
            DropIndex("dbo.usr02_estadocompletado", new[] { "UserId" });
            DropIndex("dbo.usr01_infopersonal", new[] { "usr01_estado" });
            DropIndex("dbo.usr01_infopersonal", new[] { "UserId" });
            DropIndex("dbo.pln03_tipocobro", new[] { "pln03_estado" });
            DropIndex("dbo.pln02_tipoplan", new[] { "pln02_estado" });
            DropIndex("dbo.pln02_tipoplan", new[] { "pln03_id" });
            DropIndex("dbo.con02_tipocontacto", new[] { "con02_estado" });
            DropColumn("dbo.pln02_tipoplan", "pln03_id");
            DropTable("dbo.coninf01_pasocominfo");
            DropTable("dbo.usr02_estadocompletado");
            DropTable("dbo.usr01_infopersonal");
            DropTable("dbo.pln03_tipocobro");
            DropTable("dbo.con02_tipocontacto");
            CreateIndex("dbo.pln03_configuracion", "pln04_id");
            CreateIndex("dbo.pln03_configuracion", "pln01_id");
            AddForeignKey("dbo.pln03_configuracion", "pln04_id", "dbo.pln04_tipoconfiguracion", "pln04_id", cascadeDelete: true);
            AddForeignKey("dbo.pln03_configuracion", "pln01_id", "dbo.pln01_planes", "pln01_id", cascadeDelete: true);
        }
    }
}
