namespace SafetyBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeInspectorToUser : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Inspections", name: "InspectorId", newName: "UserId");
            RenameIndex(table: "dbo.Inspections", name: "IX_InspectorId", newName: "IX_UserId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Inspections", name: "IX_UserId", newName: "IX_InspectorId");
            RenameColumn(table: "dbo.Inspections", name: "UserId", newName: "InspectorId");
        }
    }
}
