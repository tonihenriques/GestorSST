namespace GISCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v14 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbAspecto",
                c => new
                    {
                        IDAspecto = c.String(nullable: false, maxLength: 128),
                        ConteudoTrabalho = c.String(),
                        CargaRitmo = c.String(),
                        UsuarioInclusao = c.String(),
                        DataInclusao = c.DateTime(nullable: false),
                        UsuarioExclusao = c.String(),
                        DataExclusao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IDAspecto);
            
            CreateTable(
                "dbo.Rel_AspectoPergunta",
                c => new
                    {
                        IDAspectoPergunta = c.String(nullable: false, maxLength: 128),
                        idAspecto = c.String(maxLength: 128),
                        idPergunta = c.String(maxLength: 128),
                        UsuarioInclusao = c.String(),
                        DataInclusao = c.DateTime(nullable: false),
                        UsuarioExclusao = c.String(),
                        DataExclusao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IDAspectoPergunta)
                .ForeignKey("dbo.tbAspecto", t => t.idAspecto)
                .ForeignKey("dbo.tbPergunta", t => t.idPergunta)
                .Index(t => t.idAspecto)
                .Index(t => t.idPergunta);
            
            CreateTable(
                "dbo.tbPergunta",
                c => new
                    {
                        IDPergunta = c.String(nullable: false, maxLength: 128),
                        Item = c.String(),
                        Descricao = c.String(),
                        UsuarioInclusao = c.String(),
                        DataInclusao = c.DateTime(nullable: false),
                        UsuarioExclusao = c.String(),
                        DataExclusao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IDPergunta);
            
            CreateTable(
                "dbo.Rel_EquipeAspectoResposta",
                c => new
                    {
                        IDEquipeAspecto = c.String(nullable: false, maxLength: 128),
                        idEquipe = c.String(maxLength: 128),
                        idAspecto = c.String(maxLength: 128),
                        UsuarioInclusao = c.String(),
                        DataInclusao = c.DateTime(nullable: false),
                        UsuarioExclusao = c.String(),
                        DataExclusao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IDEquipeAspecto)
                .ForeignKey("dbo.tbAspecto", t => t.idAspecto)
                .ForeignKey("dbo.tbEquipe", t => t.idEquipe)
                .Index(t => t.idEquipe)
                .Index(t => t.idAspecto);
            
            AddColumn("dbo.tbEquipe", "Processo", c => c.String());
            AddColumn("dbo.tbEquipe", "LocalTrablho", c => c.String());
            AddColumn("dbo.tbEquipe", "Departamento", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rel_EquipeAspectoResposta", "idEquipe", "dbo.tbEquipe");
            DropForeignKey("dbo.Rel_EquipeAspectoResposta", "idAspecto", "dbo.tbAspecto");
            DropForeignKey("dbo.Rel_AspectoPergunta", "idPergunta", "dbo.tbPergunta");
            DropForeignKey("dbo.Rel_AspectoPergunta", "idAspecto", "dbo.tbAspecto");
            DropIndex("dbo.Rel_EquipeAspectoResposta", new[] { "idAspecto" });
            DropIndex("dbo.Rel_EquipeAspectoResposta", new[] { "idEquipe" });
            DropIndex("dbo.Rel_AspectoPergunta", new[] { "idPergunta" });
            DropIndex("dbo.Rel_AspectoPergunta", new[] { "idAspecto" });
            DropColumn("dbo.tbEquipe", "Departamento");
            DropColumn("dbo.tbEquipe", "LocalTrablho");
            DropColumn("dbo.tbEquipe", "Processo");
            DropTable("dbo.Rel_EquipeAspectoResposta");
            DropTable("dbo.tbPergunta");
            DropTable("dbo.Rel_AspectoPergunta");
            DropTable("dbo.tbAspecto");
        }
    }
}
