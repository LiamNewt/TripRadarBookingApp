using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripRadar
{
    public class Hotel //Hotel Model
    {
        //Hotel
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
        public int Guests { get; set; }


        //Hotel Details
        public string HotelDetName { get; set; }
        public string HotelCity { get; set; }
        public string Address { get; set; }
        public double FromCityCenter { get; set; }
        public string Arrival { get; set; }
        public string Departure { get; set; }
        public string RoomType { get; set; }
        public int AvailableRooms { get; set; }
        public string Facilities { get; set; }
        public double PricePNight { get; set; }
        public int ReviewCount { get; set; }

        //Cant be stored in Database
        [NotMapped]
        public List<string> Amenities { get; set; }
        [NotMapped]
        public List<string> Photos { get; set; }
    }
}//end of hotel class
