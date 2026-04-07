using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripRadar
{
    public class CarsAvailable
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Category
        {
            public string id { get; set; }
            public string name { get; set; }
        }

        public class Content
        {
            public object discountBanner { get; set; }
            public object dsaBanner { get; set; }
        }

        public class Data
        {
            public object discount_banner { get; set; }
            public string provider { get; set; }
            public Content content { get; set; }
            public List<Sort> sort { get; set; }
            public bool is_genius_location { get; set; }
            public string title { get; set; }
            public string type { get; set; }
            public Meta meta { get; set; }
            public int count { get; set; }
            public string search_key { get; set; }
            public List<SearchResult> search_results { get; set; }
            public List<Filter> filter { get; set; }
        }

        public class Filter
        {
            public List<Category> categories { get; set; }
            public string id { get; set; }
            public Layout layout { get; set; }
            public string type { get; set; }
            public string title { get; set; }
        }

        public class Layout
        {
            public string layout_type { get; set; }
        }

        public class Meta
        {
            public int response_code { get; set; }
        }

        public class Root
        {
            public bool status { get; set; }
            public string message { get; set; }
            public long timestamp { get; set; }
            public Data data { get; set; }
        }

        public class Sort
        {
            public string identifier { get; set; }
            public string title_tag { get; set; }
            public string name { get; set; }
        }

        //Added Classes as info was deeply nested in <object> and was not being deserialized correctly.
        
        public class SearchResult
        {
            public VehicleInfo vehicle_info { get; set; }
            public Pricing pricing_info { get; set; }
            public SupplierInfo supplier_info { get; set; }
            public Recommendation recommendation { get; set; }
            public List<Route> route_info { get; set; }
        }

        public class VehicleInfo
        {
            public string v_name { get; set; }
            public string group { get; set; }
            public string transmission { get; set; }
            public int door_count { get; set; }
            public int seats { get; set; }
            public int small_suitcases { get; set; }
            public int large_suitcases { get; set; }
            public bool air_conditioning { get; set; }
            public string image_url { get; set; }
            public string fuel_policy { get; set; }
        }
        public class Pricing
        {
            public double base_price { get; set; }
            public double drive_away_price { get; set; }
            public string currency { get; set; }
            public double price { get; set; }
        }
        public class SupplierInfo
        {
            public string name { get; set; }
            public string logo_url { get; set; }
            public double rating { get; set; }
            public int rating_count { get; set; }
        }
        public class Recommendation
        {
            public string tag { get; set; }
        }
        public class Route
        {
            public string pickup_location { get; set; }
            public string dropoff_location { get; set; }
        }

    }
}
