using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DagmarsTravelAgency.Models
{
    public class Traveler
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}