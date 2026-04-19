using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TripRadar
{
    public class BookingApiService
    {
        private readonly string apiKey = Environment.GetEnvironmentVariable("BookingComKey"); // Stored securely in environment variable
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
                //System.Diagnostics.Debug.WriteLine($"RAW RESPONSE: {body}");


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

        public async Task<List<Flight>> SearchFlights(string fromAirportId, string toAirportId, DateTime departureDate, int numPassengers, DateTime? returnDate)
        {
            var date = departureDate.ToString("yyyy-MM-dd");

            var url =
                $"https://booking-com15.p.rapidapi.com/api/v1/flights/searchFlights" +
                $"?fromId={Uri.EscapeDataString(fromAirportId)}" +
                $"&toId={Uri.EscapeDataString(toAirportId)}" +
                $"&departDate={date}" +
                $"&stops=none" +
                $"&pageNo=1" +
                $"&adults={numPassengers}" + 
                $"&sort=CHEAPEST" +
                $"&cabinClass=ECONOMY" +
                $"&currency_code=EUR";

            if (returnDate.HasValue)
            {
                url += $"&returnDate={returnDate.Value.ToString("yyyy-MM-dd")}"; //return flight active
            }
            else
            {
                // Single flight
            }

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

                var flights = result.data.flightOffers.Select(f =>
                {
                    var outboundSegment = f.segments[0];
                    var returnSegment = f.segments.Count > 1 ? f.segments.Last() : null;
                    var carrier = outboundSegment.legs?.FirstOrDefault()?.carriersData?.FirstOrDefault();

                    return new Flight
                    {
                        //outbound flight details
                        DepartureAirport = outboundSegment.departureAirport?.name,
                        ArrivalAirport = outboundSegment.arrivalAirport?.name,
                        DepartureTime = outboundSegment.departureTime,
                        ArrivalTime = outboundSegment.arrivalTime,

                        //return flight details if selected
                        ReturnDepartureAirport = returnSegment?.departureAirport?.name,
                        ReturnArrivalAirport = returnSegment?.arrivalAirport?.name,
                        ReturnDepartureTime = returnSegment?.departureTime,
                        ReturnArrivalTime = returnSegment?.arrivalTime,

                        //share
                        SmallAirlineLogo = carrier?.logo,
                        Price = f.priceBreakdown?.total?.units ?? 0,
                        AirlineCode = carrier?.code,
                        Token = f.token
                    };
                }).ToList();

                return flights;
            }
        }
        public async Task<List<Flight>> FlightDetails(string token)
        {

            var url =
                $"https://booking-com15.p.rapidapi.com/api/v1/flights/getFlightDetails" +
                $"?token={Uri.EscapeDataString(token)}" +
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
                var result = JsonConvert.DeserializeObject<FlightDetails.Root>(body);
                var flightDetails = new List<Flight>();
                {
                    flightDetails.Add(new Flight
                    {
                        DepartureAirport = result.data.segments[0].departureAirport?.name,
                        ArrivalAirport = result.data.segments[0].arrivalAirport?.name,
                        DepartureTime = result.data.segments[0].departureTime,
                        ArrivalTime = result.data.segments[0].arrivalTime,
                        ReturnDepartureAirport = result.data.segments.Count > 1 ? result.data.segments.Last().departureAirport?.name : null,
                        ReturnArrivalAirport = result.data.segments.Count > 1 ? result.data.segments.Last().arrivalAirport?.name : null,
                        ReturnDepartureTime = result.data.segments.Count > 1 ? result.data.segments.Last().departureTime : (DateTime?)null,
                        ReturnArrivalTime = result.data.segments.Count > 1 ? result.data.segments.Last().arrivalTime : (DateTime?)null,
                        SmallAirlineLogo = result.data.segments[0].legs?.FirstOrDefault()?.carriersData?.FirstOrDefault()?.logo,
                        Price = result.data.priceBreakdown?.total?.units ?? 0,
                        AirlineCode = result.data.segments[0].legs?.FirstOrDefault()?.carriersData?.FirstOrDefault()?.code,
                        DepartureCity = result.data.segments[0].departureAirport?.cityName,
                        ArrivalCity = result.data.segments[0].arrivalAirport?.cityName,
                        LuggageType = result.data.segments[0].travellerCabinLuggage?.FirstOrDefault()?.luggageAllowance?.luggageType,
                        CabinClass = result.data.segments[0].legs?.FirstOrDefault()?.cabinClass,
                        FlightNum = result.data.segments[0].legs?.FirstOrDefault()?.flightInfo?.flightNumber.ToString().ToUpper(),
                        //MaxCarryOn = result.data.segments[0].travellerCabinLuggage?.FirstOrDefault()?.luggageAllowance?.maxPiece.Value,
                        //MaxCarryOnWeight = result.data.segments[0].travellerCabinLuggage?.FirstOrDefault()?.luggageAllowance?.maxWeightPerPiece.Value,
                        //WeightUnit = result.data.segments[0].travellerCabinLuggage?.FirstOrDefault()?.luggageAllowance?.massUnit,
                    });
                };

                return flightDetails;

            }

        }

    }
}
