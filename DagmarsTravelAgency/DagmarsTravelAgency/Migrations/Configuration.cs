namespace DagmarsTravelAgency.Migrations
{
    using DagmarsTravelAgency.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DagmarsTravelAgency.DAL.DagmarsDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "DagmarsTravelAgency.DAL.DagmarsDataContext";
        }

        protected override void Seed(DagmarsTravelAgency.DAL.DagmarsDataContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
             var travelers = new List<Traveler>
            {
                new Traveler{FirstName="Carson",    LastName="Alexander",   Email="carson@alexander.net"},
                new Traveler{FirstName="Meredith",  LastName="Alonso",      Email="meredith@alonso.net"},
                new Traveler{FirstName="Arturo",    LastName="Anand",       Email="Arturo@Anand.net"},
                new Traveler{FirstName="Gytis",     LastName="Barzdukas",   Email="Gytis@Barzdukas.net"},
                new Traveler{FirstName="Yan",       LastName="Li",          Email="Yan@Li.net"},
                new Traveler{FirstName="Peggy",     LastName="Justice",     Email="Peggy@Justice.net"},
                new Traveler{FirstName="Laura",     LastName="Norman",      Email="Laura@Norman.net"},
                new Traveler{FirstName="Nino",      LastName="Olivetto",    Email="Nino@Olivetto.net"},
                new Traveler{FirstName="Joe",       LastName="Dante",       Email="joe@dante.net"}
            };

            travelers.ForEach(s => context.Travelers.AddOrUpdate(p => p.LastName, s));
            context.SaveChanges();

            var trips = new List<Trip>
            {
                new Trip{TripID=1050,Title="Paris",Duration=3,LuxuryLevel=1},
                new Trip{TripID=4022,Title="Honolulu",Duration=3,LuxuryLevel=2},
                new Trip{TripID=4041,Title="Tokyo",Duration=3,LuxuryLevel=2},
                new Trip{TripID=1045,Title="Hong-Kong",Duration=4,LuxuryLevel=3},
                new Trip{TripID=3141,Title="Rome",Duration=4,LuxuryLevel=1},
                new Trip{TripID=2021,Title="London",Duration=3,LuxuryLevel=2},
                new Trip{TripID=2042,Title="Berlin",Duration=4,LuxuryLevel=2},
                new Trip{TripID=2043,Title="Anchorage",Duration=7,LuxuryLevel=3}
            };
            trips.ForEach(s => context.Trips.AddOrUpdate(p => p.Title, s));
            context.SaveChanges();

            var bookings = new List<Booking>
            {
                new Booking {
                    TravelerID = travelers.Single(s => s.LastName == "Alexander").ID,
                    TripID = trips.Single(c => c.Title == "Paris" ).TripID,
                    LuxuryLevel = LuxuryLevel.A
                },
                 new Booking {
                    TravelerID = travelers.Single(s => s.LastName == "Alexander").ID,
                    TripID = trips.Single(c => c.Title == "Honolulu" ).TripID,
                    LuxuryLevel = LuxuryLevel.C
                 },
                 new Booking {
                    TravelerID = travelers.Single(s => s.LastName == "Alexander").ID,
                    TripID = trips.Single(c => c.Title == "Tokyo" ).TripID,
                    LuxuryLevel = LuxuryLevel.B
                 },
                 new Booking {
                    TravelerID = travelers.Single(s => s.LastName == "Alonso").ID,
                    TripID = trips.Single(c => c.Title == "Hong-Kong" ).TripID,
                    LuxuryLevel = LuxuryLevel.B
                 },
                 new Booking {
                     TravelerID = travelers.Single(s => s.LastName == "Alonso").ID,
                    TripID = trips.Single(c => c.Title == "Rome" ).TripID,
                    LuxuryLevel = LuxuryLevel.B
                 },
                 new Booking {
                    TravelerID = travelers.Single(s => s.LastName == "Alonso").ID,
                    TripID = trips.Single(c => c.Title == "London" ).TripID,
                    LuxuryLevel = LuxuryLevel.B
                 },
                 new Booking {
                    TravelerID = travelers.Single(s => s.LastName == "Anand").ID,
                    TripID = trips.Single(c => c.Title == "Paris" ).TripID
                 },
                 new Booking {
                    TravelerID = travelers.Single(s => s.LastName == "Anand").ID,
                    TripID = trips.Single(c => c.Title == "Honolulu").TripID,
                    LuxuryLevel = LuxuryLevel.B
                 },
                new Booking {
                    TravelerID = travelers.Single(s => s.LastName == "Barzdukas").ID,
                    TripID = trips.Single(c => c.Title == "Paris").TripID,
                    LuxuryLevel = LuxuryLevel.B
                 },
                 new Booking {
                    TravelerID = travelers.Single(s => s.LastName == "Li").ID,
                    TripID = trips.Single(c => c.Title == "Tokyo").TripID,
                    LuxuryLevel = LuxuryLevel.B
                 },
                 new Booking {
                    TravelerID = travelers.Single(s => s.LastName == "Justice").ID,
                    TripID = trips.Single(c => c.Title == "Hong-Kong").TripID,
                    LuxuryLevel = LuxuryLevel.B
                 },
                 new Booking {
                    TravelerID = travelers.Single(s => s.LastName == "Norman").ID,
                    TripID = trips.Single(c => c.Title == "Rome").TripID,
                    LuxuryLevel = LuxuryLevel.A
                 },
                 new Booking {
                    TravelerID = travelers.Single(s => s.LastName == "Dante").ID,
                    TripID = trips.Single(c => c.Title == "Anchorage").TripID,
                    LuxuryLevel = LuxuryLevel.A
                 }
            };

            foreach (Booking b in bookings)
            {
                var bookingInDataBase = context.Bookings.Where(
                    s =>
                         s.Traveler.ID == b.TravelerID &&
                         s.Trip.TripID == b.TripID).SingleOrDefault();
                if (bookingInDataBase == null)
                {
                    context.Bookings.Add(b);
                }
            }
            context.SaveChanges();
        }
    }
}
