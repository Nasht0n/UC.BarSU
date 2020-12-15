namespace Common.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCreateAndEditDateToBY : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BankYouths", "CreateDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.BankYouths", "EditDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BankYouths", "EditDate");
            DropColumn("dbo.BankYouths", "CreateDate");
        }
    }
}
