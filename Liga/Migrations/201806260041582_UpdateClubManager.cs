namespace Liga.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateClubManager : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Clubs", "ManagerID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Clubs", "ManagerID", c => c.Int());
        }
    }
}
