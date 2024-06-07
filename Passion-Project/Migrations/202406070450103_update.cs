namespace Passion_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MatchxTeams",
                c => new
                    {
                        MatchId = c.Int(nullable: false, identity: true),
                        TeamId = c.Int(nullable: false),
                        Goals = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MatchId)
                .ForeignKey("dbo.Teams", t => t.TeamId, cascadeDelete: true)
                .Index(t => t.TeamId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MatchxTeams", "TeamId", "dbo.Teams");
            DropIndex("dbo.MatchxTeams", new[] { "TeamId" });
            DropTable("dbo.MatchxTeams");
        }
    }
}
