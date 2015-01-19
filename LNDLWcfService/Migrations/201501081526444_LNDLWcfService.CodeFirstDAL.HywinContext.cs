namespace LNDLWcfService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LNDLWcfServiceCodeFirstDALHywinContext : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Office", "buildingName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Office", "buildingName", c => c.String());
        }
    }
}
