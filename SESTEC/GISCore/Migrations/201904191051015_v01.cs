namespace GISCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v01 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tbDocsPorAtividade", "IDAtividade", "dbo.tbAtividade");
            DropIndex("dbo.tbDocsPorAtividade", new[] { "IDAtividade" });
            DropIndex("dbo.tbDocsPorAtividade", new[] { "IDDocumentosEmpregado" });
            CreateTable(
                "dbo.tbDocAtividade",
                c => new
                    {
                        IDDocAtividade = c.String(nullable: false, maxLength: 128),
                        IDUniqueKey = c.String(),
                        IDDocumentosEmpregado = c.String(maxLength: 128),
                        UsuarioInclusao = c.String(),
                        DataInclusao = c.DateTime(nullable: false),
                        UsuarioExclusao = c.String(),
                        DataExclusao = c.DateTime(nullable: false),
                        UniqueKey_IDAtividade = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.IDDocAtividade)
                .ForeignKey("dbo.tbDocumentosPessoal", t => t.IDDocumentosEmpregado)
                .ForeignKey("dbo.tbAtividade", t => t.UniqueKey_IDAtividade)
                .Index(t => t.IDDocumentosEmpregado)
                .Index(t => t.UniqueKey_IDAtividade);
            
            AlterColumn("dbo.tbDocsPorAtividade", "idAtividade", c => c.String());
            CreateIndex("dbo.tbDocsPorAtividade", "idDocumentosEmpregado");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbDocAtividade", "UniqueKey_IDAtividade", "dbo.tbAtividade");
            DropForeignKey("dbo.tbDocAtividade", "IDDocumentosEmpregado", "dbo.tbDocumentosPessoal");
            DropIndex("dbo.tbDocsPorAtividade", new[] { "idDocumentosEmpregado" });
            DropIndex("dbo.tbDocAtividade", new[] { "UniqueKey_IDAtividade" });
            DropIndex("dbo.tbDocAtividade", new[] { "IDDocumentosEmpregado" });
            AlterColumn("dbo.tbDocsPorAtividade", "idAtividade", c => c.String(maxLength: 128));
            DropTable("dbo.tbDocAtividade");
            CreateIndex("dbo.tbDocsPorAtividade", "IDDocumentosEmpregado");
            CreateIndex("dbo.tbDocsPorAtividade", "IDAtividade");
            AddForeignKey("dbo.tbDocsPorAtividade", "IDAtividade", "dbo.tbAtividade", "IDAtividade");
        }
    }
}
