namespace LNDLWcfService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LNDLWcfServiceCodeFirstDALHywinContext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        Address_Id = c.Int(nullable: false),
                        Number = c.String(nullable: false),
                        Street = c.String(nullable: false),
                        City = c.String(nullable: false),
                        State = c.String(nullable: false),
                        Country = c.String(nullable: false),
                        ZipCode = c.String(nullable: false),
                        addressType = c.Int(),
                    })
                .PrimaryKey(t => t.Address_Id)
                .ForeignKey("dbo.Office", t => t.Address_Id)
                .Index(t => t.Address_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Address", "Address_Id", "dbo.Office");
            DropIndex("dbo.Address", new[] { "Address_Id" });
            DropTable("dbo.Address");
        }
    }
}
