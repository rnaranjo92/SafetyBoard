namespace SafetyBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeCommentToPostComment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "postComment", c => c.String());
            DropColumn("dbo.Comments", "comment");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comments", "comment", c => c.String());
            DropColumn("dbo.Comments", "postComment");
        }
    }
}
