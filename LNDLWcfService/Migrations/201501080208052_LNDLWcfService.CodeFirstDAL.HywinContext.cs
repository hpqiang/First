namespace LNDLWcfService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LNDLWcfServiceCodeFirstDALHywinContext : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Office", "type");
            DropColumn("dbo.Company", "companyType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Company", "companyType", c => c.Int());
            AddColumn("dbo.Office", "type", c => c.Int());
        }
    }
}
