namespace Common.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAppUserField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PaidServices", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.PaidServices", "UserId");
            AddForeignKey("dbo.PaidServices", "UserId", "dbo.AppUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PaidServices", "UserId", "dbo.AppUsers");
            DropIndex("dbo.PaidServices", new[] { "UserId" });
            DropColumn("dbo.PaidServices", "UserId");
        }
    }
}
