namespace mksolucion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20160516_tipocobro : DbMigration
    {
        public override void Up()
        {
            
            CreateTable(
                "con02_tipocontacto",
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
                .ForeignKey("gen01_estados", t => t.con02_estado)
                .Index(t => t.con02_estado);
            
            CreateTable(
                "pln03_tipocobro",
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
                .ForeignKey("gen01_estados", t => t.pln03_estado)
                .Index(t => t.pln03_estado);
            
            CreateTable(
                "usr01_infopersonal",
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
                .ForeignKey("gen01_estados", t => t.usr01_estado)
                .ForeignKey("AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.usr01_estado);
            
            CreateTable(
                "usr02_estadocompletado",
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
                .ForeignKey("AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "coninf01_pasocominfo",
                c => new
                    {
                        coninf01_id = c.Decimal(nullable: false, precision: 18, scale: 0, identity: true, storeType: "numeric"),
                        coninf01_nombre = c.String(maxLength: 500),
                        coninf01_estado = c.Int(),
                        coninf01_fechacreacion = c.DateTime(),
                        coninf01_ultimaactualizacion = c.DateTime(),
                    })
                .PrimaryKey(t => t.coninf01_id);
            
            AddColumn("pln02_tipoplan", "pln03_id", c => c.Decimal(precision: 18, scale: 0, storeType: "numeric"));
            CreateIndex("pln02_tipoplan", "pln03_id");
            CreateIndex("pln02_tipoplan", "pln02_estado");
            AddForeignKey("pln02_tipoplan", "pln03_id", "pln03_tipocobro", "pln03_id");
            AddForeignKey("pln02_tipoplan", "pln02_estado", "gen01_estados", "gen01_id");
   
        }
        
        public override void Down()
        {
            CreateTable(
                "pln03_configuracion",
                c => new
                    {
                        pln01_id = c.Decimal(nullable: false, precision: 18, scale: 0, storeType: "numeric"),
                        pln04_id = c.Decimal(nullable: false, precision: 18, scale: 0, storeType: "numeric"),
                    })
                .PrimaryKey(t => new { t.pln01_id, t.pln04_id });
            
            CreateTable(
                "pln04_tipoconfiguracion",
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
            
            DropForeignKey("usr02_estadocompletado", "UserId", "AspNetUsers");
            DropForeignKey("usr01_infopersonal", "UserId", "AspNetUsers");
            DropForeignKey("usr01_infopersonal", "usr01_estado", "gen01_estados");
            DropForeignKey("pln03_tipocobro", "pln03_estado", "gen01_estados");
            DropForeignKey("pln02_tipoplan", "pln02_estado", "gen01_estados");
            DropForeignKey("pln02_tipoplan", "pln03_id", "pln03_tipocobro");
            DropForeignKey("con02_tipocontacto", "con02_estado", "gen01_estados");
            DropIndex("usr02_estadocompletado", new[] { "UserId" });
            DropIndex("usr01_infopersonal", new[] { "usr01_estado" });
            DropIndex("usr01_infopersonal", new[] { "UserId" });
            DropIndex("pln03_tipocobro", new[] { "pln03_estado" });
            DropIndex("pln02_tipoplan", new[] { "pln02_estado" });
            DropIndex("pln02_tipoplan", new[] { "pln03_id" });
            DropIndex("con02_tipocontacto", new[] { "con02_estado" });
            DropColumn("pln02_tipoplan", "pln03_id");
            DropTable("coninf01_pasocominfo");
            DropTable("usr02_estadocompletado");
            DropTable("usr01_infopersonal");
            DropTable("pln03_tipocobro");
            DropTable("con02_tipocontacto");
            CreateIndex("pln03_configuracion", "pln04_id");
            CreateIndex("pln03_configuracion", "pln01_id");
            AddForeignKey("pln03_configuracion", "pln04_id", "pln04_tipoconfiguracion", "pln04_id", cascadeDelete: true);
            AddForeignKey("pln03_configuracion", "pln01_id", "pln01_planes", "pln01_id", cascadeDelete: true);
        }
    }
}
