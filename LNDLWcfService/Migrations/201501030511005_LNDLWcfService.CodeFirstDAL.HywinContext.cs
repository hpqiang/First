namespace LNDLWcfService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LNDLWcfServiceCodeFirstDALHywinContext : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Office", name: "Company_Id", newName: "FKCompanyID");
            RenameIndex(table: "dbo.Office", name: "IX_Company_Id", newName: "IX_FKCompanyID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Office", name: "IX_FKCompanyID", newName: "IX_Company_Id");
            RenameColumn(table: "dbo.Office", name: "FKCompanyID", newName: "Company_Id");
        }
    }
}
