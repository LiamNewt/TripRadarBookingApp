using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripRadar
{
    public class Hotel
    {
        public string DestID {  get; set; }
        public string HotelName { get; set; }
        public string Description { get; set; }
        public string Region {  get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string AccomType { get; set; }
        public string ImageUrl { get; set; }
        public DateTime checkIn { get; set; }
        public DateTime checkOut { get; set; }
        public string Price { get; set; }
        public string ReviewScore { get; set; }

        public int Adults { get; set; }
        public int Children { get; set; }

    }
}
