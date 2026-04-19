using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManagement
{
    public class SavedFlight
    {
        public int Id { get; set; }
        //outbound
        public string DepartureAirport { get; set; }
        public string ArrivalAirport { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public string AirlineCode { get; set; }
        public int Price { get; set; }
        public string CabinClass { get; set; }
        public DateTime SavedOn { get; set; }
        //return
        public string ReturnDepartureAirport { get; set; }
        public string ReturnArrivalAirport { get;set; }
        public DateTime? ReturnArrivalTime { get;set; }
        public DateTime? ReturnDepartureTime { get;set; }
        public bool IsReturn => ReturnDepartureAirport != null;



    }

    public class SavedHotel
    {
        public int Id { get; set; }
        public string HotelDetName { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public double PricePNight { get; set; }
        public string ImageUrl { get; set; }
        public string Arrival { get; set; }
        public string Departure { get; set; }
        public string RoomType { get; set; }
        public DateTime SavedOn { get; set; }
    }
}
