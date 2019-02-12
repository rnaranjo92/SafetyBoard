namespace SafetyBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsSubscribeToNewsletterInUserModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "IsSubscribeToNewsletter", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "IsSubscribeToNewsletter");
        }
    }
}
