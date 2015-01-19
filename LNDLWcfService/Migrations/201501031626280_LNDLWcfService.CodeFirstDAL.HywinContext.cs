namespace LNDLWcfService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LNDLWcfServiceCodeFirstDALHywinContext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Company",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BriefName = c.String(nullable: false),
                        FullName = c.String(nullable: false),
                        companyType = c.Int(),
                        Phone = c.String(),
                        Email = c.String(),
                        WebSite = c.String(),
                        DateSince = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        logo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Office",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        phoneNumber = c.String(),
                        Area = c.String(),
                        type = c.Int(),
                        FKCompanyID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Company", t => t.FKCompanyID, cascadeDelete: true)
                .Index(t => t.FKCompanyID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Office", "FKCompanyID", "dbo.Company");
            DropIndex("dbo.Office", new[] { "FKCompanyID" });
            DropTable("dbo.Office");
            DropTable("dbo.Company");
        }
    }
}
