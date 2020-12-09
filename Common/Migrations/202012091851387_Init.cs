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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BankYouths", "UserId", "dbo.AppUsers");
            DropForeignKey("dbo.BankYouthPublications", "BankYouthId", "dbo.BankYouths");
            DropForeignKey("dbo.BankYouthDocumentations", "BankYouthId", "dbo.BankYouths");
            DropForeignKey("dbo.BankYouthAwards", "BankYouthId", "dbo.BankYouths");
            DropIndex("dbo.BankYouthPublications", new[] { "BankYouthId" });
            DropIndex("dbo.BankYouthDocumentations", new[] { "BankYouthId" });
            DropIndex("dbo.BankYouths", new[] { "UserId" });
            DropIndex("dbo.BankYouthAwards", new[] { "BankYouthId" });
            DropTable("dbo.BankYouthPublications");
            DropTable("dbo.BankYouthDocumentations");
            DropTable("dbo.BankYouths");
            DropTable("dbo.BankYouthAwards");
        }
    }
}
