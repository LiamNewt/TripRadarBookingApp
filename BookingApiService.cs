using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TripRadar
{
    public class BookingApiService
    {
        private readonly string apiKey = Environment.GetEnvironmentVariable("BookingComKey");
        private static readonly HttpClient client = new HttpClient();


        public async Task<List<Airport>> SearchAirports(string query)
        {
            var safe = Uri.EscapeDataString(query);

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(
                $"https://booking-com15.p.rapidapi.com/api/v1/flights/searchDestination?query={safe}")
            };

            request.Headers.Add("x-rapidapi-key", apiKey);
            request.Headers.Add("x-rapidapi-host", "booking-com15.p.rapidapi.com");

            using (var response = await client.SendAsync(request))
            {
                var body = await response.Content.ReadAsStringAsync();

                dynamic result = JsonConvert.DeserializeObject(body);

                var airports = new List<Airport>();
                foreach (var airport in result.data)
                {
                    airports.Add(new Airport
                    {
                        ID = airport.id,
                        Name = airport.name,
                        Code = airport.code
                    });
                }
                return airports;
            }
        }

        public async Task<List<Flight>> SearchFlights(string fromAirportId, string toAirportId, DateTime departureDate, DateTime returnDate, int numPassengers)
        {
            var date = departureDate.ToString("yyyy-MM-dd");
            var rDate = returnDate.ToString("yyyy-MM-dd");

            var url =
                $"https://booking-com15.p.rapidapi.com/api/v1/flights/searchFlights" +
                $"?fromId={Uri.EscapeDataString(fromAirportId)}" +
                $"&toId={Uri.EscapeDataString(toAirportId)}" +
                $"&departDate={date}" +
                $"&returnDate={rDate}" +
                $"&stops=none" +
                $"&pageNo=1" +
                $"&adults={numPassengers}" + 
                $"&sort=BEST" +
                $"&cabinClass=ECONOMY" +
                $"&currency_code=EUR";

            

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

                System.Diagnostics.Debug.WriteLine($"RAW RESPONSE: {body}");

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"API Error: {response.StatusCode}{body}");
                }

                var result = JsonConvert.DeserializeObject<SearchFlights.Root>(body);

                var flights = result.data.flightOffers.Select(f => new Flight
                {
                    DepartureAirport = f.segments.First().departureAirport.code,
                    ArrivalAirport = f.segments.First().arrivalAirport.code,
                    DepartureTime = f.segments.First().departureTime,
                    ArrivalTime = f.segments.First().arrivalTime,
                    Price = f.priceBreakdown.total.units,
                    AirlineCode = f.segments.First().legs.First().carriersData.First().code,
                }).ToList();

                return flights;
            }


        }
    }
}
