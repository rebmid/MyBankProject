namespace BankProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changes3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Accounts", "EmailAddress", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Accounts", "EmailAddress", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
