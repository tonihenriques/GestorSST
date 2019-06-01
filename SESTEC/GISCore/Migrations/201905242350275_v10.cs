namespace GISCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v10 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tbAnaliseRisco", "Conhecimento", c => c.String());
            AlterColumn("dbo.tbAnaliseRisco", "BemEstar", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tbAnaliseRisco", "BemEstar", c => c.Boolean(nullable: false));
            AlterColumn("dbo.tbAnaliseRisco", "Conhecimento", c => c.Boolean(nullable: false));
        }
    }
}
