namespace BankProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changes1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Accounts", "EmailAddress", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Accounts", "EmailAddress", c => c.String(nullable: false));
        }
    }
}
