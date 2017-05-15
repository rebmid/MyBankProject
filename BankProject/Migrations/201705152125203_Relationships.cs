namespace BankProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Relationships : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Transactions", "AccountNumber");
            AddForeignKey("dbo.Transactions", "AccountNumber", "dbo.Accounts", "AccountNumber", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "AccountNumber", "dbo.Accounts");
            DropIndex("dbo.Transactions", new[] { "AccountNumber" });
        }
    }
}
