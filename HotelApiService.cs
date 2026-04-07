using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace TripRadar
{
    public class HotelApiService
    {
        private readonly string apiKey = Environment.GetEnvironmentVariable("BookingComKey");
        private static readonly HttpClient client = new HttpClient();

        public async Task<List<Hotel>> HotelAreaSearch(string query)
        {
            var safe = Uri.EscapeDataString(query);

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://booking-com15.p.rapidapi.com/api/v1/hotels/searchDestination?query={safe}"),
            };

            request.Headers.Add("x-rapidapi-key", apiKey);
            request.Headers.Add("x-rapidapi-host", "booking-com15.p.rapidapi.com");

            using (var response = await client.SendAsync(request))
            {
                var body = await response.Content.ReadAsStringAsync();
                MessageBox.Show($"AREA SEARCH: {body.Substring(0, Math.Min(800, body.Length))}");
                dynamic result = JsonConvert.DeserializeObject(body);

                var hotels = new List<Hotel>();
                foreach (var hotel in result.data)
                {
                    string destType = hotel.search_type?.ToString();
                    if (destType != "city")
                    {
                        continue;
                    }

                    hotels.Add(new Hotel
                    {
                        DestID = hotel.dest_id,
                        HotelName = hotel.label,
                    });
                }
                return hotels;
            }
        }

        public async Task<List<Hotel>> HotelsAvailable(string hotelid, DateTime checkIn, DateTime checkOut)
        {

            var url =
                $"https://booking-com15.p.rapidapi.com/api/v1/hotels/searchHotels" +
                $"?dest_id={Uri.EscapeDataString(hotelid)}" +
                $"&search_type=CITY" +
                $"&arrival_date={checkIn:yyyy-MM-dd}" +
                $"&departure_date={checkOut:yyyy-MM-dd}";
                //$"&adults={numAdults}" +
                //$"&children_age={numChild}" +
                //$"&room_qty=1" +
                //$"&page_number=1" +
                //$"&currency_code=EUR";

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(url)
            };

            request.Headers.Add("x-rapidapi-key", apiKey);
            request.Headers.Add("x-rapidapi-host", "booking-com15.p.rapidapi.com");

            using (var response = await client.SendAsync(request))
            {
                var body = await response.Content.ReadAsStringAsync();
                //Error Messages
                MessageBox.Show($"URL: {url}\n\nRESPONSE: {body.Substring(0, Math.Min(500, body.Length))}");
                MessageBox.Show(body.Substring(0, Math.Min(500, body.Length)));
                //Error Messages

                var result = JsonConvert.DeserializeObject<HotelsAvailable.Root>(body);


                var hotelsAvailable = result.data.hotels.Select(h => new Hotel
                {
                    DestID = h.property?.id.ToString(),
                    HotelName = h.property?.name.ToString(),
                    City = h.property?.wishlistName,
                    ImageUrl = h.property?.photoUrls?.FirstOrDefault(),
                    Price = h.property?.priceBreakdown?.grossPrice?.value.ToString("F2"),
                    ReviewScore = h.property?.reviewScoreWord,
                    Description = $"{h.property?.accuratePropertyClass} stars | " +
                                    $"{h.property?.reviewCount} reviews | " +
                                    $"Check In: {h.property?.checkin?.fromTime} " +
                                    $"Check Out: {h.property?.checkout?.untilTime}"

                }).ToList();

                return hotelsAvailable;
            }
        }

    }
}
