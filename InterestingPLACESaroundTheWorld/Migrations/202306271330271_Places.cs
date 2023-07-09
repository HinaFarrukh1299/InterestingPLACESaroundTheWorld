namespace InterestingPLACESaroundTheWorld.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Places : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Places",
                c => new
                    {
                        PlaceId = c.Int(nullable: false, identity: true),
                        PlaceName = c.String(),
                        PlaceDescription = c.String(),
                        DateOfCreation = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PlaceId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Places");
        }
    }
}
