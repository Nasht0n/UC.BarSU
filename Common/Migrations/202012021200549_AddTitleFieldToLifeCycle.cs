namespace Common.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTitleFieldToLifeCycle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ImplementationStudentActLifeCycles", "Title", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.ImplementationStudentActLifeCycles", "Message", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ImplementationStudentActLifeCycles", "Message", c => c.String(nullable: false, maxLength: 255));
            DropColumn("dbo.ImplementationStudentActLifeCycles", "Title");
        }
    }
}
