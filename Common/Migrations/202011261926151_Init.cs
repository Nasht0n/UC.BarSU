namespace Common.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Casts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProjectId = c.Int(nullable: false),
                        Degree = c.String(nullable: false),
                        Status = c.String(nullable: false),
                        Fullname = c.String(nullable: false),
                        Post = c.String(nullable: false),
                        IsManager = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ScienceProjects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.ScienceProjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        StateId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                        Program = c.String(nullable: false, maxLength: 255),
                        OrderNumber = c.String(nullable: false, maxLength: 25),
                        OrderDate = c.DateTime(nullable: false),
                        RegistrationNumber = c.String(nullable: false, maxLength: 25),
                        RegistrationDate = c.DateTime(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .ForeignKey("dbo.ProjectStates", t => t.StateId, cascadeDelete: true)
                .ForeignKey("dbo.AppUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.DepartmentId)
                .Index(t => t.StateId);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FacultyId = c.Int(nullable: false),
                        Fullname = c.String(nullable: false, maxLength: 255),
                        Shortname = c.String(maxLength: 25),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Faculties", t => t.FacultyId, cascadeDelete: true)
                .Index(t => t.FacultyId);
            
            CreateTable(
                "dbo.Faculties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fullname = c.String(nullable: false, maxLength: 255),
                        Shortname = c.String(nullable: false, maxLength: 25),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProjectStates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AppUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 25),
                        Password = c.String(nullable: false, maxLength: 25),
                        Fullname = c.String(nullable: false, maxLength: 255),
                        IsEnabled = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AppFeedbacks",
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
                "dbo.AppPermissions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 255),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ScienceProjectReports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StageId = c.Int(nullable: false),
                        Filename = c.String(nullable: false, maxLength: 255),
                        Path = c.String(nullable: false, maxLength: 255),
                        UploadDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Stages", t => t.StageId, cascadeDelete: true)
                .Index(t => t.StageId);
            
            CreateTable(
                "dbo.Stages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProjectId = c.Int(nullable: false),
                        StageTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ScienceProjects", t => t.ProjectId, cascadeDelete: true)
                .ForeignKey("dbo.StageTypes", t => t.StageTypeId, cascadeDelete: true)
                .Index(t => t.ProjectId)
                .Index(t => t.StageTypeId);
            
            CreateTable(
                "dbo.StageTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ImplementationStudentActComissions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ActId = c.Int(nullable: false),
                        Fullname = c.String(nullable: false, maxLength: 255),
                        Post = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ImplementationStudentActs", t => t.ActId, cascadeDelete: true)
                .Index(t => t.ActId);
            
            CreateTable(
                "dbo.ImplementationStudentActs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Scope = c.String(nullable: false, maxLength: 255),
                        Department = c.String(nullable: false),
                        Result = c.String(nullable: false),
                        Author = c.String(nullable: false, maxLength: 255),
                        ProjectName = c.String(nullable: false),
                        PracticalTasks = c.String(nullable: false),
                        EconomicEfficiency = c.String(nullable: false),
                        ProtocolDate = c.DateTime(nullable: false),
                        ProtocolNumber = c.String(nullable: false),
                        RegisterDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AppUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.ImplementationStudentActLifeCycles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ActId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Message = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ImplementationStudentActs", t => t.ActId, cascadeDelete: true)
                .Index(t => t.ActId);
            
            CreateTable(
                "dbo.AppUserPermissions",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        PermissionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.PermissionId })
                .ForeignKey("dbo.AppPermissions", t => t.PermissionId, cascadeDelete: true)
                .ForeignKey("dbo.AppUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.PermissionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AppUserPermissions", "UserId", "dbo.AppUsers");
            DropForeignKey("dbo.AppUserPermissions", "PermissionId", "dbo.AppPermissions");
            DropForeignKey("dbo.ImplementationStudentActs", "UserId", "dbo.AppUsers");
            DropForeignKey("dbo.ImplementationStudentActLifeCycles", "ActId", "dbo.ImplementationStudentActs");
            DropForeignKey("dbo.ImplementationStudentActComissions", "ActId", "dbo.ImplementationStudentActs");
            DropForeignKey("dbo.ScienceProjectReports", "StageId", "dbo.Stages");
            DropForeignKey("dbo.Stages", "StageTypeId", "dbo.StageTypes");
            DropForeignKey("dbo.Stages", "ProjectId", "dbo.ScienceProjects");
            DropForeignKey("dbo.ScienceProjects", "UserId", "dbo.AppUsers");
            DropForeignKey("dbo.ScienceProjects", "StateId", "dbo.ProjectStates");
            DropForeignKey("dbo.ScienceProjects", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Departments", "FacultyId", "dbo.Faculties");
            DropForeignKey("dbo.Casts", "ProjectId", "dbo.ScienceProjects");
            DropIndex("dbo.AppUserPermissions", new[] { "PermissionId" });
            DropIndex("dbo.AppUserPermissions", new[] { "UserId" });
            DropIndex("dbo.ImplementationStudentActLifeCycles", new[] { "ActId" });
            DropIndex("dbo.ImplementationStudentActs", new[] { "UserId" });
            DropIndex("dbo.ImplementationStudentActComissions", new[] { "ActId" });
            DropIndex("dbo.Stages", new[] { "StageTypeId" });
            DropIndex("dbo.Stages", new[] { "ProjectId" });
            DropIndex("dbo.ScienceProjectReports", new[] { "StageId" });
            DropIndex("dbo.Departments", new[] { "FacultyId" });
            DropIndex("dbo.ScienceProjects", new[] { "StateId" });
            DropIndex("dbo.ScienceProjects", new[] { "DepartmentId" });
            DropIndex("dbo.ScienceProjects", new[] { "UserId" });
            DropIndex("dbo.Casts", new[] { "ProjectId" });
            DropTable("dbo.AppUserPermissions");
            DropTable("dbo.ImplementationStudentActLifeCycles");
            DropTable("dbo.ImplementationStudentActs");
            DropTable("dbo.ImplementationStudentActComissions");
            DropTable("dbo.StageTypes");
            DropTable("dbo.Stages");
            DropTable("dbo.ScienceProjectReports");
            DropTable("dbo.AppPermissions");
            DropTable("dbo.AppFeedbacks");
            DropTable("dbo.AppUsers");
            DropTable("dbo.ProjectStates");
            DropTable("dbo.Faculties");
            DropTable("dbo.Departments");
            DropTable("dbo.ScienceProjects");
            DropTable("dbo.Casts");
        }
    }
}
