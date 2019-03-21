namespace SafetyBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addInspection : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Inspections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InspectorId = c.String(nullable: false, maxLength: 128),
                        DateTime = c.DateTime(nullable: false),
                        OrganizationId = c.Int(nullable: false),
                        InspectionTypeId = c.Byte(nullable: false),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PostingTypes", t => t.InspectionTypeId)
                .ForeignKey("dbo.AspNetUsers", t => t.InspectorId, cascadeDelete: true)
                .ForeignKey("dbo.Organizations", t => t.OrganizationId)
                .Index(t => t.InspectorId)
                .Index(t => t.OrganizationId)
                .Index(t => t.InspectionTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Inspections", "OrganizationId", "dbo.Organizations");
            DropForeignKey("dbo.Inspections", "InspectorId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Inspections", "InspectionTypeId", "dbo.PostingTypes");
            DropIndex("dbo.Inspections", new[] { "InspectionTypeId" });
            DropIndex("dbo.Inspections", new[] { "OrganizationId" });
            DropIndex("dbo.Inspections", new[] { "InspectorId" });
            DropTable("dbo.Inspections");
        }
    }
}
