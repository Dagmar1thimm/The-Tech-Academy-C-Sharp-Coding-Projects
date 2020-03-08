namespace DagmarsTravelAgency.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Booking",
                c => new
                    {
                        BookingID = c.Int(nullable: false, identity: true),
                        TripID = c.Int(nullable: false),
                        TravelerID = c.Int(nullable: false),
                        LuxuryLevel = c.Int(),
                    })
                .PrimaryKey(t => t.BookingID)
                .ForeignKey("dbo.Traveler", t => t.TravelerID, cascadeDelete: true)
                .ForeignKey("dbo.Trip", t => t.TripID, cascadeDelete: true)
                .Index(t => t.TripID)
                .Index(t => t.TravelerID);
            
            CreateTable(
                "dbo.Traveler",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Trip",
                c => new
                    {
                        TripID = c.Int(nullable: false),
                        Title = c.String(),
                        Duration = c.Int(nullable: false),
                        LuxuryLevel = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TripID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Booking", "TripID", "dbo.Trip");
            DropForeignKey("dbo.Booking", "TravelerID", "dbo.Traveler");
            DropIndex("dbo.Booking", new[] { "TravelerID" });
            DropIndex("dbo.Booking", new[] { "TripID" });
            DropTable("dbo.Trip");
            DropTable("dbo.Traveler");
            DropTable("dbo.Booking");
        }
    }
}
