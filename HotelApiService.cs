using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media.Animation;

namespace TripRadar
{
    public class HotelApiService //Hotel API Service class
    {
        private readonly string apiKey = Environment.GetEnvironmentVariable("BookingComKey"); //stored in environment varibales
        private static readonly HttpClient client = new HttpClient();

        public async Task<List<Hotel>> HotelAreaSearch(string query) //Hotel search API method
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

                //handles API error
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"API Error: {response.StatusCode}{body}");
                }

                dynamic result = JsonConvert.DeserializeObject(body);

                var hotels = new List<Hotel>();
                foreach (var hotel in result.data)
                {
                    string destType = hotel.search_type?.ToString();
                    if (destType != "city") //limits destination type to city only to avoid errors
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

        public async Task<List<Hotel>> HotelsAvailable(string hotelid, DateTime checkIn, DateTime checkOut, int numGuests) //Hotels available API method
        {

            var url =
                $"https://booking-com15.p.rapidapi.com/api/v1/hotels/searchHotels" +
                $"?dest_id={Uri.EscapeDataString(hotelid)}" +
                $"&search_type=CITY" +
                $"&arrival_date={checkIn:yyyy-MM-dd}" +
                $"&departure_date={checkOut:yyyy-MM-dd}" +
                $"&adults={numGuests}" +
                $"&room_qty=1" +
                $"&page_number=1" +
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
                //Error/Debugging Messages
                //MessageBox.Show($"URL: {url}\n\nRESPONSE: {body.Substring(0, Math.Min(500, body.Length))}");
                //MessageBox.Show(body.Substring(0, Math.Min(500, body.Length)));

                //handles API error
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"API Error: {response.StatusCode}{body}");
                }

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
                                    $"Check Out: {h.property?.checkout?.untilTime}",
                    Guests = numGuests,
                    checkIn = checkIn,
                    checkOut = checkOut

                }).ToList();

                return hotelsAvailable;
            }
        }

        public async Task<List<Hotel>>HotelDetails(string hotelId, DateTime checkIn, DateTime checkOut, int numGuests) //hotel details API method
        {
            var url =
                $"https://booking-com15.p.rapidapi.com/api/v1/hotels/getHotelDetails" +
                $"?hotel_id={Uri.EscapeDataString(hotelId)}" +
                $"&arrival_date={checkIn:yyyy-MM-dd}" +
                $"&departure_date={checkOut:yyyy-MM-dd}" +
                $"&adults={numGuests}" +
                $"&room_qty=1" +
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

                //handles API error
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"API Error: {response.StatusCode}{body}");
                }

                var result = JsonConvert.DeserializeObject<HotelDetails.Root>(body);
                var hotelDetails = new List<Hotel>
                {
                    new Hotel
                    {
                        HotelDetName = result.data?.hotel_name,
                        Address = result.data?.address,
                        HotelCity = result.data?.city,
                        FromCityCenter = result.data?.distance_to_cc != null && double.TryParse(result.data.distance_to_cc.ToString().Replace(" km", ""), out var distance) ? Math.Round(distance, 2) : 0,
                        RoomType = result.data?.accommodation_type_name,
                        AvailableRooms = result.data?.available_rooms ?? 0,
                        Arrival = result.data?.rawData.checkin.fromTime,
                        Departure = result.data?.rawData.checkout.untilTime,
                        Facilities = result.data?.family_facilities?.ToArray().Length > 0 ? string.Join(", ", result.data.family_facilities) : "N/A",
                        PricePNight = result.data?.product_price_breakdown?.gross_amount_per_night?.value != null && double.TryParse(result.data.product_price_breakdown.gross_amount_per_night.value.ToString().Replace("€", ""), out var price) ? Math.Round(price,2): 0,
                        Photos = result.data?.rooms?.Values.FirstOrDefault()?.photos?.Select(p => p.url_max1280)?.ToList() ?? new List<string>(),
                        ImageUrl = result.data?.rooms?.Values.FirstOrDefault()?.photos?.FirstOrDefault()?.url_max750,
                        ReviewCount = result.data?.rawData?.reviewCount.Equals(null) == false ? (int)result.data.rawData.reviewCount : 0,
                        Amenities = result.data?.property_highlight_strip.Any() == true ? result.data.property_highlight_strip.Select(a => a.name).ToList() : new List<string>(),
                    }
                };
                return hotelDetails;
            }
        }
    }
}

