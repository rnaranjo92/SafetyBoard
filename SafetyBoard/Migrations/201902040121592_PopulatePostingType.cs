namespace SafetyBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulatePostingType : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO PostingTypes (Id, SafetyCategory)VALUES(1, 'Structural Issue')");
            Sql("INSERT INTO PostingTypes (Id, SafetyCategory)VALUES(2, 'Electrical Issue')");
            Sql("INSERT INTO PostingTypes (Id, SafetyCategory)VALUES(3, 'Mechanical Issue')");
            Sql("INSERT INTO PostingTypes (Id, SafetyCategory)VALUES(4, 'Environmental Issue')");
            Sql("INSERT INTO PostingTypes (Id, SafetyCategory)VALUES(5, 'Communication Issue')");
            Sql("INSERT INTO PostingTypes (Id, SafetyCategory)VALUES(6, 'Other')");
        }
        
        public override void Down()
        {
        }
    }
}
