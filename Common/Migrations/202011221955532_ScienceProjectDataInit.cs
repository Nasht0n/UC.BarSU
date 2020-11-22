﻿namespace Common.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ScienceProjectDataInit : DbMigration
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
                        Receptionist = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .ForeignKey("dbo.ProjectStates", t => t.StateId, cascadeDelete: true)
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ScienceProjectReports", "StageId", "dbo.Stages");
            DropForeignKey("dbo.Stages", "StageTypeId", "dbo.StageTypes");
            DropForeignKey("dbo.Stages", "ProjectId", "dbo.ScienceProjects");
            DropForeignKey("dbo.ScienceProjects", "StateId", "dbo.ProjectStates");
            DropForeignKey("dbo.ScienceProjects", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Departments", "FacultyId", "dbo.Faculties");
            DropForeignKey("dbo.Casts", "ProjectId", "dbo.ScienceProjects");
            DropIndex("dbo.Stages", new[] { "StageTypeId" });
            DropIndex("dbo.Stages", new[] { "ProjectId" });
            DropIndex("dbo.ScienceProjectReports", new[] { "StageId" });
            DropIndex("dbo.Departments", new[] { "FacultyId" });
            DropIndex("dbo.ScienceProjects", new[] { "StateId" });
            DropIndex("dbo.ScienceProjects", new[] { "DepartmentId" });
            DropIndex("dbo.Casts", new[] { "ProjectId" });
            DropTable("dbo.StageTypes");
            DropTable("dbo.Stages");
            DropTable("dbo.ScienceProjectReports");
            DropTable("dbo.ProjectStates");
            DropTable("dbo.Faculties");
            DropTable("dbo.Departments");
            DropTable("dbo.ScienceProjects");
            DropTable("dbo.Casts");
        }
    }
}
