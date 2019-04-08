namespace SafetyBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsQAToIdentityModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "IsQA", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "IsQA");
        }
    }
}
