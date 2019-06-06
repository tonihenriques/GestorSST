namespace GISCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v12 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbAnaliseRisco", "RiscoAdicional", c => c.String());
            AddColumn("dbo.tbAnaliseRisco", "ControleProposto", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tbAnaliseRisco", "ControleProposto");
            DropColumn("dbo.tbAnaliseRisco", "RiscoAdicional");
        }
    }
}
