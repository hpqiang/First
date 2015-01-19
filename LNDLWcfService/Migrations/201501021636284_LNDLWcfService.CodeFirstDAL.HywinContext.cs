namespace LNDLWcfService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LNDLWcfServiceCodeFirstDALHywinContext : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Person", "companyId", "dbo.Company");
            RenameColumn(table: "dbo.Person", name: "companyId", newName: "Company_Id");
            RenameIndex(table: "dbo.Person", name: "IX_companyId", newName: "IX_Company_Id");
            AddColumn("dbo.Shipping", "shippingStatus", c => c.Int(nullable: false));
            AlterColumn("dbo.Person", "Title", c => c.String());
            AddForeignKey("dbo.Person", "Company_Id", "dbo.Company", "Id");
            DropColumn("dbo.Person", "CompanyPhone");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Person", "CompanyPhone", c => c.String(nullable: false));
            DropForeignKey("dbo.Person", "Company_Id", "dbo.Company");
            AlterColumn("dbo.Person", "Title", c => c.String(nullable: false));
            DropColumn("dbo.Shipping", "shippingStatus");
            RenameIndex(table: "dbo.Person", name: "IX_Company_Id", newName: "IX_companyId");
            RenameColumn(table: "dbo.Person", name: "Company_Id", newName: "companyId");
            AddForeignKey("dbo.Person", "companyId", "dbo.Company", "Id", cascadeDelete: true);
        }
    }
}
