namespace Common.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingResearchActsEntities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ImplementationResearchActAuthors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ActId = c.Int(nullable: false),
                        Fullname = c.String(nullable: false),
                        Post = c.String(nullable: false),
                        AcademicDegree = c.String(),
                        AcademicStatus = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ImplementationResearchActs", t => t.ActId, cascadeDelete: true)
                .Index(t => t.ActId);
            
            CreateTable(
                "dbo.ImplementationResearchActs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ImplementingResult = c.String(nullable: false),
                        Process = c.String(nullable: false),
                        Characteristic = c.String(nullable: false),
                        ImplementationForm = c.String(nullable: false),
                        UnitUsing = c.String(nullable: false),
                        FeasibilityOfIntroducing = c.String(nullable: false),
                        HeadUnit = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AppUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.ImplementationResearchActEmployees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ActId = c.Int(nullable: false),
                        Fullname = c.String(nullable: false),
                        Post = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ImplementationResearchActs", t => t.ActId, cascadeDelete: true)
                .Index(t => t.ActId);
            
            CreateTable(
                "dbo.ImplementationResearchActLifeCycles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ActId = c.Int(nullable: false),
                        Title = c.String(nullable: false),
                        Message = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ImplementationResearchActs", t => t.ActId, cascadeDelete: true)
                .Index(t => t.ActId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ImplementationResearchActs", "UserId", "dbo.AppUsers");
            DropForeignKey("dbo.ImplementationResearchActLifeCycles", "ActId", "dbo.ImplementationResearchActs");
            DropForeignKey("dbo.ImplementationResearchActEmployees", "ActId", "dbo.ImplementationResearchActs");
            DropForeignKey("dbo.ImplementationResearchActAuthors", "ActId", "dbo.ImplementationResearchActs");
            DropIndex("dbo.ImplementationResearchActLifeCycles", new[] { "ActId" });
            DropIndex("dbo.ImplementationResearchActEmployees", new[] { "ActId" });
            DropIndex("dbo.ImplementationResearchActs", new[] { "UserId" });
            DropIndex("dbo.ImplementationResearchActAuthors", new[] { "ActId" });
            DropTable("dbo.ImplementationResearchActLifeCycles");
            DropTable("dbo.ImplementationResearchActEmployees");
            DropTable("dbo.ImplementationResearchActs");
            DropTable("dbo.ImplementationResearchActAuthors");
        }
    }
}
