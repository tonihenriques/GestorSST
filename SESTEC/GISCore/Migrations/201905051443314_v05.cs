namespace GISCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v05 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbAtividade", "NomeDaImagem", c => c.String());
            AddColumn("dbo.tbAtividade", "Imagem", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tbAtividade", "Imagem");
            DropColumn("dbo.tbAtividade", "NomeDaImagem");
        }
    }
}
