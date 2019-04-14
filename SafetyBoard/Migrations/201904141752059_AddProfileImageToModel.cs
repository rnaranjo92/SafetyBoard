namespace SafetyBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProfileImageToModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProfileImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Path = c.String(),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProfileImages", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.ProfileImages", new[] { "UserId" });
            DropTable("dbo.ProfileImages");
        }
    }
}
