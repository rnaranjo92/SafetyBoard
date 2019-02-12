namespace SafetyBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'1e22e829-dd69-45c9-9688-5fd31bed3f02', N'guest@safetyboard.com', 0, N'AJXb+wsHPKij+pKPaFN5vV8DYzBXq9C7jxS8FXBAlfKBoW3nOZtXszCniy7v6RC/Dg==', N'9925c630-0113-4fde-b74e-6c5b9f005c68', NULL, 0, 0, NULL, 1, 0, N'guest@safetyboard.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'e7fbba4e-1124-4b7a-abe4-615d6dc7b1eb', N'admin@safetyboard.com', 0, N'AEWmKD47aXJfOOLGe7GVLJTa57y9QCQITGLA9sROX/yJNqpcl7lq+Xw/axI+5hmF+Q==', N'0fd7ec5a-f8cf-4c53-a273-34e1753e0319', NULL, 0, 0, NULL, 1, 0, N'admin@safetyboard.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'9d87d8d4-cd4e-4e47-91de-8587e3fafa8d', N'CanManagePosts')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'e7fbba4e-1124-4b7a-abe4-615d6dc7b1eb', N'9d87d8d4-cd4e-4e47-91de-8587e3fafa8d')
");


        }
        
        public override void Down()
        {
        }
    }
}
