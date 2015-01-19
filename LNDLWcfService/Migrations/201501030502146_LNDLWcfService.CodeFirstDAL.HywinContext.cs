namespace LNDLWcfService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LNDLWcfServiceCodeFirstDALHywinContext : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Office", new[] { "company_Id" });
            CreateIndex("dbo.Office", "Company_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Office", new[] { "Company_Id" });
            CreateIndex("dbo.Office", "company_Id");
        }
    }
}
