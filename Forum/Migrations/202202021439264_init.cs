namespace Forum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Announcements",
                c => new
                    {
                        AnnouncementID = c.Int(nullable: false, identity: true),
                        AuthorID = c.String(),
                        Name = c.String(),
                        TextContent = c.String(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.AnnouncementID)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Fora",
                c => new
                    {
                        ForumID = c.Int(nullable: false, identity: true),
                        AuthorID = c.String(maxLength: 128),
                        Name = c.String(),
                        Description = c.String(),
                        Category = c.String(),
                    })
                .PrimaryKey(t => t.ForumID)
                .ForeignKey("dbo.AspNetUsers", t => t.AuthorID)
                .Index(t => t.AuthorID);
            
            CreateTable(
                "dbo.PinThreads",
                c => new
                    {
                        PinThreadID = c.Int(nullable: false, identity: true),
                        ForumID = c.Int(nullable: false),
                        AuthorID = c.String(maxLength: 128),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.PinThreadID)
                .ForeignKey("dbo.AspNetUsers", t => t.AuthorID)
                .ForeignKey("dbo.Fora", t => t.ForumID, cascadeDelete: true)
                .Index(t => t.ForumID)
                .Index(t => t.AuthorID);
            
            CreateTable(
                "dbo.PinPosts",
                c => new
                    {
                        PinPostID = c.Int(nullable: false, identity: true),
                        ThreadID = c.Int(nullable: false),
                        AuthorID = c.String(maxLength: 128),
                        TextContent = c.String(),
                        PinThread_PinThreadID = c.Int(),
                    })
                .PrimaryKey(t => t.PinPostID)
                .ForeignKey("dbo.AspNetUsers", t => t.AuthorID)
                .ForeignKey("dbo.Threads", t => t.ThreadID, cascadeDelete: true)
                .ForeignKey("dbo.PinThreads", t => t.PinThread_PinThreadID)
                .Index(t => t.ThreadID)
                .Index(t => t.AuthorID)
                .Index(t => t.PinThread_PinThreadID);
            
            CreateTable(
                "dbo.Threads",
                c => new
                    {
                        ThreadID = c.Int(nullable: false, identity: true),
                        ForumID = c.Int(nullable: false),
                        AuthorID = c.String(maxLength: 128),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ThreadID)
                .ForeignKey("dbo.AspNetUsers", t => t.AuthorID)
                .ForeignKey("dbo.Fora", t => t.ForumID, cascadeDelete: true)
                .Index(t => t.ForumID)
                .Index(t => t.AuthorID);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        PostID = c.Int(nullable: false, identity: true),
                        ThreadID = c.Int(nullable: false),
                        AuthorID = c.String(maxLength: 128),
                        TextContent = c.String(),
                        PinThread_PinThreadID = c.Int(),
                    })
                .PrimaryKey(t => t.PostID)
                .ForeignKey("dbo.AspNetUsers", t => t.AuthorID)
                .ForeignKey("dbo.Threads", t => t.ThreadID, cascadeDelete: true)
                .ForeignKey("dbo.PinThreads", t => t.PinThread_PinThreadID)
                .Index(t => t.ThreadID)
                .Index(t => t.AuthorID)
                .Index(t => t.PinThread_PinThreadID);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        MessageID = c.Int(nullable: false, identity: true),
                        AuthorID = c.String(),
                        ReceiverID = c.String(),
                        Content = c.String(),
                        UserAuthor_Id = c.String(maxLength: 128),
                        UserReceiver_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.MessageID)
                .ForeignKey("dbo.AspNetUsers", t => t.UserAuthor_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserReceiver_Id)
                .Index(t => t.UserAuthor_Id)
                .Index(t => t.UserReceiver_Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Messages", "UserReceiver_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Messages", "UserAuthor_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Posts", "PinThread_PinThreadID", "dbo.PinThreads");
            DropForeignKey("dbo.PinPosts", "PinThread_PinThreadID", "dbo.PinThreads");
            DropForeignKey("dbo.Posts", "ThreadID", "dbo.Threads");
            DropForeignKey("dbo.Posts", "AuthorID", "dbo.AspNetUsers");
            DropForeignKey("dbo.PinPosts", "ThreadID", "dbo.Threads");
            DropForeignKey("dbo.Threads", "ForumID", "dbo.Fora");
            DropForeignKey("dbo.Threads", "AuthorID", "dbo.AspNetUsers");
            DropForeignKey("dbo.PinPosts", "AuthorID", "dbo.AspNetUsers");
            DropForeignKey("dbo.PinThreads", "ForumID", "dbo.Fora");
            DropForeignKey("dbo.PinThreads", "AuthorID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Fora", "AuthorID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Announcements", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Messages", new[] { "UserReceiver_Id" });
            DropIndex("dbo.Messages", new[] { "UserAuthor_Id" });
            DropIndex("dbo.Posts", new[] { "PinThread_PinThreadID" });
            DropIndex("dbo.Posts", new[] { "AuthorID" });
            DropIndex("dbo.Posts", new[] { "ThreadID" });
            DropIndex("dbo.Threads", new[] { "AuthorID" });
            DropIndex("dbo.Threads", new[] { "ForumID" });
            DropIndex("dbo.PinPosts", new[] { "PinThread_PinThreadID" });
            DropIndex("dbo.PinPosts", new[] { "AuthorID" });
            DropIndex("dbo.PinPosts", new[] { "ThreadID" });
            DropIndex("dbo.PinThreads", new[] { "AuthorID" });
            DropIndex("dbo.PinThreads", new[] { "ForumID" });
            DropIndex("dbo.Fora", new[] { "AuthorID" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Announcements", new[] { "User_Id" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Messages");
            DropTable("dbo.Posts");
            DropTable("dbo.Threads");
            DropTable("dbo.PinPosts");
            DropTable("dbo.PinThreads");
            DropTable("dbo.Fora");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Announcements");
        }
    }
}
