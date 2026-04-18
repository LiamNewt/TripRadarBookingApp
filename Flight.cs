using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripRadar
{
        public class Flight
        {
        //Search Results Properties
        
        //Outbound
            public string DepartureAirport { get; set; }
            public string ArrivalAirport { get; set; }
            public DateTime DepartureTime { get; set; }
            public DateTime ArrivalTime { get; set; }
            public string DepartureCity { get; set; }
            public string ArrivalCity { get; set; }

        //Return
        public string ReturnDepartureAirport { get; set; }
            public string ReturnArrivalAirport { get; set; }
            public DateTime? ReturnDepartureTime { get; set; }
            public DateTime? ReturnArrivalTime { get; set; }

            public int Price { get; set; }
            public string AirlineCode { get; set; }
            public string AirlineLogo => $"https://pics.avs.io/200/200/{AirlineCode}.png";
            public string SmallAirlineLogo { get; set; }
            public string Token { get; set; }
            public bool IsReturn => ReturnDepartureAirport != null;
            public string LuggageType { get; set; }
            public string CabinClass { get; set; }
            public string FlightNum { get; set; }
            //public int? MaxCarryOn { get; set; }
            //public double? MaxCarryOnWeight { get; set; }
            //public string WeightUnit { get; set; }





    }
}


