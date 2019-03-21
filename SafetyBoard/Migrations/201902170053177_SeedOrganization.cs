namespace SafetyBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedOrganization : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Organizations (Name)VALUES('412 Maintenance Group')");
            Sql("INSERT INTO Organizations (Name)VALUES('412 Communication Group')");
            Sql("INSERT INTO Organizations (Name)VALUES('412 Engineering Group')");
        }

        public override void Down()
        {
        }
    }
}
