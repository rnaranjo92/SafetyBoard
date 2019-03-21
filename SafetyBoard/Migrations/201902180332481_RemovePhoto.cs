namespace SafetyBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovePhoto : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Postings", "Picture");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Postings", "Picture", c => c.String());
        }
    }
}
