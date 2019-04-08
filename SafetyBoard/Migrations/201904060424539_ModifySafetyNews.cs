namespace SafetyBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifySafetyNews : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SafetyNews", "Title", c => c.String());
            AddColumn("dbo.SafetyNews", "Article", c => c.String());
            AddColumn("dbo.SafetyNews", "IsRemoved", c => c.Boolean(nullable: false));
            DropColumn("dbo.SafetyNews", "Topic");
            DropColumn("dbo.SafetyNews", "ContentBody");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SafetyNews", "ContentBody", c => c.String());
            AddColumn("dbo.SafetyNews", "Topic", c => c.String());
            DropColumn("dbo.SafetyNews", "IsRemoved");
            DropColumn("dbo.SafetyNews", "Article");
            DropColumn("dbo.SafetyNews", "Title");
        }
    }
}
