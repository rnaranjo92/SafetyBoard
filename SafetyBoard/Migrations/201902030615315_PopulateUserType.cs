namespace SafetyBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateUserType : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO UserTypes (Id, Title)VALUES(1, 'NormalUser')");
            Sql("INSERT INTO UserTypes (Id, Title)VALUES(2, 'QualityAssurance')");
            Sql("INSERT INTO UserTypes (Id, Title)VALUES(3, 'Director')");
            Sql("INSERT INTO UserTypes (Id, Title)VALUES(4, 'Flight Chief')");
            Sql("INSERT INTO UserTypes (Id, Title)VALUES(5, 'Commander')");
        }
        
        public override void Down()
        {
        }
    }
}
