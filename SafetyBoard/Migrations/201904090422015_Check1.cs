namespace SafetyBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Check1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "SafetyNewsId", "dbo.SafetyNews");
            DropIndex("dbo.Comments", new[] { "SafetyNewsId" });
            DropColumn("dbo.Comments", "SafetyNewsId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comments", "SafetyNewsId", c => c.Int(nullable: false));
            CreateIndex("dbo.Comments", "SafetyNewsId");
            AddForeignKey("dbo.Comments", "SafetyNewsId", "dbo.SafetyNews", "Id", cascadeDelete: true);
        }
    }
}
