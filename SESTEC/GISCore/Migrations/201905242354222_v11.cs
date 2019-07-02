namespace GISCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v11 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tbAnaliseRisco", "Conhecimento", c => c.Boolean(nullable: false));
            AlterColumn("dbo.tbAnaliseRisco", "BemEstar", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tbAnaliseRisco", "BemEstar", c => c.String());
            AlterColumn("dbo.tbAnaliseRisco", "Conhecimento", c => c.String());
        }
    }
}
