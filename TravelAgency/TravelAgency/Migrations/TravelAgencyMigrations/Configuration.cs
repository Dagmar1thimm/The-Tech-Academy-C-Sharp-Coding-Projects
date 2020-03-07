namespace TravelAgency.Migrations.TravelAgencyMigrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TravelAgency.Data;

    internal sealed class Configuration : DbMigrationsConfiguration<TravelAgency.Data.TravelerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\TravelAgencyMigrations";
        }

        protected override void Seed(TravelAgency.Data.TravelerContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            context.Agencies.AddOrUpdate(
                a => a.Name, DummyData.getAgencies().ToArray());
//              a => new { a.Name, a.Location }, DummyData.getAgencies().ToArray());
            context.SaveChanges();
            context.Travelers.AddOrUpdate(
                t => new { t.FirstName, t.LastName, t.Email, t.Gender, t.Destination, t.LocalTrip, t.AgencyName }, DummyData.getTravelers(context).ToArray());
        }
    }
}
