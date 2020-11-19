namespace Common.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AppFeedback",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 25),
                        Email = c.String(nullable: false, maxLength: 150),
                        Title = c.String(nullable: false, maxLength: 255),
                        Message = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AppPermission",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 255),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AppUserPermissions",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        PermissionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.PermissionId })
                .ForeignKey("dbo.AppPermission", t => t.PermissionId, cascadeDelete: true)
                .ForeignKey("dbo.AppUser", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.PermissionId);
            
            CreateTable(
                "dbo.AppUser",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 25),
                        Password = c.String(nullable: false, maxLength: 25),
                        Fullname = c.String(nullable: false, maxLength: 255),
                        IsEnabled = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AppUserPermissions", "UserId", "dbo.AppUser");
            DropForeignKey("dbo.AppUserPermissions", "PermissionId", "dbo.AppPermission");
            DropIndex("dbo.AppUserPermissions", new[] { "PermissionId" });
            DropIndex("dbo.AppUserPermissions", new[] { "UserId" });
            DropTable("dbo.AppUser");
            DropTable("dbo.AppUserPermissions");
            DropTable("dbo.AppPermission");
            DropTable("dbo.AppFeedback");
        }
    }
}
