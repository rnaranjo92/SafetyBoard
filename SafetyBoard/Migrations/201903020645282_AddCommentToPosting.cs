namespace SafetyBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCommentToPosting : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Postings", "OrganizationId", c => c.Int(nullable: false));
            CreateIndex("dbo.Postings", "OrganizationId");
            AddForeignKey("dbo.Postings", "OrganizationId", "dbo.Organizations", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Postings", "OrganizationId", "dbo.Organizations");
            DropIndex("dbo.Postings", new[] { "OrganizationId" });
            DropColumn("dbo.Postings", "OrganizationId");
        }
    }
}
