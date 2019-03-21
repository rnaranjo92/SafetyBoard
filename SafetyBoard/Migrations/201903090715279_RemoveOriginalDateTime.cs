namespace SafetyBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveOriginalDateTime : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Notifications", "OriginalDateTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Notifications", "OriginalDateTime", c => c.DateTime());
        }
    }
}
