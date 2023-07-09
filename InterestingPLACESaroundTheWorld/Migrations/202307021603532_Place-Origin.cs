namespace InterestingPLACESaroundTheWorld.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PlaceOrigin : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Places", "OriginID", c => c.Int(nullable: false));
            CreateIndex("dbo.Places", "OriginID");
            AddForeignKey("dbo.Places", "OriginID", "dbo.Origins", "OriginID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Places", "OriginID", "dbo.Origins");
            DropIndex("dbo.Places", new[] { "OriginID" });
            DropColumn("dbo.Places", "OriginID");
        }
    }
}
