namespace Liga.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial19 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Matches", "HomeTeamID", c => c.Int(nullable: false));
            AddColumn("dbo.Matches", "AwayTeamID", c => c.Int(nullable: false));
            CreateIndex("dbo.Matches", "HomeTeamID");
            CreateIndex("dbo.Matches", "AwayTeamID");
            AddForeignKey("dbo.Matches", "AwayTeamID", "dbo.Clubs", "ID");
            AddForeignKey("dbo.Matches", "HomeTeamID", "dbo.Clubs", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Matches", "HomeTeamID", "dbo.Clubs");
            DropForeignKey("dbo.Matches", "AwayTeamID", "dbo.Clubs");
            DropIndex("dbo.Matches", new[] { "AwayTeamID" });
            DropIndex("dbo.Matches", new[] { "HomeTeamID" });
            DropColumn("dbo.Matches", "AwayTeamID");
            DropColumn("dbo.Matches", "HomeTeamID");
        }
    }
}
