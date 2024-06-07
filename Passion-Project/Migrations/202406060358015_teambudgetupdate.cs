namespace Passion_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class teambudgetupdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Teams", "TeamBudget", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Teams", "TeamBudget", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
