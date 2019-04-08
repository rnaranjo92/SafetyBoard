namespace SafetyBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSafetyNews : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SafetyNews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DatePosted = c.DateTime(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                        Topic = c.String(),
                        ContentBody = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SafetyNews", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.SafetyNews", new[] { "UserId" });
            DropTable("dbo.SafetyNews");
        }
    }
}
