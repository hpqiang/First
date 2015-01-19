namespace LNDLWcfService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LNDLWcfServiceCodeFirstDALHywinContext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contact",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        FKOfficeID = c.Int(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        ManagerId = c.Int(nullable: false),
                        MobilePhone = c.String(),
                        Email = c.String(nullable: false),
                        photo = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Office", t => t.FKOfficeID, cascadeDelete: true)
                .Index(t => t.FKOfficeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contact", "FKOfficeID", "dbo.Office");
            DropIndex("dbo.Contact", new[] { "FKOfficeID" });
            DropTable("dbo.Contact");
        }
    }
}
