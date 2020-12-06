namespace Common.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ResearchActAddProjectName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ImplementationResearchActs", "ProjectName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ImplementationResearchActs", "ProjectName");
        }
    }
}
