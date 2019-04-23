namespace VacationsUnited.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Itinerary", "Region", c => c.Int(nullable: false));
            DropColumn("dbo.Group", "Region");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Group", "Region", c => c.Int(nullable: false));
            DropColumn("dbo.Itinerary", "Region");
        }
    }
}
