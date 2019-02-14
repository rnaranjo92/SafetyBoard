namespace SafetyBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveOrganization : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "Organization");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Organization", c => c.String(nullable: false, maxLength: 255));
        }
    }
}
