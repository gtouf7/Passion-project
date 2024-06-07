namespace Passion_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Scorers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Fixtures", "HomeGoals", c => c.Int(nullable: false));
            AddColumn("dbo.Fixtures", "AwayGoals", c => c.Int(nullable: false));
            AlterColumn("dbo.Fixtures", "MatchRound", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Fixtures", "MatchRound", c => c.Int(nullable: false));
            DropColumn("dbo.Fixtures", "AwayGoals");
            DropColumn("dbo.Fixtures", "HomeGoals");
        }
    }
}
