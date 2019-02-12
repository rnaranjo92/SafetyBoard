namespace SafetyBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateDateRegisteredForAllUsers : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Users SET DateRegistered = GETDATE() WHERE Id = 1");
            Sql("UPDATE Users SET DateRegistered = GETDATE() WHERE Id = 3");
        }
        
        public override void Down()
        {
        }
    }
}
