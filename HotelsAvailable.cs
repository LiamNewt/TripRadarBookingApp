using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripRadar
{
    public class HotelsAvailable
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Appear
        {
            public Component component { get; set; }
            public string id { get; set; }
            public string contentUrl { get; set; }
        }

        public class Checkin
        {
            public string untilTime { get; set; }
            public string fromTime { get; set; }
        }

        public class Checkout
        {
            public string fromTime { get; set; }
            public string untilTime { get; set; }
        }

        public class Component
        {
            public Props props { get; set; }
        }

        public class Content
        {
            public Props props { get; set; }
        }

        public class Data
        {
            public List<Hotel> hotels { get; set; }
            public List<Metum> meta { get; set; }
            //public List<Appear> appear { get; set; }
        }

        public class GrossPrice
        {
            public string currency { get; set; }
            public double value { get; set; }
        }

        public class Hotel
        {
            public string accessibilityLabel { get; set; }
            public Property property { get; set; }
        }

        public class Item
        {
            public Props props { get; set; }
        }

        public class LinkAction
        {
            public Props props { get; set; }
        }

        public class Metum
        {
            public string title { get; set; }
        }

        public class PriceBreakdown
        {
            public List<object> benefitBadges { get; set; }
            public GrossPrice grossPrice { get; set; }
            public List<object> taxExceptions { get; set; }
            public StrikethroughPrice strikethroughPrice { get; set; }
        }

        public class Property
        {
            public string reviewScoreWord { get; set; }
            public int accuratePropertyClass { get; set; }
            public int reviewCount { get; set; }
            public int ufi { get; set; }
            public bool isPreferred { get; set; }
            public bool isFirstPage { get; set; }
            public Checkin checkin { get; set; }
            public int qualityClass { get; set; }
            public int rankingPosition { get; set; }
            public double reviewScore { get; set; }
            public string countryCode { get; set; }
            public int propertyClass { get; set; }
            public List<string> photoUrls { get; set; }
            public string checkoutDate { get; set; }
            public int position { get; set; }
            public double latitude { get; set; }
            public Checkout checkout { get; set; }
            public PriceBreakdown priceBreakdown { get; set; }
            public int optOutFromGalleryChanges { get; set; }
            public string wishlistName { get; set; }
            public List<string> blockIds { get; set; }
            public string currency { get; set; }
            public string checkinDate { get; set; }
            public int id { get; set; }
            public int mainPhotoId { get; set; }
            public string name { get; set; }
            public double longitude { get; set; }
            public bool? isPreferredPlus { get; set; }
        }

        public class Props
        {
            public bool fill { get; set; }
            public Content content { get; set; }
            public string title { get; set; }
            public string text { get; set; }
            public bool fitContentWidth { get; set; }
            public List<Item> items { get; set; }
            public Component component { get; set; }
            public string spacing { get; set; }
            public string accessibilityLabel { get; set; }
            public string icon { get; set; }
            public string tertiaryTintedColor { get; set; }
            public string variant { get; set; }
            public string url { get; set; }
        }

        public class Root
        {
            public bool status { get; set; }
            public string message { get; set; }
            public long timestamp { get; set; }
            public Data data { get; set; }
        }

        public class StrikethroughPrice
        {
            public double value { get; set; }
            public string currency { get; set; }
        }

        public class Text
        {
            public string text { get; set; }
            public string font { get; set; }
            public string color { get; set; }
            public List<LinkAction> linkActions { get; set; }
        }


    }
}
