namespace LNDLWcfService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LNDLWcfServiceCodeFirstDALHywinContext : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Person", new[] { "FKOfficeID" });
            AlterColumn("dbo.Person", "Email", c => c.String());
            AlterColumn("dbo.Person", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Person", "FKOfficeID", c => c.Int(nullable: false));
            CreateIndex("dbo.Person", "FKOfficeID");
            DropColumn("dbo.Person", "ManagerId");
            DropColumn("dbo.Person", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Person", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Person", "ManagerId", c => c.Int(nullable: false));
            DropIndex("dbo.Person", new[] { "FKOfficeID" });
            AlterColumn("dbo.Person", "FKOfficeID", c => c.Int());
            AlterColumn("dbo.Person", "Title", c => c.String());
            AlterColumn("dbo.Person", "Email", c => c.String(nullable: false));
            CreateIndex("dbo.Person", "FKOfficeID");
        }
    }
}
