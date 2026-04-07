using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace TripRadar
{
    public class CarHire
    {
        
        public string SearchKey { get; set; }
        public string CarName { get; set; }
        public string CarType { get; set; }
        public string Provider { get; set; }
        public string ProviderLogo { get; set; }
        public string Transmission { get; set; }
        public int Doors { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }

    }

    public class LocationResult
    {
        public string Name { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }
}
