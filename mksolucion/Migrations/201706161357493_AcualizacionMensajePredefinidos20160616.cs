namespace mksolucion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AcualizacionMensajePredefinidos20160616 : DbMigration
    {
        public override void Up()
        {
            DropColumn("con04_mensajepredef", "con04_mesnajetxt");
            DropColumn("con04_mensajepredef", "con04_mesnajehtml");
            AddColumn("con04_mensajepredef", "con04_mensajetxt", c => c.String());
            AddColumn("con04_mensajepredef", "con04_mensajehtml", c => c.String());
            
        }
        
        public override void Down()
        {
            DropColumn("con04_mensajepredef", "con04_mensajehtml");
            DropColumn("con04_mensajepredef", "con04_mensajetxt");
            AddColumn("con04_mensajepredef", "con04_mesnajehtml", c => c.String());
            AddColumn("con04_mensajepredef", "con04_mesnajetxt", c => c.String());
            
        }
    }
}
