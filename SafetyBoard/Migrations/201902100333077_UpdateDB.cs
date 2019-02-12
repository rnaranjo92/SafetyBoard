namespace SafetyBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDB : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Postings", "TimePosted", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Postings", "TimePosted", c => c.DateTime(nullable: false));
        }
    }
}
