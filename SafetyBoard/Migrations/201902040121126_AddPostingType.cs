namespace SafetyBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPostingType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PostingTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        SafetyCategory = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Postings", "PostingTypeId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Postings", "PostingTypeId");
            AddForeignKey("dbo.Postings", "PostingTypeId", "dbo.PostingTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Postings", "PostingTypeId", "dbo.PostingTypes");
            DropIndex("dbo.Postings", new[] { "PostingTypeId" });
            DropColumn("dbo.Postings", "PostingTypeId");
            DropTable("dbo.PostingTypes");
        }
    }
}
