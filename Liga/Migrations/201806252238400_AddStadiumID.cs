namespace Liga.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial18 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Stadia", "Stadium_ID", "dbo.Stadia");
            DropIndex("dbo.Stadia", new[] { "Stadium_ID" });
            AddColumn("dbo.Stadia", "ClubID", c => c.Int());
            DropColumn("dbo.Stadia", "Stadium_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Stadia", "Stadium_ID", c => c.Int());
            DropColumn("dbo.Stadia", "ClubID");
            CreateIndex("dbo.Stadia", "Stadium_ID");
            AddForeignKey("dbo.Stadia", "Stadium_ID", "dbo.Stadia", "ID");
        }
    }
}
