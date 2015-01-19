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
                        Number = c.String(),
                        Street = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Country = c.String(),
                        ZipCode = c.String(),
                        addressType = c.Int(),
                    })
                .PrimaryKey(t => t.Address_Id)
                .ForeignKey("dbo.Office", t => t.Address_Id)
                .Index(t => t.Address_Id);
            
            CreateTable(
                "dbo.Office",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        buildingName = c.String(),
                        phoneNumber = c.String(),
                        Area = c.String(),
                        type = c.Int(),
                        FKCompanyID = c.Int(nullable: false),
                        Company_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Company", t => t.Company_Id)
                .Index(t => t.Company_Id);
            
            CreateTable(
                "dbo.Company",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BriefName = c.String(),
                        FullName = c.String(),
                        companyType = c.Int(),
                        Phone = c.String(),
                        Email = c.String(),
                        WebSite = c.String(),
                        DateSince = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        logo = c.String(),
                        country = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Person",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Title = c.String(),
                        MobilePhone = c.String(),
                        Email = c.String(),
                        photo = c.String(),
                        FKOfficeID = c.Int(nullable: false),
                        Office_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Office", t => t.Office_Id)
                .Index(t => t.Office_Id);
            
            CreateTable(
                "dbo.Inventory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        threshhold = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sale",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Date = c.DateTime(),
                        Inventory_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Inventory", t => t.Inventory_Id)
                .Index(t => t.Inventory_Id);
            
            AddColumn("dbo.CompanyProduct", "Company_Id", c => c.Int());
            AddColumn("dbo.Payment", "Sale_Id", c => c.Int());
            AddColumn("dbo.Shipping", "Inventory_Id", c => c.Int());
            CreateIndex("dbo.CompanyProduct", "Company_Id");
            CreateIndex("dbo.Payment", "Sale_Id");
            CreateIndex("dbo.Shipping", "Inventory_Id");
            AddForeignKey("dbo.CompanyProduct", "Company_Id", "dbo.Company", "Id");
            AddForeignKey("dbo.Shipping", "Inventory_Id", "dbo.Inventory", "Id");
            AddForeignKey("dbo.Payment", "Sale_Id", "dbo.Sale", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sale", "Inventory_Id", "dbo.Inventory");
            DropForeignKey("dbo.Payment", "Sale_Id", "dbo.Sale");
            DropForeignKey("dbo.Shipping", "Inventory_Id", "dbo.Inventory");
            DropForeignKey("dbo.Address", "Address_Id", "dbo.Office");
            DropForeignKey("dbo.Person", "Office_Id", "dbo.Office");
            DropForeignKey("dbo.Office", "Company_Id", "dbo.Company");
            DropForeignKey("dbo.CompanyProduct", "Company_Id", "dbo.Company");
            DropIndex("dbo.Sale", new[] { "Inventory_Id" });
            DropIndex("dbo.Shipping", new[] { "Inventory_Id" });
            DropIndex("dbo.Payment", new[] { "Sale_Id" });
            DropIndex("dbo.Person", new[] { "Office_Id" });
            DropIndex("dbo.CompanyProduct", new[] { "Company_Id" });
            DropIndex("dbo.Office", new[] { "Company_Id" });
            DropIndex("dbo.Address", new[] { "Address_Id" });
            DropColumn("dbo.Shipping", "Inventory_Id");
            DropColumn("dbo.Payment", "Sale_Id");
            DropColumn("dbo.CompanyProduct", "Company_Id");
            DropTable("dbo.Sale");
            DropTable("dbo.Inventory");
            DropTable("dbo.Person");
            DropTable("dbo.Company");
            DropTable("dbo.Office");
            DropTable("dbo.Address");
        }
    }
}
