using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DagmarsTravelAgency.Models
{
    public enum LuxuryLevel
    {
        A, B, C, D, E
    }
    public class Booking
    {
        public int BookingID { get; set; }
        public int TripID { get; set; }
        public int TravelerID { get; set; }
        public LuxuryLevel? LuxuryLevel { get; set; }

        public virtual Trip Trip { get; set; }
        public virtual Traveler Traveler { get; set; }
    }
}