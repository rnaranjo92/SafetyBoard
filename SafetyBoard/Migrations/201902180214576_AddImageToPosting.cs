namespace SafetyBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImageToPosting : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Postings", "Picture", c => c.String(nullable: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Postings", "Picture");
        }
    }
}
