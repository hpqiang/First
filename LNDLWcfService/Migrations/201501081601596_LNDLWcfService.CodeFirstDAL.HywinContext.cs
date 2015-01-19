namespace LNDLWcfService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LNDLWcfServiceCodeFirstDALHywinContext : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Address", "addressType", c => c.Int());
            AddColumn("dbo.Office", "type", c => c.Int());
            AddColumn("dbo.Company", "companyType", c => c.Int());
            AlterColumn("dbo.Address", "Number", c => c.String(nullable: false));
            AlterColumn("dbo.Address", "Street", c => c.String(nullable: false));
            AlterColumn("dbo.Company", "BriefName", c => c.String(nullable: false));
            AlterColumn("dbo.Company", "FullName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Company", "FullName", c => c.String());
            AlterColumn("dbo.Company", "BriefName", c => c.String());
            AlterColumn("dbo.Address", "Street", c => c.String());
            AlterColumn("dbo.Address", "Number", c => c.String());
            DropColumn("dbo.Company", "companyType");
            DropColumn("dbo.Office", "type");
            DropColumn("dbo.Address", "addressType");
        }
    }
}
