namespace InterestingPLACESaroundTheWorld.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Origin : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Origins",
                c => new
                    {
                        OriginID = c.Int(nullable: false, identity: true),
                        Continent = c.String(),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.OriginID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Origins");
        }
    }
}
