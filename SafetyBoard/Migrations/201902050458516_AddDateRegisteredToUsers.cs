namespace SafetyBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateRegisteredToUsers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "DateRegistered", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "DateRegistered");
        }
    }
}
