namespace GISCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v02 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tbDocsPorAtividade", "idAtividade", c => c.String(maxLength: 128));
            CreateIndex("dbo.tbDocsPorAtividade", "idAtividade");
            AddForeignKey("dbo.tbDocsPorAtividade", "idAtividade", "dbo.tbAtividade", "IDAtividade");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbDocsPorAtividade", "idAtividade", "dbo.tbAtividade");
            DropIndex("dbo.tbDocsPorAtividade", new[] { "idAtividade" });
            AlterColumn("dbo.tbDocsPorAtividade", "idAtividade", c => c.String());
        }
    }
}
