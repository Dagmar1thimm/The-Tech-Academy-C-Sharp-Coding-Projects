using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelAgency
{
    public class Agency
    {
        public int AgencyID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public virtual List<Traveler>Travelers { get; set; } // virtual makes this a navigationproperty
    }

}