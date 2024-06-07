namespace Passion_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class playerFK : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Players", "PlayerTeamId", c => c.Int(nullable: false));
            CreateIndex("dbo.Players", "PlayerTeamId");
            AddForeignKey("dbo.Players", "PlayerTeamId", "dbo.Teams", "TeamId", cascadeDelete: true);
            DropColumn("dbo.Players", "PlayerTeam");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Players", "PlayerTeam", c => c.Int(nullable: false));
            DropForeignKey("dbo.Players", "PlayerTeamId", "dbo.Teams");
            DropIndex("dbo.Players", new[] { "PlayerTeamId" });
            DropColumn("dbo.Players", "PlayerTeamId");
        }
    }
}
