using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static TripRadar.SearchFlights;


namespace TripRadar
{
    public class TripRadarApp
    {
        private readonly string apiKey = Environment.GetEnvironmentVariable("BookingComKey");
        private static readonly HttpClient client = new HttpClient();

        
        public async Task<Root> SearchFlights(string fromId, string toId)
        {
            var query = $"fromId = {Uri.EscapeDataString(fromId)}" +
                        $"toId= {Uri.EscapeDataString(toId)}";
            if (string.IsNullOrWhiteSpace(apiKey))
            {
                MessageBox.Show("API key not found.", "Missing API Key", MessageBoxButton.OK, MessageBoxImage.Warning);
                return null;
            }
            if (string.IsNullOrWhiteSpace(query))
            {
                MessageBox.Show("Search query cannot be empty.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                return null;
            }

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://booking-com15.p.rapidapi.com/api/v1/flights/searchFlights?{query}"),
            };
            request.Headers.Add("x-rapidapi-key", apiKey);
            request.Headers.Add("x-rapidapi-host", "booking-com15.p.rapidapi.com");
    
            try
            {
                using (var response = await client.SendAsync(request))
                {
                    var body = await response.Content.ReadAsStringAsync();

                    if (!response.IsSuccessStatusCode)
                    {
                        MessageBox.Show($"Request failed: {(int)response.StatusCode} {response.ReasonPhrase}\n\n{body}", "API Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return null;
                    }

                    Root result = JsonConvert.DeserializeObject<Root>(body); // APi returns a JSON object that matches the Root class structure
                    return result;
                    
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Network error: {ex.Message}", "Request Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }
    }
}

