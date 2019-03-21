namespace SafetyBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Check2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "PostingId", "dbo.Postings");
            AddForeignKey("dbo.Comments", "PostingId", "dbo.Postings", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "PostingId", "dbo.Postings");
            AddForeignKey("dbo.Comments", "PostingId", "dbo.Postings", "Id");
        }
    }
}
