using DagmarsTravelAgency.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace DagmarsTravelAgency.DAL
{
    public class DagmarsDataContext :DbContext
    {
        public DagmarsDataContext() : base("DagmarsDataContext")
        {
        }

        public DbSet<Traveler> Travelers { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Trip> Trips { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }

}