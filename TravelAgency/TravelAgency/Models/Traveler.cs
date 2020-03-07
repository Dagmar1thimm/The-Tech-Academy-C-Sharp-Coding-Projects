using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TravelAgency
{
    public class Traveler
    {
        public int TravelerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Destination { get; set; }
        public bool LocalTrip { get; set; }
        public string AgencyName { get; set; }
        
        [ForeignKey("AgencyID")]
        public virtual Agency Agency { get; set; }

        public int AgencyID { get; set; }
    }
}