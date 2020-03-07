namespace TravelAgency.Migrations.TravelAgencyMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Traveler", "Agency_AgencyID", "dbo.Agency");
            DropIndex("dbo.Traveler", new[] { "Agency_AgencyID" });
            RenameColumn(table: "dbo.Traveler", name: "Agency_AgencyID", newName: "AgencyID");
            AlterColumn("dbo.Traveler", "AgencyID", c => c.Int(nullable: false));
            CreateIndex("dbo.Traveler", "AgencyID");
            AddForeignKey("dbo.Traveler", "AgencyID", "dbo.Agency", "AgencyID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Traveler", "AgencyID", "dbo.Agency");
            DropIndex("dbo.Traveler", new[] { "AgencyID" });
            AlterColumn("dbo.Traveler", "AgencyID", c => c.Int());
            RenameColumn(table: "dbo.Traveler", name: "AgencyID", newName: "Agency_AgencyID");
            CreateIndex("dbo.Traveler", "Agency_AgencyID");
            AddForeignKey("dbo.Traveler", "Agency_AgencyID", "dbo.Agency", "AgencyID");
        }
    }
}
