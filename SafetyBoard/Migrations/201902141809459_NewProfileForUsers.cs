namespace SafetyBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewProfileForUsers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Organization", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.AspNetUsers", "AllowAccess", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "AllowAccess");
            DropColumn("dbo.AspNetUsers", "Organization");
        }
    }
}
