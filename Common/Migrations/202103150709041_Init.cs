namespace Common.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PaidServices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Address = c.String(nullable: false, maxLength: 255),
                        OrderNumber = c.String(nullable: false, maxLength: 50),
                        OrderDate = c.DateTime(nullable: false),
                        ServiceName = c.String(nullable: false, maxLength: 255),
                        PeriodOfExecution = c.String(nullable: false, maxLength: 255),
                        TotalCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Fullname = c.String(nullable: false, maxLength: 255),
                        Post = c.String(nullable: false, maxLength: 255),
                        Degree = c.String(nullable: false, maxLength: 255),
                        Status = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PaidServices");
        }
    }
}
