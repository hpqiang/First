namespace LNDLWcfService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LNDLWcfServiceCodeFirstDALHywinContext : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderToOrder", "issueDate", c => c.DateTime());
            AddColumn("dbo.OrderToOrder", "expectedDatebyCustomer", c => c.DateTime());
            AddColumn("dbo.OrderToOrder", "expectedDate", c => c.DateTime());
            AddColumn("dbo.OrderToOrder", "manufacturingDate", c => c.DateTime());
            AddColumn("dbo.OrderToOrder", "exMillDate", c => c.DateTime());
            AddColumn("dbo.OrderToOrder", "shippingDate", c => c.DateTime());
            AddColumn("dbo.OrderToOrder", "arriveDate", c => c.DateTime());
            AddColumn("dbo.OrderToOrder", "inWareHouseDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderToOrder", "inWareHouseDate");
            DropColumn("dbo.OrderToOrder", "arriveDate");
            DropColumn("dbo.OrderToOrder", "shippingDate");
            DropColumn("dbo.OrderToOrder", "exMillDate");
            DropColumn("dbo.OrderToOrder", "manufacturingDate");
            DropColumn("dbo.OrderToOrder", "expectedDate");
            DropColumn("dbo.OrderToOrder", "expectedDatebyCustomer");
            DropColumn("dbo.OrderToOrder", "issueDate");
        }
    }
}
