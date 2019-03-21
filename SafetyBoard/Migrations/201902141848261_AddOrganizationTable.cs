namespace SafetyBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOrganizationTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Organizations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Organization", c => c.String(nullable: false, maxLength: 255));
            DropTable("dbo.Organizations");
        }
    }
}
