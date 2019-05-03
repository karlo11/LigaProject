namespace Liga.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateClub : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clubs", "DateOfFoundation", c => c.DateTime(nullable: false));
            AddColumn("dbo.Clubs", "PhoneNumber", c => c.String());
            AlterColumn("dbo.Managers", "OIB", c => c.String(maxLength: 11));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Managers", "OIB", c => c.String(nullable: false, maxLength: 11));
            DropColumn("dbo.Clubs", "PhoneNumber");
            DropColumn("dbo.Clubs", "DateOfFoundation");
        }
    }
}
