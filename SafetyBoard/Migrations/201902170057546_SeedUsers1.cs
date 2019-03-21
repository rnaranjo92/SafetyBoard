namespace SafetyBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Organizations", "Name", c => c.String(nullable: false));

            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [DriversLicense], [AllowAccess],[OrganizationId],[FirstName],[LastName]) VALUES (N'01046dff-8d43-4084-94b2-dda35ff6589b', N'guest@safetyboard.com', 0, N'AAqsPhKfTth540+125Ju4X80N0IU+2zLBsbk9+rrO2Wd4CR2lfLFVbPXGDdbmlzuiQ==', N'c42b41fc-f12f-4ba7-946c-ed70fb995065', N'468465156', 0, 0, NULL, 1, 0, N'guest@safetyboard.com', N'kjdf380429430', 1,19471016,'Rolando','Naranjo')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [DriversLicense], [AllowAccess],[OrganizationId],[FirstName],[LastName]) VALUES (N'e7fbba4e-1124-4b7a-abe4-615d6dc7b1eb', N'admin@safetyboard.com', 0, N'AEWmKD47aXJfOOLGe7GVLJTa57y9QCQITGLA9sROX/yJNqpcl7lq+Xw/axI+5hmF+Q==', N'0fd7ec5a-f8cf-4c53-a273-34e1753e0319', N'1234', 0, 0, NULL, 1, 0, N'admin@safetyboard.com', N'', 0,19471015,'Rolando','Naranjo')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'9d87d8d4-cd4e-4e47-91de-8587e3fafa8d', N'CanManagePosts')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'e7184e57-ac8e-4965-ac80-67a1f14dc7d1', N'NormalUsers')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'01046dff-8d43-4084-94b2-dda35ff6589b', N'e7184e57-ac8e-4965-ac80-67a1f14dc7d1')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'e7fbba4e-1124-4b7a-abe4-615d6dc7b1eb', N'9d87d8d4-cd4e-4e47-91de-8587e3fafa8d')

");
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Organizations", "Name", c => c.String());
        }
    }
}
