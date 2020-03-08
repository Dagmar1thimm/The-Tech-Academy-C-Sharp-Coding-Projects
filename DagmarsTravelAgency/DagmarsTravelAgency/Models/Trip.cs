using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DagmarsTravelAgency.Models
{
    public class Trip
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TripID { get; set; }
        public string Title { get; set; }

        public int Duration { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
        public int LuxuryLevel { get; internal set; }
    }
}