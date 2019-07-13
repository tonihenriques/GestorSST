namespace GISCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v16 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbEquipe", "Empresa", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tbEquipe", "Empresa");
        }
    }
}
