using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using DagmarsTravelAgency.Models;

namespace DagmarsTravelAgency.DAL
{
    public class DagmarsDataInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<DagmarsDataContext>
    {
        protected override void Seed(DagmarsDataContext context)
        {
            var travelers = new List<Traveler>
            {
            new Traveler{FirstName="Carson",LastName="Alexander",Email="carson@alexander.net"},
            new Traveler{FirstName="Meredith",LastName="Alonso",Email="meredith@alonso.net"},
            new Traveler{FirstName="Arturo",LastName="Anand",Email="Arturo@Anand.net"},
            new Traveler{FirstName="Gytis",LastName="Barzdukas",Email="Gytis@Barzdukas.net"},
            new Traveler{FirstName="Yan",LastName="Li",Email="Yan@Li.net"},
            new Traveler{FirstName="Peggy",LastName="Justice",Email="Peggy@Justice.net"},
            new Traveler{FirstName="Laura",LastName="Norman",Email="Laura@Norman.net"},
            new Traveler{FirstName="Nino",LastName="Olivetto",Email="Nino@Olivetto.net"}
            };

            travelers.ForEach(t => context.Travelers.Add(t));
            context.SaveChanges();

            var trips = new List<Trip>
            {
            new Trip{TripID=1050,Title="Paris",Duration=3,},
            new Trip{TripID=4022,Title="Honolulu",Duration=3,},
            new Trip{TripID=4041,Title="Tokyo",Duration=3,},
            new Trip{TripID=1045,Title="Hong-Kong",Duration=4,},
            new Trip{TripID=3141,Title="Rome",Duration=4,},
            new Trip{TripID=2021,Title="London",Duration=3,},
            new Trip{TripID=2042,Title="Berlin",Duration=4,}
            };
            trips.ForEach(t => context.Trips.Add(t));
            context.SaveChanges();
            var bookings = new List<Booking>
            {
            new Booking{TravelerID=1,TripID=1050,LuxuryLevel=LuxuryLevel.A},
            new Booking{TravelerID=1,TripID=4022,LuxuryLevel=LuxuryLevel.C},
            new Booking{TravelerID=1,TripID=4041,LuxuryLevel=LuxuryLevel.B},
            new Booking{TravelerID=2,TripID=1045,LuxuryLevel=LuxuryLevel.B},
            new Booking{TravelerID=2,TripID=3141,LuxuryLevel=LuxuryLevel.E},
            new Booking{TravelerID=2,TripID=2021,LuxuryLevel=LuxuryLevel.E},
            new Booking{TravelerID=3,TripID=1050},
            new Booking{TravelerID=4,TripID=1050,},
            new Booking{TravelerID=4,TripID=4022,LuxuryLevel=LuxuryLevel.E},
            new Booking{TravelerID=5,TripID=4041,LuxuryLevel=LuxuryLevel.C},
            new Booking{TravelerID=6,TripID=1045},
            new Booking{TravelerID=7,TripID=3141,LuxuryLevel=LuxuryLevel.A},
            };
            bookings.ForEach(b => context.Bookings.Add(b));
            context.SaveChanges();

        }
    }
}