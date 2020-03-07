using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelAgency.Data
{
    public class DummyData
    {
        //public static List<Traveler> getTravelers()
        //{
        //    List<Traveler> travelers = new List<Traveler>()
        //    {
        //        new Traveler()
        //        {
        //            //TravelerID = 1,
        //            FirstName = "Joe",
        //            LastName = "Miller",
        //            Email = "joe@miller.net",
        //            Gender = "M",
        //            Destination = "Paris",
        //            LocalTrip = false,
        //            AgencyName = "Agency 1"
        //        },
        //        new Traveler()
        //        {
        //            //TravelerID = 2,
        //            FirstName = "Mary",
        //            LastName = "Jordan",
        //            Email = "mary@jordan.net",
        //            Gender = "F",
        //            Destination = "Berlin",
        //            LocalTrip = false,
        //            AgencyName = "Agency 2"

        //        }
        //    };

        //    return travelers;
        //}

        public static List<Agency> getAgencies()
        { 
            List<Agency> agencies = new List<Agency>()
            {
                new Agency()
                {
                    Name = "Agency 1",
                    Location = "N.Y., N.Y."
                },
                new Agency()
                {
                    Name = "Agency 2",
                    Location = "Los Angeles, CA"
                }
            };

            return agencies;
        }

        public static List<Traveler> getTravelers(TravelerContext context) {

            List<Traveler> travelers = new List<Traveler>()
            {
                new Traveler()
                {
                    FirstName = "Joe",
                    LastName = "Miller",
                    Email = "joe@miller.net",
                    Gender = "M",
                    Destination = "Paris",
                    LocalTrip = false,
                    AgencyName = context.Agencies.Find("Agency 1").Name
                },
                new Traveler()
                {
                    FirstName = "Mary",
                    LastName = "Jordan",
                    Email = "mary@jordan.net",
                    Gender = "F",
                    Destination = "Berlin",
                    LocalTrip = false,
                    AgencyName = context.Agencies.Find("Agency 2").Name
                }
            };
            return travelers;
        }
    }
}