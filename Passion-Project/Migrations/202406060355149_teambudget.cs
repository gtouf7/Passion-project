namespace Passion_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class teambudget : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teams", "TeamBudget", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Teams", "TeamBudget");
        }
    }
}
