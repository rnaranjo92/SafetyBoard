namespace SafetyBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOrganizationToUsers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Organization", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Organization");
        }
    }
}
