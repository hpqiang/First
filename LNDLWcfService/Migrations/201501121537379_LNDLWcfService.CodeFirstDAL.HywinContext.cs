namespace LNDLWcfService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LNDLWcfServiceCodeFirstDALHywinContext : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderFromCustomer", "Product_Id", "dbo.Product");
            DropForeignKey("dbo.OrderToSupplier", "Product_Id", "dbo.Product");
            DropIndex("dbo.OrderFromCustomer", new[] { "Product_Id" });
            DropIndex("dbo.OrderToSupplier", new[] { "Product_Id" });
            CreateTable(
                "dbo.OrderToSupplierProduct",
                c => new
                    {
                        OrderToSupplier_Id = c.Int(nullable: false),
                        Product_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.OrderToSupplier_Id, t.Product_Id })
                .ForeignKey("dbo.OrderToSupplier", t => t.OrderToSupplier_Id, cascadeDelete: true)
                .ForeignKey("dbo.Product", t => t.Product_Id, cascadeDelete: true)
                .Index(t => t.OrderToSupplier_Id)
                .Index(t => t.Product_Id);
            
            CreateTable(
                "dbo.OrderFromCustomerProduct",
                c => new
                    {
                        OrderFromCustomer_Id = c.Int(nullable: false),
                        Product_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.OrderFromCustomer_Id, t.Product_Id })
                .ForeignKey("dbo.OrderFromCustomer", t => t.OrderFromCustomer_Id, cascadeDelete: true)
                .ForeignKey("dbo.Product", t => t.Product_Id, cascadeDelete: true)
                .Index(t => t.OrderFromCustomer_Id)
                .Index(t => t.Product_Id);
            
            DropColumn("dbo.OrderFromCustomer", "Product_Id");
            DropColumn("dbo.OrderToSupplier", "Product_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderToSupplier", "Product_Id", c => c.Int());
            AddColumn("dbo.OrderFromCustomer", "Product_Id", c => c.Int());
            DropForeignKey("dbo.OrderFromCustomerProduct", "Product_Id", "dbo.Product");
            DropForeignKey("dbo.OrderFromCustomerProduct", "OrderFromCustomer_Id", "dbo.OrderFromCustomer");
            DropForeignKey("dbo.OrderToSupplierProduct", "Product_Id", "dbo.Product");
            DropForeignKey("dbo.OrderToSupplierProduct", "OrderToSupplier_Id", "dbo.OrderToSupplier");
            DropIndex("dbo.OrderFromCustomerProduct", new[] { "Product_Id" });
            DropIndex("dbo.OrderFromCustomerProduct", new[] { "OrderFromCustomer_Id" });
            DropIndex("dbo.OrderToSupplierProduct", new[] { "Product_Id" });
            DropIndex("dbo.OrderToSupplierProduct", new[] { "OrderToSupplier_Id" });
            DropTable("dbo.OrderFromCustomerProduct");
            DropTable("dbo.OrderToSupplierProduct");
            CreateIndex("dbo.OrderToSupplier", "Product_Id");
            CreateIndex("dbo.OrderFromCustomer", "Product_Id");
            AddForeignKey("dbo.OrderToSupplier", "Product_Id", "dbo.Product", "Id");
            AddForeignKey("dbo.OrderFromCustomer", "Product_Id", "dbo.Product", "Id");
        }
    }
}
