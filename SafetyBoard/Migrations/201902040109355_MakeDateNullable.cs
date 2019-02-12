namespace SafetyBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeDateNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "BirthDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "BirthDate", c => c.DateTime(nullable: false));
        }
    }
}
