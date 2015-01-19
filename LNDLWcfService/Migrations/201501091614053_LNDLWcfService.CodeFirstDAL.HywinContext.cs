namespace LNDLWcfService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LNDLWcfServiceCodeFirstDALHywinContext : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Contact", newName: "Person");
            DropIndex("dbo.Person", new[] { "FKOfficeID" });
            AddColumn("dbo.Person", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Person", "Title", c => c.String());
            AlterColumn("dbo.Person", "FKOfficeID", c => c.Int());
            CreateIndex("dbo.Person", "FKOfficeID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Person", new[] { "FKOfficeID" });
            AlterColumn("dbo.Person", "FKOfficeID", c => c.Int(nullable: false));
            AlterColumn("dbo.Person", "Title", c => c.String(nullable: false));
            DropColumn("dbo.Person", "Discriminator");
            CreateIndex("dbo.Person", "FKOfficeID");
            RenameTable(name: "dbo.Person", newName: "Contact");
        }
    }
}
