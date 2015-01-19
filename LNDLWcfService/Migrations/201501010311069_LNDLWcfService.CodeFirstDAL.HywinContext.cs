namespace LNDLWcfService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LNDLWcfServiceCodeFirstDALHywinContext : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderFromCustomer", "Company_Id", c => c.Int());
            AddColumn("dbo.OrderToSupplier", "Company_Id", c => c.Int());
            CreateIndex("dbo.OrderFromCustomer", "Company_Id");
            CreateIndex("dbo.OrderToSupplier", "Company_Id");
            AddForeignKey("dbo.OrderFromCustomer", "Company_Id", "dbo.Company", "Id");
            AddForeignKey("dbo.OrderToSupplier", "Company_Id", "dbo.Company", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderToSupplier", "Company_Id", "dbo.Company");
            DropForeignKey("dbo.OrderFromCustomer", "Company_Id", "dbo.Company");
            DropIndex("dbo.OrderToSupplier", new[] { "Company_Id" });
            DropIndex("dbo.OrderFromCustomer", new[] { "Company_Id" });
            DropColumn("dbo.OrderToSupplier", "Company_Id");
            DropColumn("dbo.OrderFromCustomer", "Company_Id");
        }
    }
}
