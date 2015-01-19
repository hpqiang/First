namespace LNDLWcfService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LNDLWcfServiceCodeFirstDALHywinContext : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Employee", newName: "Person");
            DropIndex("dbo.Contact", new[] { "companyId" });
            AddColumn("dbo.Person", "companyId", c => c.Int());
            AddColumn("dbo.Person", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Person", "companyId");
            DropTable("dbo.Contact");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Contact",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        companyId = c.Int(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Title = c.String(nullable: false),
                        ManagerId = c.Int(nullable: false),
                        CompanyPhone = c.String(nullable: false),
                        MobilePhone = c.String(),
                        Email = c.String(nullable: false),
                        photo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropIndex("dbo.Person", new[] { "companyId" });
            DropColumn("dbo.Person", "Discriminator");
            DropColumn("dbo.Person", "companyId");
            CreateIndex("dbo.Contact", "companyId");
            RenameTable(name: "dbo.Person", newName: "Employee");
        }
    }
}
