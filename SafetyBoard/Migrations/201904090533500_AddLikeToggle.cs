namespace SafetyBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLikeToggle : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Likes",
                c => new
                    {
                        SafetyNewsId = c.Int(nullable: false),
                        LikerId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.SafetyNewsId, t.LikerId })
                .ForeignKey("dbo.AspNetUsers", t => t.LikerId, cascadeDelete: true)
                .ForeignKey("dbo.SafetyNews", t => t.SafetyNewsId, cascadeDelete: true)
                .Index(t => t.SafetyNewsId)
                .Index(t => t.LikerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Likes", "SafetyNewsId", "dbo.SafetyNews");
            DropForeignKey("dbo.Likes", "LikerId", "dbo.AspNetUsers");
            DropIndex("dbo.Likes", new[] { "LikerId" });
            DropIndex("dbo.Likes", new[] { "SafetyNewsId" });
            DropTable("dbo.Likes");
        }
    }
}
