namespace GISCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v018 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rel_EquipeAspectoResposta", "idAspecto", "dbo.tbAspecto");
            DropForeignKey("dbo.Rel_EquipeAspectoResposta", "idPergunta", "dbo.tbPergunta");
            DropIndex("dbo.Rel_EquipeAspectoResposta", new[] { "idAspecto" });
            DropIndex("dbo.Rel_EquipeAspectoResposta", new[] { "idPergunta" });
            AddColumn("dbo.Rel_EquipeAspectoResposta", "idAspectoPergunta", c => c.String(maxLength: 128));
            AlterColumn("dbo.Rel_EquipeAspectoResposta", "idAspecto", c => c.String());
            AlterColumn("dbo.Rel_EquipeAspectoResposta", "idPergunta", c => c.String());
            CreateIndex("dbo.Rel_EquipeAspectoResposta", "idAspectoPergunta");
            AddForeignKey("dbo.Rel_EquipeAspectoResposta", "idAspectoPergunta", "dbo.Rel_AspectoPergunta", "IDAspectoPergunta");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rel_EquipeAspectoResposta", "idAspectoPergunta", "dbo.Rel_AspectoPergunta");
            DropIndex("dbo.Rel_EquipeAspectoResposta", new[] { "idAspectoPergunta" });
            AlterColumn("dbo.Rel_EquipeAspectoResposta", "idPergunta", c => c.String(maxLength: 128));
            AlterColumn("dbo.Rel_EquipeAspectoResposta", "idAspecto", c => c.String(maxLength: 128));
            DropColumn("dbo.Rel_EquipeAspectoResposta", "idAspectoPergunta");
            CreateIndex("dbo.Rel_EquipeAspectoResposta", "idPergunta");
            CreateIndex("dbo.Rel_EquipeAspectoResposta", "idAspecto");
            AddForeignKey("dbo.Rel_EquipeAspectoResposta", "idPergunta", "dbo.tbPergunta", "IDPergunta");
            AddForeignKey("dbo.Rel_EquipeAspectoResposta", "idAspecto", "dbo.tbAspecto", "IDAspecto");
        }
    }
}
