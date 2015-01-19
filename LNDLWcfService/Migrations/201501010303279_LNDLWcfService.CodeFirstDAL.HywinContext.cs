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
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.String(nullable: false),
                        Street = c.String(nullable: false),
                        City = c.String(nullable: false),
                        State = c.String(nullable: false),
                        Country = c.String(nullable: false),
                        ZipCode = c.String(nullable: false),
                        addressType = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Office",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        phoneNumber = c.String(),
                        Area = c.String(),
                        type = c.Int(),
                        Company_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Address", t => t.Id)
                .ForeignKey("dbo.Company", t => t.Company_Id)
                .Index(t => t.Id)
                .Index(t => t.Company_Id);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HireDate = c.DateTime(),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Title = c.String(nullable: false),
                        ManagerId = c.Int(nullable: false),
                        CompanyPhone = c.String(nullable: false),
                        MobilePhone = c.String(),
                        Email = c.String(nullable: false),
                        photo = c.String(),
                        Office_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Office", t => t.Office_Id)
                .Index(t => t.Office_Id);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        categoryName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        productNumber = c.String(),
                        standardCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        listPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Size = c.String(),
                        Weight = c.String(),
                        Color = c.String(),
                        startSaleDate = c.DateTime(),
                        endSaleDate = c.DateTime(),
                        categoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category", t => t.categoryId, cascadeDelete: true)
                .Index(t => t.categoryId);
            
            CreateTable(
                "dbo.LineItem",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        orderQty = c.Int(nullable: false),
                        unitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        unitPriceDiscount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        lineTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Product_Id = c.Int(),
                        OrderFromCustomer_Id = c.Int(),
                        OrderToSupplier_Id = c.Int(),
                        Shipping_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Product", t => t.Product_Id)
                .ForeignKey("dbo.OrderFromCustomer", t => t.OrderFromCustomer_Id)
                .ForeignKey("dbo.OrderToSupplier", t => t.OrderToSupplier_Id)
                .ForeignKey("dbo.Shipping", t => t.Shipping_Id)
                .Index(t => t.Product_Id)
                .Index(t => t.OrderFromCustomer_Id)
                .Index(t => t.OrderToSupplier_Id)
                .Index(t => t.Shipping_Id);
            
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
                "dbo.Contact",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        companyId = c.Int(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Title = c.String(nullable: false),
                        ManagerId = c.Int(nullable: false),
                        CompanyPhone = c.String(nullable: false),
                        MobilePhone = c.String(),
                        Email = c.String(nullable: false),
                        photo = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Company", t => t.companyId, cascadeDelete: true)
                .Index(t => t.companyId);
            
            CreateTable(
                "dbo.OrderFromCustomer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        purchaseOrderNumber = c.String(nullable: false),
                        salesOrderNumber = c.String(),
                        orderDate = c.DateTime(),
                        dueDate = c.DateTime(),
                        modifiedDate = c.DateTime(),
                        onLineOrder = c.Boolean(nullable: false),
                        subTotal = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderToOrder",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        orderStatus = c.Int(),
                        OrderFromCustomer_Id = c.Int(),
                        OrderToSupplier_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OrderFromCustomer", t => t.OrderFromCustomer_Id)
                .ForeignKey("dbo.OrderToSupplier", t => t.OrderToSupplier_Id)
                .Index(t => t.OrderFromCustomer_Id)
                .Index(t => t.OrderToSupplier_Id);
            
            CreateTable(
                "dbo.Payment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Date = c.DateTime(),
                        OrderFromCustomer_Id = c.Int(),
                        OrderToSupplier_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OrderFromCustomer", t => t.OrderFromCustomer_Id)
                .ForeignKey("dbo.OrderToSupplier", t => t.OrderToSupplier_Id)
                .Index(t => t.OrderFromCustomer_Id)
                .Index(t => t.OrderToSupplier_Id);
            
            CreateTable(
                "dbo.Inventory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        productId = c.Int(nullable: false),
                        threshhold = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderToSupplier",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        purchaseOrderNumber = c.String(nullable: false),
                        salesOrderNumber = c.String(),
                        orderDate = c.DateTime(),
                        dueDate = c.DateTime(),
                        modifiedDate = c.DateTime(),
                        subTotal = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Shipping",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        start = c.DateTime(),
                        expectTime = c.DateTime(),
                        arrivalTime = c.DateTime(),
                        OrderToSupplier_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OrderToSupplier", t => t.OrderToSupplier_Id)
                .Index(t => t.OrderToSupplier_Id);
            
            CreateTable(
                "dbo.ShippingList",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Shipping", "OrderToSupplier_Id", "dbo.OrderToSupplier");
            DropForeignKey("dbo.LineItem", "Shipping_Id", "dbo.Shipping");
            DropForeignKey("dbo.Payment", "OrderToSupplier_Id", "dbo.OrderToSupplier");
            DropForeignKey("dbo.OrderToOrder", "OrderToSupplier_Id", "dbo.OrderToSupplier");
            DropForeignKey("dbo.LineItem", "OrderToSupplier_Id", "dbo.OrderToSupplier");
            DropForeignKey("dbo.Payment", "OrderFromCustomer_Id", "dbo.OrderFromCustomer");
            DropForeignKey("dbo.OrderToOrder", "OrderFromCustomer_Id", "dbo.OrderFromCustomer");
            DropForeignKey("dbo.LineItem", "OrderFromCustomer_Id", "dbo.OrderFromCustomer");
            DropForeignKey("dbo.Office", "Company_Id", "dbo.Company");
            DropForeignKey("dbo.Contact", "companyId", "dbo.Company");
            DropForeignKey("dbo.LineItem", "Product_Id", "dbo.Product");
            DropForeignKey("dbo.Product", "categoryId", "dbo.Category");
            DropForeignKey("dbo.Office", "Id", "dbo.Address");
            DropForeignKey("dbo.Employee", "Office_Id", "dbo.Office");
            DropIndex("dbo.Shipping", new[] { "OrderToSupplier_Id" });
            DropIndex("dbo.Payment", new[] { "OrderToSupplier_Id" });
            DropIndex("dbo.Payment", new[] { "OrderFromCustomer_Id" });
            DropIndex("dbo.OrderToOrder", new[] { "OrderToSupplier_Id" });
            DropIndex("dbo.OrderToOrder", new[] { "OrderFromCustomer_Id" });
            DropIndex("dbo.Contact", new[] { "companyId" });
            DropIndex("dbo.LineItem", new[] { "Shipping_Id" });
            DropIndex("dbo.LineItem", new[] { "OrderToSupplier_Id" });
            DropIndex("dbo.LineItem", new[] { "OrderFromCustomer_Id" });
            DropIndex("dbo.LineItem", new[] { "Product_Id" });
            DropIndex("dbo.Product", new[] { "categoryId" });
            DropIndex("dbo.Employee", new[] { "Office_Id" });
            DropIndex("dbo.Office", new[] { "Company_Id" });
            DropIndex("dbo.Office", new[] { "Id" });
            DropTable("dbo.ShippingList");
            DropTable("dbo.Shipping");
            DropTable("dbo.OrderToSupplier");
            DropTable("dbo.Inventory");
            DropTable("dbo.Payment");
            DropTable("dbo.OrderToOrder");
            DropTable("dbo.OrderFromCustomer");
            DropTable("dbo.Contact");
            DropTable("dbo.Company");
            DropTable("dbo.LineItem");
            DropTable("dbo.Product");
            DropTable("dbo.Category");
            DropTable("dbo.Employee");
            DropTable("dbo.Office");
            DropTable("dbo.Address");
        }
    }
}
