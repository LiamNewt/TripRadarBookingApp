using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TripRadar
{
    public class HotelApiService
    {
        private readonly string apiKey = Environment.GetEnvironmentVariable("BookingComKey");
        private static readonly HttpClient client = new HttpClient();

        public async Task<List<Hotel>> HotelSearch(string query)
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

                dynamic result = JsonConvert.DeserializeObject(body);

                var hotels = new List<Hotel>();
                foreach (var hotel in result.data)
                {
                    hotels.Add(new Hotel
                    {
                        DestID = hotel.dest_id,
                        HotelName = hotel.label,
                    });
                }
                return hotels;
            }
        }

    }
}
