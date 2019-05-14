namespace GISCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v_03 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbTipoDeRisco", "idAtividade", c => c.String(maxLength: 128));
            CreateIndex("dbo.tbTipoDeRisco", "idAtividade");
            AddForeignKey("dbo.tbTipoDeRisco", "idAtividade", "dbo.tbAtividade", "IDAtividade");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbTipoDeRisco", "idAtividade", "dbo.tbAtividade");
            DropIndex("dbo.tbTipoDeRisco", new[] { "idAtividade" });
            DropColumn("dbo.tbTipoDeRisco", "idAtividade");
        }
    }
}
