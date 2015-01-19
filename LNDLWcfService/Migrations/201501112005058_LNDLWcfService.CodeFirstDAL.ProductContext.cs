namespace LNDLWcfService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LNDLWcfServiceCodeFirstDALProductContext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CompanyProduct",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FKCompanyID = c.Int(nullable: false),
                        FKProductID = c.Int(nullable: false),
                        Company_Id = c.Int(),
                        Product_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Company", t => t.Company_Id)
                .ForeignKey("dbo.Product", t => t.Product_Id)
                .Index(t => t.Company_Id)
                .Index(t => t.Product_Id);
            
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
                "dbo.Category",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        categoryName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
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
                        Product_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Product", t => t.Product_Id)
                .Index(t => t.Product_Id);
            
            CreateTable(
                "dbo.LineItem",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        orderQty = c.Int(nullable: false),
                        unitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        unitPriceDiscount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        lineTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        moneyType = c.Int(nullable: false),
                        orderStatus = c.Int(nullable: false),
                        issueDate = c.DateTime(),
                        expectedDatebyCustomer = c.DateTime(),
                        expectedDate = c.DateTime(),
                        manufacturingDate = c.DateTime(),
                        exMillDate = c.DateTime(),
                        shippingDate = c.DateTime(),
                        arriveDate = c.DateTime(),
                        inWareHouseDate = c.DateTime(),
                        customerOrderId = c.Int(nullable: false),
                        supplierOrderId = c.Int(nullable: false),
                        shippingId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OrderFromCustomer", t => t.customerOrderId, cascadeDelete: true)
                .ForeignKey("dbo.OrderToSupplier", t => t.supplierOrderId, cascadeDelete: true)
                .ForeignKey("dbo.Shipping", t => t.shippingId, cascadeDelete: true)
                .Index(t => t.customerOrderId)
                .Index(t => t.supplierOrderId)
                .Index(t => t.shippingId);
            
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
                        orderPDFPath = c.String(),
                        Product_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Product", t => t.Product_Id)
                .Index(t => t.Product_Id);
            
            CreateTable(
                "dbo.Payment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        paymentStatus = c.Int(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Date = c.DateTime(),
                        OrderToSupplier_Id = c.Int(),
                        OrderFromCustomer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OrderToSupplier", t => t.OrderToSupplier_Id)
                .ForeignKey("dbo.OrderFromCustomer", t => t.OrderFromCustomer_Id)
                .Index(t => t.OrderToSupplier_Id)
                .Index(t => t.OrderFromCustomer_Id);
            
            CreateTable(
                "dbo.Shipping",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        start = c.DateTime(),
                        expectTime = c.DateTime(),
                        arrivalTime = c.DateTime(),
                        shippingStatus = c.Int(nullable: false),
                        OrderToSupplier_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OrderToSupplier", t => t.OrderToSupplier_Id)
                .Index(t => t.OrderToSupplier_Id);
            
            CreateTable(
                "dbo.Photo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        photoPath = c.String(),
                        FKProductID = c.Int(nullable: false),
                        Product_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Product", t => t.Product_Id)
                .Index(t => t.Product_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderToSupplier", "Product_Id", "dbo.Product");
            DropForeignKey("dbo.Photo", "Product_Id", "dbo.Product");
            DropForeignKey("dbo.OrderFromCustomer", "Product_Id", "dbo.Product");
            DropForeignKey("dbo.Payment", "OrderFromCustomer_Id", "dbo.OrderFromCustomer");
            DropForeignKey("dbo.LineItem", "shippingId", "dbo.Shipping");
            DropForeignKey("dbo.LineItem", "supplierOrderId", "dbo.OrderToSupplier");
            DropForeignKey("dbo.Shipping", "OrderToSupplier_Id", "dbo.OrderToSupplier");
            DropForeignKey("dbo.Payment", "OrderToSupplier_Id", "dbo.OrderToSupplier");
            DropForeignKey("dbo.LineItem", "customerOrderId", "dbo.OrderFromCustomer");
            DropForeignKey("dbo.CompanyProduct", "Product_Id", "dbo.Product");
            DropForeignKey("dbo.Product", "categoryId", "dbo.Category");
            DropForeignKey("dbo.CompanyProduct", "Company_Id", "dbo.Company");
            DropIndex("dbo.Photo", new[] { "Product_Id" });
            DropIndex("dbo.Shipping", new[] { "OrderToSupplier_Id" });
            DropIndex("dbo.Payment", new[] { "OrderFromCustomer_Id" });
            DropIndex("dbo.Payment", new[] { "OrderToSupplier_Id" });
            DropIndex("dbo.OrderToSupplier", new[] { "Product_Id" });
            DropIndex("dbo.LineItem", new[] { "shippingId" });
            DropIndex("dbo.LineItem", new[] { "supplierOrderId" });
            DropIndex("dbo.LineItem", new[] { "customerOrderId" });
            DropIndex("dbo.OrderFromCustomer", new[] { "Product_Id" });
            DropIndex("dbo.Product", new[] { "categoryId" });
            DropIndex("dbo.CompanyProduct", new[] { "Product_Id" });
            DropIndex("dbo.CompanyProduct", new[] { "Company_Id" });
            DropTable("dbo.Photo");
            DropTable("dbo.Shipping");
            DropTable("dbo.Payment");
            DropTable("dbo.OrderToSupplier");
            DropTable("dbo.LineItem");
            DropTable("dbo.OrderFromCustomer");
            DropTable("dbo.Category");
            DropTable("dbo.Product");
            DropTable("dbo.CompanyProduct");
        }
    }
}
