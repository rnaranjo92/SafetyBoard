namespace SafetyBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSafetyNewsInComment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "SafetyNewsId", c => c.Int(nullable: false));
            CreateIndex("dbo.Comments", "SafetyNewsId");
            AddForeignKey("dbo.Comments", "SafetyNewsId", "dbo.SafetyNews", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "SafetyNewsId", "dbo.SafetyNews");
            DropIndex("dbo.Comments", new[] { "SafetyNewsId" });
            DropColumn("dbo.Comments", "SafetyNewsId");
        }
    }
}
