namespace SafetyBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTimePostedInPosting : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Postings", "TimePosted", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Postings", "TimePosted");
        }
    }
}
