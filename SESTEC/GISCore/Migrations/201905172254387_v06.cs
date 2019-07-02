namespace GISCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v06 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbAtividadeFuncaoLiberada",
                c => new
                    {
                        IDAtividadeFuncaoLiberada = c.String(nullable: false, maxLength: 128),
                        IDFuncao = c.String(maxLength: 128),
                        IDAtividade = c.String(maxLength: 128),
                        IDAlocacao = c.String(maxLength: 128),
                        UsuarioInclusao = c.String(),
                        DataInclusao = c.DateTime(nullable: false),
                        UsuarioExclusao = c.String(),
                        DataExclusao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IDAtividadeFuncaoLiberada)
                .ForeignKey("dbo.tbAlocacao", t => t.IDAlocacao)
                .ForeignKey("dbo.tbAtividade", t => t.IDAtividade)
                .ForeignKey("dbo.tbFuncao", t => t.IDFuncao)
                .Index(t => t.IDFuncao)
                .Index(t => t.IDAtividade)
                .Index(t => t.IDAlocacao);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbAtividadeFuncaoLiberada", "IDFuncao", "dbo.tbFuncao");
            DropForeignKey("dbo.tbAtividadeFuncaoLiberada", "IDAtividade", "dbo.tbAtividade");
            DropForeignKey("dbo.tbAtividadeFuncaoLiberada", "IDAlocacao", "dbo.tbAlocacao");
            DropIndex("dbo.tbAtividadeFuncaoLiberada", new[] { "IDAlocacao" });
            DropIndex("dbo.tbAtividadeFuncaoLiberada", new[] { "IDAtividade" });
            DropIndex("dbo.tbAtividadeFuncaoLiberada", new[] { "IDFuncao" });
            DropTable("dbo.tbAtividadeFuncaoLiberada");
        }
    }
}
