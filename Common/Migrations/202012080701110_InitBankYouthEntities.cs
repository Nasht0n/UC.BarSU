namespace Common.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitBankYouthEntities : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BankYouthDocumentations", "BankYouth_Id", "dbo.BankYouths");
            DropIndex("dbo.BankYouthDocumentations", new[] { "BankYouth_Id" });
            RenameColumn(table: "dbo.BankYouthDocumentations", name: "BankYouth_Id", newName: "BankYouthId");
            AlterColumn("dbo.BankYouthDocumentations", "BankYouthId", c => c.Int(nullable: false));
            CreateIndex("dbo.BankYouthDocumentations", "BankYouthId");
            AddForeignKey("dbo.BankYouthDocumentations", "BankYouthId", "dbo.BankYouths", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BankYouthDocumentations", "BankYouthId", "dbo.BankYouths");
            DropIndex("dbo.BankYouthDocumentations", new[] { "BankYouthId" });
            AlterColumn("dbo.BankYouthDocumentations", "BankYouthId", c => c.Int());
            RenameColumn(table: "dbo.BankYouthDocumentations", name: "BankYouthId", newName: "BankYouth_Id");
            CreateIndex("dbo.BankYouthDocumentations", "BankYouth_Id");
            AddForeignKey("dbo.BankYouthDocumentations", "BankYouth_Id", "dbo.BankYouths", "Id");
        }
    }
}
