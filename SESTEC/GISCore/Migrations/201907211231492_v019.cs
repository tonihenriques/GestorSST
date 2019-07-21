namespace GISCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v019 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Rel_EquipeAspectoResposta", "idAspecto");
            DropColumn("dbo.Rel_EquipeAspectoResposta", "idPergunta");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rel_EquipeAspectoResposta", "idPergunta", c => c.String());
            AddColumn("dbo.Rel_EquipeAspectoResposta", "idAspecto", c => c.String());
        }
    }
}
