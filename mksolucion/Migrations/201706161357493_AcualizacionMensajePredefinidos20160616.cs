namespace mksolucion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AcualizacionMensajePredefinidos20160616 : DbMigration
    {
        public override void Up()
        {
            DropColumn("ntf03_mensajepredef", "ntf03_mesnajetxt");
            DropColumn("ntf03_mensajepredef", "ntf03_mesnajehtml");
            AddColumn("ntf03_mensajepredef", "ntf03_mensajetxt", c => c.String());
            AddColumn("ntf03_mensajepredef", "ntf03_mensajehtml", c => c.String());
            
        }
        
        public override void Down()
        {
            DropColumn("ntf03_mensajepredef", "ntf03_mensajehtml");
            DropColumn("ntf03_mensajepredef", "ntf03_mensajetxt");
            AddColumn("ntf03_mensajepredef", "ntf03_mesnajehtml", c => c.String());
            AddColumn("ntf03_mensajepredef", "ntf03_mesnajetxt", c => c.String());
            
        }
    }
}
