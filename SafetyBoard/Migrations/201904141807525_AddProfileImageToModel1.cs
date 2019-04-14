namespace SafetyBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProfileImageToModel1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ProfileImages", "Title");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProfileImages", "Title", c => c.String());
        }
    }
}
