namespace VacationsUnited.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class signinchangestues0416 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SelectedDestination",
                c => new
                    {
                        SelectedDestinationID = c.Int(nullable: false, identity: true),
                        Day = c.Int(nullable: false),
                        ItineraryID = c.Int(nullable: false),
                        DestinationID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SelectedDestinationID);
            
            DropColumn("dbo.Itinerary", "DestinationId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Itinerary", "DestinationId", c => c.Int(nullable: false));
            DropTable("dbo.SelectedDestination");
        }
    }
}
