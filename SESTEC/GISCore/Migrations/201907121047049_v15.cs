namespace GISCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v15 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rel_EquipeAspectoResposta", "idPergunta", c => c.String(maxLength: 128));
            AddColumn("dbo.Rel_EquipeAspectoResposta", "Sim_Nao", c => c.Boolean(nullable: false));
            CreateIndex("dbo.Rel_EquipeAspectoResposta", "idPergunta");
            AddForeignKey("dbo.Rel_EquipeAspectoResposta", "idPergunta", "dbo.tbPergunta", "IDPergunta");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rel_EquipeAspectoResposta", "idPergunta", "dbo.tbPergunta");
            DropIndex("dbo.Rel_EquipeAspectoResposta", new[] { "idPergunta" });
            DropColumn("dbo.Rel_EquipeAspectoResposta", "Sim_Nao");
            DropColumn("dbo.Rel_EquipeAspectoResposta", "idPergunta");
        }
    }
}
