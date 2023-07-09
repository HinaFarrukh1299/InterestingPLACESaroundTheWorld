namespace InterestingPLACESaroundTheWorld.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TraditionPlaces : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Traditions",
                c => new
                    {
                        TraditionID = c.Int(nullable: false, identity: true),
                        TraditionName = c.String(),
                        TraditionDescription = c.String(),
                    })
                .PrimaryKey(t => t.TraditionID);
            
            CreateTable(
                "dbo.TraditionPlaces",
                c => new
                    {
                        Tradition_TraditionID = c.Int(nullable: false),
                        Place_PlaceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tradition_TraditionID, t.Place_PlaceId })
                .ForeignKey("dbo.Traditions", t => t.Tradition_TraditionID, cascadeDelete: true)
                .ForeignKey("dbo.Places", t => t.Place_PlaceId, cascadeDelete: true)
                .Index(t => t.Tradition_TraditionID)
                .Index(t => t.Place_PlaceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TraditionPlaces", "Place_PlaceId", "dbo.Places");
            DropForeignKey("dbo.TraditionPlaces", "Tradition_TraditionID", "dbo.Traditions");
            DropIndex("dbo.TraditionPlaces", new[] { "Place_PlaceId" });
            DropIndex("dbo.TraditionPlaces", new[] { "Tradition_TraditionID" });
            DropTable("dbo.TraditionPlaces");
            DropTable("dbo.Traditions");
        }
    }
}
