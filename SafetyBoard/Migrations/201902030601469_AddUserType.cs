namespace SafetyBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Users", "UserTypeId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Users", "UserTypeId");
            AddForeignKey("dbo.Users", "UserTypeId", "dbo.UserTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "UserTypeId", "dbo.UserTypes");
            DropIndex("dbo.Users", new[] { "UserTypeId" });
            DropColumn("dbo.Users", "UserTypeId");
            DropTable("dbo.UserTypes");
        }
    }
}
