namespace SafetyBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NeedToMakeUserTypeAndOrganizationRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Organization", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Organization", c => c.String());
        }
    }
}
