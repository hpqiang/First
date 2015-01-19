namespace LNDLWcfService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LNDLWcfServiceCodeFirstDALProductContext : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CompanyProduct", "Company_Id", "dbo.Company");
            DropForeignKey("dbo.Office", "FKCompanyID", "dbo.Company");
            DropForeignKey("dbo.Person", "FKOfficeID", "dbo.Office");
            DropForeignKey("dbo.Address", "Address_Id", "dbo.Office");
            DropIndex("dbo.Address", new[] { "Address_Id" });
            DropIndex("dbo.Office", new[] { "FKCompanyID" });
            DropIndex("dbo.CompanyProduct", new[] { "Company_Id" });
            DropIndex("dbo.Person", new[] { "FKOfficeID" });
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
                        Product_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Product", t => t.Product_Id)
                .Index(t => t.Product_Id);
            
            AddColumn("dbo.CompanyProduct", "Product_Id", c => c.Int());
            CreateIndex("dbo.CompanyProduct", "Product_Id");
            AddForeignKey("dbo.CompanyProduct", "Product_Id", "dbo.Product", "Id");
            DropColumn("dbo.CompanyProduct", "Company_Id");
            //DropTable("dbo.Address");
            //DropTable("dbo.Office");
            //DropTable("dbo.Company");
            //DropTable("dbo.Person");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Person",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(),
                        Title = c.String(),
                        MobilePhone = c.String(),
                        Email = c.String(),
                        photo = c.String(),
                        FKOfficeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
                "dbo.Office",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        buildingName = c.String(nullable: false),
                        phoneNumber = c.String(),
                        Area = c.String(),
                        type = c.Int(),
                        FKCompanyID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
                .PrimaryKey(t => t.Address_Id);
            
            AddColumn("dbo.CompanyProduct", "Company_Id", c => c.Int());
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
            DropIndex("dbo.Photo", new[] { "Product_Id" });
            DropIndex("dbo.Shipping", new[] { "OrderToSupplier_Id" });
            DropIndex("dbo.Payment", new[] { "OrderFromCustomer_Id" });
            DropIndex("dbo.Payment", new[] { "OrderToSupplier_Id" });
            DropIndex("dbo.OrderToSupplier", new[] { "Product_Id" });
            DropIndex("dbo.LineItem", new[] { "shippingId" });
            DropIndex("dbo.LineItem", new[] { "supplierOrderId" });
            DropIndex("dbo.LineItem", new[] { "customerOrderId" });
            DropIndex("dbo.OrderFromCustomer", new[] { "Product_Id" });
            DropIndex("dbo.CompanyProduct", new[] { "Product_Id" });
            DropIndex("dbo.Product", new[] { "categoryId" });
            DropColumn("dbo.CompanyProduct", "Product_Id");
            DropTable("dbo.Photo");
            DropTable("dbo.Shipping");
            DropTable("dbo.Payment");
            DropTable("dbo.OrderToSupplier");
            DropTable("dbo.LineItem");
            DropTable("dbo.OrderFromCustomer");
            DropTable("dbo.Product");
            DropTable("dbo.Category");
            CreateIndex("dbo.Person", "FKOfficeID");
            CreateIndex("dbo.CompanyProduct", "Company_Id");
            CreateIndex("dbo.Office", "FKCompanyID");
            CreateIndex("dbo.Address", "Address_Id");
            AddForeignKey("dbo.Address", "Address_Id", "dbo.Office", "Id");
            AddForeignKey("dbo.Person", "FKOfficeID", "dbo.Office", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Office", "FKCompanyID", "dbo.Company", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CompanyProduct", "Company_Id", "dbo.Company", "Id");
        }
    }
}
