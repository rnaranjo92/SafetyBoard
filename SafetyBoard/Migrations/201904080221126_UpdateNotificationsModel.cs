namespace SafetyBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateNotificationsModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Notifications", "Inspection_Id", "dbo.Inspections");
            DropIndex("dbo.Notifications", new[] { "Inspection_Id" });
            AddColumn("dbo.Notifications", "SafetyNews_Id", c => c.Int());
            AlterColumn("dbo.Notifications", "Inspection_Id", c => c.Int());
            CreateIndex("dbo.Notifications", "Inspection_Id");
            CreateIndex("dbo.Notifications", "SafetyNews_Id");
            AddForeignKey("dbo.Notifications", "SafetyNews_Id", "dbo.SafetyNews", "Id");
            AddForeignKey("dbo.Notifications", "Inspection_Id", "dbo.Inspections", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notifications", "Inspection_Id", "dbo.Inspections");
            DropForeignKey("dbo.Notifications", "SafetyNews_Id", "dbo.SafetyNews");
            DropIndex("dbo.Notifications", new[] { "SafetyNews_Id" });
            DropIndex("dbo.Notifications", new[] { "Inspection_Id" });
            AlterColumn("dbo.Notifications", "Inspection_Id", c => c.Int(nullable: false));
            DropColumn("dbo.Notifications", "SafetyNews_Id");
            CreateIndex("dbo.Notifications", "Inspection_Id");
            AddForeignKey("dbo.Notifications", "Inspection_Id", "dbo.Inspections", "Id", cascadeDelete: true);
        }
    }
}
