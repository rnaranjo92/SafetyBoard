namespace SafetyBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterPHoneNumber : DbMigration
    {
        public override void Up()
        {
            AlterColumn("AspNetUsers", "PhoneNumber", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
        }
    }
}
