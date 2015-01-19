namespace LNDLWcfService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LNDLWcfServiceCodeFirstDALHywinContext : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Address", "addressType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Address", "addressType", c => c.Int());
        }
    }
}
