using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripRadar
{
    public class SearchFlights
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Datum
        {
            public string id { get; set; }
            public string type { get; set; }
            public string name { get; set; }
            public string code { get; set; }
            public string city { get; set; }
            public string cityName { get; set; }
            public string regionName { get; set; }
            public string country { get; set; }
            public string countryName { get; set; }
            public string countryNameShort { get; set; }
            public string photoUri { get; set; }
            public DistanceToCity distanceToCity { get; set; }
            public string parent { get; set; }
            public string region { get; set; }
        }

        public class DistanceToCity
        {
            public double value { get; set; }
            public string unit { get; set; }
        }

        public class Flightsearch
        {
            public bool status { get; set; }
            public string message { get; set; }
            public long timestamp { get; set; }
            public List<Datum> data { get; set; }
        }


    }
}
