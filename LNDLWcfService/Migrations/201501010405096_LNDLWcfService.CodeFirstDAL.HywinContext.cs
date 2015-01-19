namespace LNDLWcfService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LNDLWcfServiceCodeFirstDALHywinContext : DbMigration
    {
        public override void Up()
        {
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
            
            AddColumn("dbo.Payment", "Sale_Id", c => c.Int());
            AddColumn("dbo.Shipping", "Inventory_Id", c => c.Int());
            CreateIndex("dbo.Payment", "Sale_Id");
            CreateIndex("dbo.Shipping", "Inventory_Id");
            AddForeignKey("dbo.Shipping", "Inventory_Id", "dbo.Inventory", "Id");
            AddForeignKey("dbo.Payment", "Sale_Id", "dbo.Sale", "Id");
            DropColumn("dbo.Inventory", "productId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Inventory", "productId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Sale", "Inventory_Id", "dbo.Inventory");
            DropForeignKey("dbo.Payment", "Sale_Id", "dbo.Sale");
            DropForeignKey("dbo.Shipping", "Inventory_Id", "dbo.Inventory");
            DropIndex("dbo.Sale", new[] { "Inventory_Id" });
            DropIndex("dbo.Shipping", new[] { "Inventory_Id" });
            DropIndex("dbo.Payment", new[] { "Sale_Id" });
            DropColumn("dbo.Shipping", "Inventory_Id");
            DropColumn("dbo.Payment", "Sale_Id");
            DropTable("dbo.Sale");
        }
    }
}
