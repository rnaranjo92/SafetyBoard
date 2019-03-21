namespace SafetyBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsCanceled : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Inspections", "IsCanceled", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Inspections", "IsCanceled");
        }
    }
}
