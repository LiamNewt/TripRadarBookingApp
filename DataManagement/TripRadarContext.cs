using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManagement
{
    public class TripRadarContext : DbContext
    {
        public TripRadarContext() : base("TRDatabase") { }

        public DbSet<SavedHotel> SavedHotels { get; set; }
        public DbSet<SavedFlight> SavedFlights { get; set; }
    }
}
