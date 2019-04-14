namespace SafetyBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDatePostedToComment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "DatePosted", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comments", "DatePosted");
        }
    }
}
