namespace Common.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AppChanges : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AppFeedback", newName: "AppFeedbacks");
            RenameTable(name: "dbo.AppPermission", newName: "AppPermissions");
            RenameTable(name: "dbo.AppUser", newName: "AppUsers");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.AppUsers", newName: "AppUser");
            RenameTable(name: "dbo.AppPermissions", newName: "AppPermission");
            RenameTable(name: "dbo.AppFeedbacks", newName: "AppFeedback");
        }
    }
}
