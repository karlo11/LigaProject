namespace Liga.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial16 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Managers");
            AddColumn("dbo.Clubs", "ManagerID", c => c.Int());
            AlterColumn("dbo.Managers", "ID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Managers", "ID");
            CreateIndex("dbo.Managers", "ID");
            AddForeignKey("dbo.Managers", "ID", "dbo.Clubs", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Managers", "ID", "dbo.Clubs");
            DropIndex("dbo.Managers", new[] { "ID" });
            DropPrimaryKey("dbo.Managers");
            AlterColumn("dbo.Managers", "ID", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Clubs", "ManagerID");
            AddPrimaryKey("dbo.Managers", "ID");
        }
    }
}
