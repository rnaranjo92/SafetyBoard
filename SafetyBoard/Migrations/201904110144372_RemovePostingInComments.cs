namespace SafetyBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovePostingInComments : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "PostingId", "dbo.Postings");
            DropIndex("dbo.Comments", new[] { "PostingId" });
            DropColumn("dbo.Comments", "PostingId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comments", "PostingId", c => c.Int(nullable: false));
            CreateIndex("dbo.Comments", "PostingId");
            AddForeignKey("dbo.Comments", "PostingId", "dbo.Postings", "Id", cascadeDelete: true);
        }
    }
}
