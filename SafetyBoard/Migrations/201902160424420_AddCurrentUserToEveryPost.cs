namespace SafetyBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCurrentUserToEveryPost : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Postings", "UserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Postings", "UserId");
            AddForeignKey("dbo.Postings", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Postings", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Postings", new[] { "UserId" });
            DropColumn("dbo.Postings", "UserId");
        }
    }
}
