namespace Liga.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clubs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(),
                        League_ID = c.Int(),
                        Stadium_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Leagues", t => t.League_ID)
                .ForeignKey("dbo.Stadia", t => t.Stadium_ID)
                .Index(t => t.League_ID)
                .Index(t => t.Stadium_ID);
            
            CreateTable(
                "dbo.Leagues",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DateOfFoundation = c.DateTime(nullable: false),
                        Country = c.String(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Managers",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        OIB = c.String(nullable: false, maxLength: 11),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Clubs", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.Matches",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        HomeID = c.Int(),
                        AwayID = c.Int(),
                        GoalsScoredHomeTeam = c.Int(nullable: false),
                        GoalsScoredAwayTeam = c.Int(nullable: false),
                        GameDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Stadia",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        DateOfBuild = c.DateTime(nullable: false),
                        City = c.String(nullable: false),
                        Capacity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MatchClubs",
                c => new
                    {
                        Match_ID = c.Int(nullable: false),
                        Club_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Match_ID, t.Club_ID })
                .ForeignKey("dbo.Matches", t => t.Match_ID, cascadeDelete: true)
                .ForeignKey("dbo.Clubs", t => t.Club_ID, cascadeDelete: true)
                .Index(t => t.Match_ID)
                .Index(t => t.Club_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clubs", "Stadium_ID", "dbo.Stadia");
            DropForeignKey("dbo.MatchClubs", "Club_ID", "dbo.Clubs");
            DropForeignKey("dbo.MatchClubs", "Match_ID", "dbo.Matches");
            DropForeignKey("dbo.Managers", "ID", "dbo.Clubs");
            DropForeignKey("dbo.Clubs", "League_ID", "dbo.Leagues");
            DropIndex("dbo.MatchClubs", new[] { "Club_ID" });
            DropIndex("dbo.MatchClubs", new[] { "Match_ID" });
            DropIndex("dbo.Managers", new[] { "ID" });
            DropIndex("dbo.Clubs", new[] { "Stadium_ID" });
            DropIndex("dbo.Clubs", new[] { "League_ID" });
            DropTable("dbo.MatchClubs");
            DropTable("dbo.Stadia");
            DropTable("dbo.Matches");
            DropTable("dbo.Managers");
            DropTable("dbo.Leagues");
            DropTable("dbo.Clubs");
        }
    }
}
