namespace SafetyBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateOrganizationToUsers : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Users SET Organization = 'USS Carl Vinson' WHERE Id = 1");
            Sql("UPDATE Users SET Organization = '412th FSS/FSRA' WHERE Id = 3");
        }
        
        public override void Down()
        {
        }
    }
}
