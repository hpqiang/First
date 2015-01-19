namespace LNDLWcfService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LNDLWcfServiceCodeFirstDALHywinContext : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Office", "buildingName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Office", "buildingName");
        }
    }
}
