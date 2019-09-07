namespace GISCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v_Data_AR_string : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbAnaliseRisco", "Data_Realizacao", c => c.String());
            AlterColumn("dbo.tbAnaliseRisco", "DataRealizada", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tbAnaliseRisco", "DataRealizada", c => c.DateTime(nullable: false));
            DropColumn("dbo.tbAnaliseRisco", "Data_Realizacao");
        }
    }
}
