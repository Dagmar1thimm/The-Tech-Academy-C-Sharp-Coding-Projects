using System;
using System.Collections.Generic;
using System.Data.Entity;   // Wichtig für DbContext!
using System.Data.Entity.ModelConfiguration.Conventions; //Manuell hinzugefügt
using System.Linq;
using System.Web;

namespace TravelAgency.Data
{
    public class TravelerContext: DbContext
    {
        public TravelerContext() : base("DefaultConnection")
        {

        }

        public DbSet<Traveler> Travelers { get; set; }
        public DbSet<Agency> Agencies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}