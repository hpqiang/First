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
            AlterColumn("dbo.Company", "BriefName", c => c.String());
            AlterColumn("dbo.Company", "FullName", c => c.String());
            AlterColumn("dbo.Person", "LastName", c => c.String());
            AlterColumn("dbo.Person", "Title", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Person", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Person", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Company", "FullName", c => c.String(nullable: false));
            AlterColumn("dbo.Company", "BriefName", c => c.String(nullable: false));
            AlterColumn("dbo.Address", "Street", c => c.String(nullable: false));
            AlterColumn("dbo.Address", "Number", c => c.String(nullable: false));
        }
    }
}
