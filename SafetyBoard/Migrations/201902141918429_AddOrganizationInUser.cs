namespace SafetyBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOrganizationInUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "OrganizationId", c => c.Int(nullable: false));
            CreateIndex("dbo.AspNetUsers", "OrganizationId");
            AddForeignKey("dbo.AspNetUsers", "OrganizationId", "dbo.Organizations", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "OrganizationId", "dbo.Organizations");
            DropIndex("dbo.AspNetUsers", new[] { "OrganizationId" });
            DropColumn("dbo.AspNetUsers", "OrganizationId");
        }
    }
}
