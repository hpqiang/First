namespace LNDLWcfService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LNDLWcfServiceCodeFirstDALHywinContext : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Person", "FKOfficeID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Person", "FKOfficeID", c => c.Int(nullable: false));
        }
    }
}
