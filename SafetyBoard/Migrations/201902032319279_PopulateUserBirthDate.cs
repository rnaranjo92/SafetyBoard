namespace SafetyBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateUserBirthDate : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Users SET BirthDate = '20 APRIL 1992' WHERE Id =1");
            Sql("UPDATE Users SET BirthDate = '29 AUGUST 1992' WHERE Id =3");
        }
        
        public override void Down()
        {
        }
    }
}
