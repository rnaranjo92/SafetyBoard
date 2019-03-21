namespace SafetyBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeOriginalVenue : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Notifications", "OriginalVenue");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Notifications", "OriginalVenue", c => c.String());
        }
    }
}
