namespace SafetyBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulatePostingWithValues : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Postings (Title, PostingTypeId, Description,TimePosted) VALUES('Structural Problem',1,'Surveys are very useful to gather different types of information from different perspective on the subject of the survey. A large number of different responses allows researchers to work with a lot of data which directs them to the answer that they are looking for. However, there are disadvantages in using surveys such as survey questions may not be appropriate for the participants due to its complexity and with that being said, face-to-face survey or in-person survey must be used in order to target a specific population in order to get accurate results.',GETDATE())");

            Sql("INSERT INTO Postings (Title, PostingTypeId, Description,TimePosted) VALUES('Employee Problem',6,'Surveys are very useful to gather different types of information from different perspective on the subject of the survey. A large number of different responses allows researchers to work with a lot of data which directs them to the answer that they are looking for. However, there are disadvantages in using surveys such as survey questions may not be appropriate for the participants due to its complexity and with that being said, face-to-face survey or in-person survey must be used in order to target a specific population in order to get accurate results.',GETDATE())");
        }
        
        public override void Down()
        {
        }
    }
}
