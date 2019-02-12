namespace SafetyBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDescriptionToPosting : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Postings", "Description", c => c.String(nullable: false, maxLength: 3000));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Postings", "Description");
        }
    }
}
