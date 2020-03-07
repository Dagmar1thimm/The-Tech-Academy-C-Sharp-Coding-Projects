namespace TravelAgency.Migrations.TravelAgencyMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Agency",
                c => new
                    {
                        AgencyID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.AgencyID);
            
            CreateTable(
                "dbo.Traveler",
                c => new
                    {
                        TravelerID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Gender = c.String(),
                        Destination = c.String(),
                        LocalTrip = c.Boolean(nullable: false),
                        AgencyName = c.String(),
                        Agency_AgencyID = c.Int(),
                    })
                .PrimaryKey(t => t.TravelerID)
                .ForeignKey("dbo.Agency", t => t.Agency_AgencyID)
                .Index(t => t.Agency_AgencyID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Traveler", "Agency_AgencyID", "dbo.Agency");
            DropIndex("dbo.Traveler", new[] { "Agency_AgencyID" });
            DropTable("dbo.Traveler");
            DropTable("dbo.Agency");
        }
    }
}
