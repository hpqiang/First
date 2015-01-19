namespace LNDLWcfService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LNDLWcfServiceCodeFirstDALHywinContext : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Person", "Office_Id", "dbo.Office");
            DropForeignKey("dbo.Office", "Id", "dbo.Address");
            DropForeignKey("dbo.Product", "categoryId", "dbo.Category");
            DropForeignKey("dbo.LineItem", "Product_Id", "dbo.Product");
            DropForeignKey("dbo.Person", "Company_Id", "dbo.Company");
            DropForeignKey("dbo.Office", "Company_Id", "dbo.Company");
            DropForeignKey("dbo.LineItem", "OrderFromCustomer_Id", "dbo.OrderFromCustomer");
            DropForeignKey("dbo.OrderToOrder", "OrderFromCustomer_Id", "dbo.OrderFromCustomer");
            DropForeignKey("dbo.Payment", "OrderFromCustomer_Id", "dbo.OrderFromCustomer");
            DropForeignKey("dbo.OrderFromCustomer", "Company_Id", "dbo.Company");
            DropForeignKey("dbo.LineItem", "OrderToSupplier_Id", "dbo.OrderToSupplier");
            DropForeignKey("dbo.OrderToOrder", "OrderToSupplier_Id", "dbo.OrderToSupplier");
            DropForeignKey("dbo.Payment", "OrderToSupplier_Id", "dbo.OrderToSupplier");
            DropForeignKey("dbo.LineItem", "Shipping_Id", "dbo.Shipping");
            DropForeignKey("dbo.Shipping", "OrderToSupplier_Id", "dbo.OrderToSupplier");
            DropForeignKey("dbo.OrderToSupplier", "Company_Id", "dbo.Company");
            DropForeignKey("dbo.Shipping", "Inventory_Id", "dbo.Inventory");
            DropForeignKey("dbo.Payment", "Sale_Id", "dbo.Sale");
            DropForeignKey("dbo.Sale", "Inventory_Id", "dbo.Inventory");
            DropIndex("dbo.Office", new[] { "Id" });
            DropIndex("dbo.Office", new[] { "Company_Id" });
            DropIndex("dbo.Person", new[] { "Office_Id" });
            DropIndex("dbo.Person", new[] { "Company_Id" });
            DropIndex("dbo.Product", new[] { "categoryId" });
            DropIndex("dbo.LineItem", new[] { "Product_Id" });
            DropIndex("dbo.LineItem", new[] { "OrderFromCustomer_Id" });
            DropIndex("dbo.LineItem", new[] { "OrderToSupplier_Id" });
            DropIndex("dbo.LineItem", new[] { "Shipping_Id" });
            DropIndex("dbo.OrderFromCustomer", new[] { "Company_Id" });
            DropIndex("dbo.OrderToOrder", new[] { "OrderFromCustomer_Id" });
            DropIndex("dbo.OrderToOrder", new[] { "OrderToSupplier_Id" });
            DropIndex("dbo.Payment", new[] { "OrderFromCustomer_Id" });
            DropIndex("dbo.Payment", new[] { "OrderToSupplier_Id" });
            DropIndex("dbo.Payment", new[] { "Sale_Id" });
            DropIndex("dbo.OrderToSupplier", new[] { "Company_Id" });
            DropIndex("dbo.Shipping", new[] { "OrderToSupplier_Id" });
            DropIndex("dbo.Shipping", new[] { "Inventory_Id" });
            DropIndex("dbo.Sale", new[] { "Inventory_Id" });
            DropTable("dbo.Address");
            DropTable("dbo.Person");
            DropTable("dbo.Office");
            DropTable("dbo.Category");
            DropTable("dbo.Product");
            DropTable("dbo.LineItem");
            DropTable("dbo.OrderFromCustomer");
            DropTable("dbo.OrderToOrder");
            DropTable("dbo.Payment");
            DropTable("dbo.OrderToSupplier");
            DropTable("dbo.Shipping");
            DropTable("dbo.Inventory");
            DropTable("dbo.Sale");
            DropTable("dbo.ShippingList");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ShippingList",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
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
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Inventory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        threshhold = c.Int(nullable: false),
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
                        shippingStatus = c.Int(nullable: false),
                        OrderToSupplier_Id = c.Int(),
                        Inventory_Id = c.Int(),
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
                        Company_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Payment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Date = c.DateTime(),
                        OrderFromCustomer_Id = c.Int(),
                        OrderToSupplier_Id = c.Int(),
                        Sale_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderToOrder",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        orderStatus = c.Int(),
                        issueDate = c.DateTime(),
                        expectedDatebyCustomer = c.DateTime(),
                        expectedDate = c.DateTime(),
                        manufacturingDate = c.DateTime(),
                        exMillDate = c.DateTime(),
                        shippingDate = c.DateTime(),
                        arriveDate = c.DateTime(),
                        inWareHouseDate = c.DateTime(),
                        OrderFromCustomer_Id = c.Int(),
                        OrderToSupplier_Id = c.Int(),
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
                        Company_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
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
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        categoryName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Person",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        ManagerId = c.Int(nullable: false),
                        MobilePhone = c.String(),
                        Email = c.String(nullable: false),
                        photo = c.String(),
                        HireDate = c.DateTime(),
                        Title = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Office_Id = c.Int(),
                        Company_Id = c.Int(),
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
                .PrimaryKey(t => t.Id);
            
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
            
            CreateIndex("dbo.Sale", "Inventory_Id");
            CreateIndex("dbo.Shipping", "Inventory_Id");
            CreateIndex("dbo.Shipping", "OrderToSupplier_Id");
            CreateIndex("dbo.OrderToSupplier", "Company_Id");
            CreateIndex("dbo.Payment", "Sale_Id");
            CreateIndex("dbo.Payment", "OrderToSupplier_Id");
            CreateIndex("dbo.Payment", "OrderFromCustomer_Id");
            CreateIndex("dbo.OrderToOrder", "OrderToSupplier_Id");
            CreateIndex("dbo.OrderToOrder", "OrderFromCustomer_Id");
            CreateIndex("dbo.OrderFromCustomer", "Company_Id");
            CreateIndex("dbo.LineItem", "Shipping_Id");
            CreateIndex("dbo.LineItem", "OrderToSupplier_Id");
            CreateIndex("dbo.LineItem", "OrderFromCustomer_Id");
            CreateIndex("dbo.LineItem", "Product_Id");
            CreateIndex("dbo.Product", "categoryId");
            CreateIndex("dbo.Person", "Company_Id");
            CreateIndex("dbo.Person", "Office_Id");
            CreateIndex("dbo.Office", "Company_Id");
            CreateIndex("dbo.Office", "Id");
            AddForeignKey("dbo.Sale", "Inventory_Id", "dbo.Inventory", "Id");
            AddForeignKey("dbo.Payment", "Sale_Id", "dbo.Sale", "Id");
            AddForeignKey("dbo.Shipping", "Inventory_Id", "dbo.Inventory", "Id");
            AddForeignKey("dbo.OrderToSupplier", "Company_Id", "dbo.Company", "Id");
            AddForeignKey("dbo.Shipping", "OrderToSupplier_Id", "dbo.OrderToSupplier", "Id");
            AddForeignKey("dbo.LineItem", "Shipping_Id", "dbo.Shipping", "Id");
            AddForeignKey("dbo.Payment", "OrderToSupplier_Id", "dbo.OrderToSupplier", "Id");
            AddForeignKey("dbo.OrderToOrder", "OrderToSupplier_Id", "dbo.OrderToSupplier", "Id");
            AddForeignKey("dbo.LineItem", "OrderToSupplier_Id", "dbo.OrderToSupplier", "Id");
            AddForeignKey("dbo.OrderFromCustomer", "Company_Id", "dbo.Company", "Id");
            AddForeignKey("dbo.Payment", "OrderFromCustomer_Id", "dbo.OrderFromCustomer", "Id");
            AddForeignKey("dbo.OrderToOrder", "OrderFromCustomer_Id", "dbo.OrderFromCustomer", "Id");
            AddForeignKey("dbo.LineItem", "OrderFromCustomer_Id", "dbo.OrderFromCustomer", "Id");
            AddForeignKey("dbo.Office", "Company_Id", "dbo.Company", "Id");
            AddForeignKey("dbo.Person", "Company_Id", "dbo.Company", "Id");
            AddForeignKey("dbo.LineItem", "Product_Id", "dbo.Product", "Id");
            AddForeignKey("dbo.Product", "categoryId", "dbo.Category", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Office", "Id", "dbo.Address", "Id");
            AddForeignKey("dbo.Person", "Office_Id", "dbo.Office", "Id");
        }
    }
}
