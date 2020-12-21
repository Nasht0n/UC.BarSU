namespace Common.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BankYouthAwards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BankYouthId = c.Int(nullable: false),
                        Description = c.String(nullable: false),
                        Date = c.String(nullable: false),
                        Filename = c.String(nullable: false),
                        Path = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BankYouths", t => t.BankYouthId, cascadeDelete: true)
                .Index(t => t.BankYouthId);
            
            CreateTable(
                "dbo.BankYouths",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Surname = c.String(nullable: false, maxLength: 255),
                        Firstname = c.String(nullable: false, maxLength: 255),
                        Patronymic = c.String(nullable: false, maxLength: 255),
                        DateOfBirthday = c.DateTime(nullable: false),
                        MobilePhone = c.String(nullable: false, maxLength: 150),
                        Email = c.String(nullable: false, maxLength: 255),
                        Area = c.String(nullable: false, maxLength: 255),
                        District = c.String(nullable: false, maxLength: 255),
                        Settlement = c.String(nullable: false, maxLength: 255),
                        YearOfAddmission = c.Int(nullable: false),
                        Speciality = c.String(nullable: false, maxLength: 255),
                        Qualification = c.String(nullable: false, maxLength: 255),
                        YearOfInclusion = c.Int(nullable: false),
                        Merit = c.String(nullable: false),
                        AverageBall = c.Double(nullable: false),
                        IsExcellentStudent = c.Boolean(nullable: false),
                        Incentives = c.String(nullable: false),
                        ProtocolNumber = c.String(nullable: false, maxLength: 150),
                        ProtocolDate = c.DateTime(nullable: false),
                        Fullname = c.String(nullable: false, maxLength: 255),
                        Post = c.String(nullable: false, maxLength: 255),
                        AcademicStatus = c.String(nullable: false, maxLength: 255),
                        AcademicDegree = c.String(nullable: false, maxLength: 255),
                        CreateDate = c.DateTime(nullable: false),
                        EditDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AppUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.BankYouthDocumentations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BankYouthId = c.Int(nullable: false),
                        Description = c.String(nullable: false),
                        RegNumber = c.String(nullable: false),
                        RegDate = c.DateTime(nullable: false),
                        Filename = c.String(nullable: false),
                        Path = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BankYouths", t => t.BankYouthId, cascadeDelete: true)
                .Index(t => t.BankYouthId);
            
            CreateTable(
                "dbo.BankYouthPublications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BankYouthId = c.Int(nullable: false),
                        Description = c.String(nullable: false),
                        Filename = c.String(nullable: false),
                        Path = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BankYouths", t => t.BankYouthId, cascadeDelete: true)
                .Index(t => t.BankYouthId);
            
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
                        ProjectName = c.String(nullable: false),
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
                        Title = c.String(nullable: false, maxLength: 255),
                        Message = c.String(nullable: false),
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
            DropForeignKey("dbo.ImplementationResearchActs", "UserId", "dbo.AppUsers");
            DropForeignKey("dbo.ImplementationResearchActLifeCycles", "ActId", "dbo.ImplementationResearchActs");
            DropForeignKey("dbo.ImplementationResearchActEmployees", "ActId", "dbo.ImplementationResearchActs");
            DropForeignKey("dbo.ImplementationResearchActAuthors", "ActId", "dbo.ImplementationResearchActs");
            DropForeignKey("dbo.ScienceProjects", "UserId", "dbo.AppUsers");
            DropForeignKey("dbo.ScienceProjects", "StateId", "dbo.ProjectStates");
            DropForeignKey("dbo.ScienceProjects", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Departments", "FacultyId", "dbo.Faculties");
            DropForeignKey("dbo.Casts", "ProjectId", "dbo.ScienceProjects");
            DropForeignKey("dbo.BankYouths", "UserId", "dbo.AppUsers");
            DropForeignKey("dbo.BankYouthPublications", "BankYouthId", "dbo.BankYouths");
            DropForeignKey("dbo.BankYouthDocumentations", "BankYouthId", "dbo.BankYouths");
            DropForeignKey("dbo.BankYouthAwards", "BankYouthId", "dbo.BankYouths");
            DropIndex("dbo.AppUserPermissions", new[] { "PermissionId" });
            DropIndex("dbo.AppUserPermissions", new[] { "UserId" });
            DropIndex("dbo.ImplementationStudentActLifeCycles", new[] { "ActId" });
            DropIndex("dbo.ImplementationStudentActs", new[] { "UserId" });
            DropIndex("dbo.ImplementationStudentActComissions", new[] { "ActId" });
            DropIndex("dbo.Stages", new[] { "StageTypeId" });
            DropIndex("dbo.Stages", new[] { "ProjectId" });
            DropIndex("dbo.ScienceProjectReports", new[] { "StageId" });
            DropIndex("dbo.ImplementationResearchActLifeCycles", new[] { "ActId" });
            DropIndex("dbo.ImplementationResearchActEmployees", new[] { "ActId" });
            DropIndex("dbo.ImplementationResearchActs", new[] { "UserId" });
            DropIndex("dbo.ImplementationResearchActAuthors", new[] { "ActId" });
            DropIndex("dbo.Departments", new[] { "FacultyId" });
            DropIndex("dbo.ScienceProjects", new[] { "StateId" });
            DropIndex("dbo.ScienceProjects", new[] { "DepartmentId" });
            DropIndex("dbo.ScienceProjects", new[] { "UserId" });
            DropIndex("dbo.Casts", new[] { "ProjectId" });
            DropIndex("dbo.BankYouthPublications", new[] { "BankYouthId" });
            DropIndex("dbo.BankYouthDocumentations", new[] { "BankYouthId" });
            DropIndex("dbo.BankYouths", new[] { "UserId" });
            DropIndex("dbo.BankYouthAwards", new[] { "BankYouthId" });
            DropTable("dbo.AppUserPermissions");
            DropTable("dbo.ImplementationStudentActLifeCycles");
            DropTable("dbo.ImplementationStudentActs");
            DropTable("dbo.ImplementationStudentActComissions");
            DropTable("dbo.StageTypes");
            DropTable("dbo.Stages");
            DropTable("dbo.ScienceProjectReports");
            DropTable("dbo.ImplementationResearchActLifeCycles");
            DropTable("dbo.ImplementationResearchActEmployees");
            DropTable("dbo.ImplementationResearchActs");
            DropTable("dbo.ImplementationResearchActAuthors");
            DropTable("dbo.AppPermissions");
            DropTable("dbo.AppFeedbacks");
            DropTable("dbo.ProjectStates");
            DropTable("dbo.Faculties");
            DropTable("dbo.Departments");
            DropTable("dbo.ScienceProjects");
            DropTable("dbo.Casts");
            DropTable("dbo.AppUsers");
            DropTable("dbo.BankYouthPublications");
            DropTable("dbo.BankYouthDocumentations");
            DropTable("dbo.BankYouths");
            DropTable("dbo.BankYouthAwards");
        }
    }
}
