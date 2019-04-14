namespace SafetyBoard.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class ChangeCommentModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Comments", "PostingId", c => c.Int(nullable: true));
            AlterColumn("dbo.Comments", "SafetyNewsId", c => c.Int(nullable: true));
        }

        public override void Down()
        {
            AlterColumn("dbo.Comments", "PostingId", c => c.Int(nullable: false));
            AlterColumn("dbo.Comments", "SafetyNewsId", c => c.Int(nullable: false));
        }
    }
}
