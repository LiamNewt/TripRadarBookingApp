using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripRadar
{
    public class SearchFlights
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Aggregation
        {
            public int totalCount { get; set; }
            public int filteredTotalCount { get; set; }
            public List<Stop> stops { get; set; }
            public List<Airline> airlines { get; set; }
            public List<DepartureInterval> departureIntervals { get; set; }
            public List<FlightTime> flightTimes { get; set; }
            public int durationMin { get; set; }
            public int durationMax { get; set; }
            public MinPrice minPrice { get; set; }
            public MinPriceFiltered minPriceFiltered { get; set; }
            public List<Baggage> baggage { get; set; }
            public Budget budget { get; set; }
            public BudgetPerAdult budgetPerAdult { get; set; }
            public List<Duration> duration { get; set; }
        }

        public class Airline
        {
            public string name { get; set; }
            public string logoUrl { get; set; }
            public string iataCode { get; set; }
            public int count { get; set; }
            public MinPrice minPrice { get; set; }
        }

        public class Ancillaries
        {
            public FlexibleTicket flexibleTicket { get; set; }
        }

        public class Arrival
        {
            public string start { get; set; }
            public string end { get; set; }
            public int count { get; set; }
        }

        public class ArrivalAirport
        {
            public string type { get; set; }
            public string code { get; set; }
            public string city { get; set; }
            public string cityName { get; set; }
            public string country { get; set; }
            public string countryName { get; set; }
            public string name { get; set; }
        }

        public class AvgPerAdult
        {
            public string currencyCode { get; set; }
            public int units { get; set; }
            public int nanos { get; set; }
        }

        public class AvgPerChild
        {
            public string currencyCode { get; set; }
            public int units { get; set; }
            public int nanos { get; set; }
        }

        public class AvgPerInfant
        {
            public string currencyCode { get; set; }
            public int units { get; set; }
            public int nanos { get; set; }
        }

        public class Baggage
        {
            public string paramName { get; set; }
            public int count { get; set; }
            public bool enabled { get; set; }
            public string baggageType { get; set; }
        }

        public class BaggagePolicy
        {
            public string code { get; set; }
            public string name { get; set; }
            public string url { get; set; }
        }

        public class BaseFare
        {
            public string currencyCode { get; set; }
            public int units { get; set; }
            public int nanos { get; set; }
        }

        public class BrandedFareInfo
        {
            public string fareName { get; set; }
            public string cabinClass { get; set; }
            public List<object> features { get; set; }
            public List<object> fareAttributes { get; set; }
            public List<object> nonIncludedFeatures { get; set; }
        }

        public class Budget
        {
            public string paramName { get; set; }
            public Min min { get; set; }
            public Max max { get; set; }
        }

        public class BudgetPerAdult
        {
            public string paramName { get; set; }
            public Min min { get; set; }
            public Max max { get; set; }
        }

        public class Carrier
        {
            public string name { get; set; }
            public string code { get; set; }
            public string logo { get; set; }
        }

        public class CarrierInfo
        {
            public string operatingCarrier { get; set; }
            public string marketingCarrier { get; set; }
            public string operatingCarrierDisclosureText { get; set; }
        }

        public class CarriersDatum
        {
            public string name { get; set; }
            public string code { get; set; }
            public string logo { get; set; }
        }

        public class CarrierTaxBreakdown
        {
            public Carrier carrier { get; set; }
            public AvgPerAdult avgPerAdult { get; set; }
            public AvgPerChild avgPerChild { get; set; }
            public AvgPerInfant avgPerInfant { get; set; }
        }

        public class Data
        {
            public Aggregation aggregation { get; set; }
            public List<FlightOffer> flightOffers { get; set; }
            public List<FlightDeal> flightDeals { get; set; }
            public string atolProtectedStatus { get; set; }
            public bool isOffersCabinClassExtended { get; set; }
            public List<BaggagePolicy> baggagePolicies { get; set; }
        }

        public class Departure
        {
            public string start { get; set; }
            public string end { get; set; }
            public int count { get; set; }
        }

        public class DepartureAirport
        {
            public string type { get; set; }
            public string code { get; set; }
            public string city { get; set; }
            public string cityName { get; set; }
            public string country { get; set; }
            public string countryName { get; set; }
            public string name { get; set; }
        }

        public class DepartureInterval
        {
            public string start { get; set; }
            public string end { get; set; }
        }

        public class Discount
        {
            public string currencyCode { get; set; }
            public int units { get; set; }
            public int nanos { get; set; }
        }

        public class Duration
        {
            public int min { get; set; }
            public int max { get; set; }
            public string durationType { get; set; }
            public bool enabled { get; set; }
            public string paramName { get; set; }
        }

        public class ExtraProduct
        {
            public string type { get; set; }
            public PriceBreakdown priceBreakdown { get; set; }
        }

        public class ExtraProductDisplayRequirements
        {
        }

        public class Fee
        {
            public string currencyCode { get; set; }
            public int units { get; set; }
            public int nanos { get; set; }
        }

        public class FlexibleTicket
        {
            public string airProductReference { get; set; }
            public List<string> travellers { get; set; }
            public PriceBreakdown priceBreakdown { get; set; }
            public bool preSelected { get; set; }
        }

        public class FlightDeal
        {
            public string key { get; set; }
            public string offerToken { get; set; }
            public Price price { get; set; }
            public List<TravellerPrice> travellerPrices { get; set; }
        }

        public class FlightInfo
        {
            public List<object> facilities { get; set; }
            public int flightNumber { get; set; }
            public string planeType { get; set; }
            public CarrierInfo carrierInfo { get; set; }
        }

        public class FlightOffer
        {
            public string token { get; set; }
            public List<Segment> segments { get; set; }
            public PriceBreakdown priceBreakdown { get; set; }
            public List<TravellerPrice> travellerPrices { get; set; }
            public List<object> priceDisplayRequirements { get; set; }
            public string pointOfSale { get; set; }
            public string tripType { get; set; }
            public PosMismatch posMismatch { get; set; }
            public List<ExtraProduct> extraProducts { get; set; }
            public OfferExtras offerExtras { get; set; }
            public Ancillaries ancillaries { get; set; }
            public List<object> appliedDiscounts { get; set; }
            public string offerKeyToHighlight { get; set; }
            public SeatAvailability seatAvailability { get; set; }
            public ExtraProductDisplayRequirements extraProductDisplayRequirements { get; set; }
            public BrandedFareInfo brandedFareInfo { get; set; }
        }

        public class FlightTime
        {
            public List<Arrival> arrival { get; set; }
            public List<Departure> departure { get; set; }
        }

        

        public class Leg
        {
            public DateTime departureTime { get; set; }
            public DateTime arrivalTime { get; set; }
            public DepartureAirport departureAirport { get; set; }
            public ArrivalAirport arrivalAirport { get; set; }
            public string cabinClass { get; set; }
            public FlightInfo flightInfo { get; set; }
            public List<string> carriers { get; set; }
            public List<CarriersDatum> carriersData { get; set; }
            public int totalTime { get; set; }
            public List<object> flightStops { get; set; }
            public string departureTerminal { get; set; }
            public string arrivalTerminal { get; set; }
        }

        public class LuggageAllowance
        {
            public string luggageType { get; set; }
            public string ruleType { get; set; }
            public int maxPiece { get; set; }
            public double maxWeightPerPiece { get; set; }
            public string massUnit { get; set; }
            public double? maxTotalWeight { get; set; }
            public SizeRestrictions sizeRestrictions { get; set; }
        }

        public class Max
        {
            public string currencyCode { get; set; }
            public int units { get; set; }
            public int nanos { get; set; }
        }

        public class Min
        {
            public string currencyCode { get; set; }
            public int units { get; set; }
            public int nanos { get; set; }
        }

        public class MinPrice
        {
            public string currencyCode { get; set; }
            public int units { get; set; }
            public int nanos { get; set; }
        }

        public class MinPriceFiltered
        {
            public string currencyCode { get; set; }
            public int units { get; set; }
            public int nanos { get; set; }
        }

        public class MoreTaxesAndFees
        {
        }

        public class OfferExtras
        {
            public FlexibleTicket flexibleTicket { get; set; }
        }

        public class PosMismatch
        {
            public string detectedPointOfSale { get; set; }
            public bool isPOSMismatch { get; set; }
            public string offerSalesCountry { get; set; }
        }

        public class Price
        {
            public string currencyCode { get; set; }
            public int units { get; set; }
            public int nanos { get; set; }
        }

        public class PriceBreakdown
        {
            public Total total { get; set; }
            public BaseFare baseFare { get; set; }
            public Fee fee { get; set; }
            public Tax tax { get; set; }
            public TotalRounded totalRounded { get; set; }
            public MoreTaxesAndFees moreTaxesAndFees { get; set; }
            public Discount discount { get; set; }
            public TotalWithoutDiscount totalWithoutDiscount { get; set; }
            public TotalWithoutDiscountRounded totalWithoutDiscountRounded { get; set; }
            public List<CarrierTaxBreakdown> carrierTaxBreakdown { get; set; }
        }

        public class Root
        {
            public bool status { get; set; }
            public string message { get; set; }
            public long timestamp { get; set; }
            public Data data { get; set; }
        }

        public class SeatAvailability
        {
            public int numberOfSeatsAvailable { get; set; }
        }

        public class Segment
        {
            public DepartureAirport departureAirport { get; set; }
            public ArrivalAirport arrivalAirport { get; set; }
            public DateTime departureTime { get; set; }
            public DateTime arrivalTime { get; set; }
            public List<Leg> legs { get; set; }
            public int totalTime { get; set; }
            public List<TravellerCheckedLuggage> travellerCheckedLuggage { get; set; }
            public List<TravellerCabinLuggage> travellerCabinLuggage { get; set; }
            public bool isAtolProtected { get; set; }
            public bool showWarningDestinationAirport { get; set; }
            public bool showWarningOriginAirport { get; set; }
        }

        public class SizeRestrictions
        {
            public double maxLength { get; set; }
            public double maxWidth { get; set; }
            public double maxHeight { get; set; }
            public string sizeUnit { get; set; }
        }

        public class Stop
        {
            public int numberOfStops { get; set; }
            public int count { get; set; }
            public MinPrice minPrice { get; set; }
        }

        public class Tax
        {
            public string currencyCode { get; set; }
            public int units { get; set; }
            public int nanos { get; set; }
        }

        public class Total
        {
            public string currencyCode { get; set; }
            public int units { get; set; }
            public int nanos { get; set; }
        }

        public class TotalRounded
        {
            public string currencyCode { get; set; }
            public int nanos { get; set; }
            public int units { get; set; }
        }

        public class TotalWithoutDiscount
        {
            public string currencyCode { get; set; }
            public int units { get; set; }
            public int nanos { get; set; }
        }

        public class TotalWithoutDiscountRounded
        {
            public string currencyCode { get; set; }
            public int nanos { get; set; }
            public int units { get; set; }
        }

        public class TravellerCabinLuggage
        {
            public string travellerReference { get; set; }
            public LuggageAllowance luggageAllowance { get; set; }
            public bool? personalItem { get; set; }
        }

        public class TravellerCheckedLuggage
        {
            public string travellerReference { get; set; }
            public LuggageAllowance luggageAllowance { get; set; }
        }

        public class TravellerPrice
        {
            public TravellerPriceBreakdown travellerPriceBreakdown { get; set; }
            public string travellerReference { get; set; }
            public string travellerType { get; set; }
        }

        public class TravellerPriceBreakdown
        {
            public Total total { get; set; }
            public BaseFare baseFare { get; set; }
            public Fee fee { get; set; }
            public Tax tax { get; set; }
            public TotalRounded totalRounded { get; set; }
            public MoreTaxesAndFees moreTaxesAndFees { get; set; }
            public Discount discount { get; set; }
            public TotalWithoutDiscount totalWithoutDiscount { get; set; }
            public TotalWithoutDiscountRounded totalWithoutDiscountRounded { get; set; }
        }


    }
}
