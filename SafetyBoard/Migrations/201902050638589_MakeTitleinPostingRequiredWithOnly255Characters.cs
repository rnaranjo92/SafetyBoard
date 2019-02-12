namespace SafetyBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeTitleinPostingRequiredWithOnly255Characters : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Postings", "Title", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Postings", "Title", c => c.String());
        }
    }
}
