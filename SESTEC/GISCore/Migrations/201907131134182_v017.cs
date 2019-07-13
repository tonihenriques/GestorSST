namespace GISCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v017 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbAspecto", "DescricaoAspecto", c => c.String());
            DropColumn("dbo.tbAspecto", "ConteudoTrabalho");
            DropColumn("dbo.tbAspecto", "CargaRitmo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tbAspecto", "CargaRitmo", c => c.String());
            AddColumn("dbo.tbAspecto", "ConteudoTrabalho", c => c.String());
            DropColumn("dbo.tbAspecto", "DescricaoAspecto");
        }
    }
}
