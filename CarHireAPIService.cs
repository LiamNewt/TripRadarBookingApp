using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static TripRadar.HotelsAvailable;

namespace TripRadar
{
    public class CarHireAPIService
    {
        private readonly string apiKey = Environment.GetEnvironmentVariable("BookingComKey");
        private static readonly HttpClient client = new HttpClient();

        private async Task<List<LocationResult>> GetLocation(string query)
        {
            var safe = Uri.EscapeDataString(query);

            var geoRequest = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://nominatim.openstreetmap.org/search?q={safe}&format=json&limit=5"),
            };
            geoRequest.Headers.Add("User-Agent", "TripRadar/1.0");

            using (var response = await client.SendAsync(geoRequest))
            {
                var body = await response.Content.ReadAsStringAsync();
                MessageBox.Show($"GEO SEARCH: {body.Substring(0, Math.Min(800, body.Length))}");
                System.Diagnostics.Debug.WriteLine($"GEO SEARCH: {body.Substring(0, Math.Min(800, body.Length))}");
                var result = JsonConvert.DeserializeObject<dynamic>(body);

                var coordinates = new List<LocationResult>();
                foreach (var item in result)
                {
                    double lat = 0;
                    double lon = 0;

                    double.TryParse(item.lat.ToString(), out lat);
                    double.TryParse(item.lon.ToString(), out lon);

                    coordinates.Add(new LocationResult
                    {
                        Name = item.display_name.ToString(),
                        Latitude = lat,
                        Longitude = lon
                    });
                }
                return coordinates;
            }

        }

        public async Task<List<LocationResult>> CarHireAreaSearch(string query)
        {
            return await GetLocation(query);
        }

        public async Task<List<CarHire>> CarsAvailable(double latitude, double longitude, DateTime pickUpDate, DateTime pickUpTime, DateTime dropOffDate, DateTime dropOffTime)
        {
            var url = $"https://booking-com15.p.rapidapi.com/api/v1/cars/searchCarRentals" +
                      $"?pick_up_latitude={latitude}" +
                      $"&pick_up_longitude={longitude}" +
                      $"&drop_off_latitude={latitude}" +
                      $"&drop_off_longitude={longitude}" +
                      $"&pick_up_date={pickUpDate:yyyy-MM-dd}" +
                      $"&pick_up_time={pickUpTime:HH:mm}" +
                      $"&drop_off_date={dropOffDate:yyyy-MM-dd}" +
                      $"&drop_off_time={dropOffTime:HH:mm}"
                      ;

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

                var result = JsonConvert.DeserializeObject<CarsAvailable.Root>(body);

                var carHireAvailable = result.data.search_results.Select(c => new CarHire
                {
                    CarName = c.vehicle_info.v_name,
                    CarType = c.vehicle_info.group,
                    Transmission = c.vehicle_info.transmission,
                    Doors = c.vehicle_info.door_count,
                    Provider = c.supplier_info.name,
                    ProviderLogo = c.supplier_info.logo_url,
                    Price = c.pricing_info.price,
                    Image = c.vehicle_info.image_url,
                }).ToList();
                return carHireAvailable;

            }
        }
    }
}
