namespace LNDLWcfService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LNDLWcfServiceCodeFirstDALHywinContext : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Address", "Number", c => c.String());
            AlterColumn("dbo.Address", "Street", c => c.String());
            AlterColumn("dbo.Address", "City", c => c.String());
            AlterColumn("dbo.Address", "State", c => c.String());
            AlterColumn("dbo.Address", "Country", c => c.String());
            AlterColumn("dbo.Address", "ZipCode", c => c.String());
            AlterColumn("dbo.Company", "BriefName", c => c.String());
            AlterColumn("dbo.Company", "FullName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Company", "FullName", c => c.String(nullable: false));
            AlterColumn("dbo.Company", "BriefName", c => c.String(nullable: false));
            AlterColumn("dbo.Address", "ZipCode", c => c.String(nullable: false));
            AlterColumn("dbo.Address", "Country", c => c.String(nullable: false));
            AlterColumn("dbo.Address", "State", c => c.String(nullable: false));
            AlterColumn("dbo.Address", "City", c => c.String(nullable: false));
            AlterColumn("dbo.Address", "Street", c => c.String(nullable: false));
            AlterColumn("dbo.Address", "Number", c => c.String(nullable: false));
        }
    }
}
