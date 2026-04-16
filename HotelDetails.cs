using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripRadar
{
    public partial class HotelDetails
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class _19160501
        {
            public List<Facility> facilities { get; set; }
            public ChildrenAndBedsText children_and_beds_text { get; set; }
            public PrivateBathroomHighlight private_bathroom_highlight { get; set; }
            public List<BedConfiguration> bed_configurations { get; set; }
            public int private_bathroom_count { get; set; }
            public List<Highlight> highlights { get; set; }
            public string description { get; set; }
            public List<Photo> photos { get; set; }
        }

        public class AgeInterval
        {
            public GroupByPrice group_by_price { get; set; }
            public int min_age { get; set; }
            public Crib crib { get; set; }
            public List<List<string>> types_by_price { get; set; }
            public int max_age { get; set; }
            public ExtraBed extra_bed { get; set; }
        }

        public class AggregatedData
        {
            public int has_seating { get; set; }
            public int? has_refundable { get; set; }
            public List<CommonKitchenFac> common_kitchen_fac { get; set; }
            public int has_kitchen { get; set; }
            public int? has_nonrefundable { get; set; }
        }

        public class AllInclusiveAmount
        {
            public double value { get; set; }
            public string currency { get; set; }
            public string amount_unrounded { get; set; }
            public string amount_rounded { get; set; }
        }

        public class AllInclusiveAmountHotelCurrency
        {
            public string amount_rounded { get; set; }
            public string amount_unrounded { get; set; }
            public string currency { get; set; }
            public double value { get; set; }
        }

        public class Amount
        {
            public string currency { get; set; }
            public double value { get; set; }
        }

        public class Base
        {
            public int base_amount { get; set; }
            public string kind { get; set; }
        }

        public class BedConfiguration
        {
            public List<BedType> bed_types { get; set; }
        }

        public class BedType
        {
            public object description_localized { get; set; }
            public string name { get; set; }
            public string description_imperial { get; set; }
            public string name_with_count { get; set; }
            public int bed_type { get; set; }
            public int count { get; set; }
            public string description { get; set; }
        }

        public class Benefit
        {
            public object icon { get; set; }
            public string name { get; set; }
            public string badge_variant { get; set; }
            public string kind { get; set; }
            public string details { get; set; }
            public string identifier { get; set; }
        }

        public class Block
        {
            public int full_board { get; set; }
            public int deposit_required { get; set; }
            public FitOccupancy fit_occupancy { get; set; }
            public int breakfast_included { get; set; }
            public List<object> bh_room_highlights { get; set; }
            public string is_block_fit { get; set; }
            public Paymentterms paymentterms { get; set; }
            public int extrabed_available { get; set; }
            public string max_occupancy { get; set; }
            public int pod_ios_migrate_policies_to_smp_fullon { get; set; }
            public string block_id { get; set; }
            public string name { get; set; }
            public int must_reserve_free_parking { get; set; }
            public string name_without_policy { get; set; }
            public int nr_children { get; set; }
            public int package_id { get; set; }
            public int can_reserve_free_parking { get; set; }
            public int is_domestic_rate { get; set; }
            public int genius_discount_percentage { get; set; }
            public int max_children_free_age { get; set; }
            public int number_of_bathrooms { get; set; }
            public int is_last_minute_deal { get; set; }
            public int room_count { get; set; }
            public int smoking { get; set; }
            public int half_board { get; set; }
            public double room_surface_in_feet2 { get; set; }
            public int is_flash_deal { get; set; }
            public List<object> children_ages { get; set; }
            public string room_name { get; set; }
            public object extrabed_available_amount { get; set; }
            public int number_of_bedrooms { get; set; }
            public int nr_adults { get; set; }
            public int all_inclusive { get; set; }
            public int babycots_available { get; set; }
            public BlockText block_text { get; set; }
            public string refundable_until { get; set; }
            public int is_smart_deal { get; set; }
            public int room_surface_in_m2 { get; set; }
            public int roomtype_id { get; set; }
            public string mealplan { get; set; }
            public int max_children_free { get; set; }
            public int room_id { get; set; }
            public string refundable { get; set; }
            public object babycots_available_amount { get; set; }
            public int fit_status { get; set; }
        }

        public class BlockText
        {
            public List<Policy> policies { get; set; }
        }

        public class BookingHome
        {
        }

        public class BreakfastReviewScore
        {
            public int review_count { get; set; }
            public double? review_score { get; set; }
            public double? rating { get; set; }
            public string review_snippet { get; set; }
            public string review_score_word { get; set; }
            public int review_number { get; set; }
        }

        public class Cancellation
        {
            public int guaranteed_non_refundable { get; set; }
            public Timeline timeline { get; set; }
            public string type_translation { get; set; }
            public string bucket { get; set; }
            public Info info { get; set; }
            public string type { get; set; }
            public int non_refundable_anymore { get; set; }
            public string description { get; set; }
        }

        public class ChargesDetails
        {
            public Amount amount { get; set; }
            public string translated_copy { get; set; }
            public string mode { get; set; }
        }

        public class Checkin
        {
            public string fromTime { get; set; }
            public string untilTime { get; set; }
        }

        public class Checkout
        {
            public string fromTime { get; set; }
            public string untilTime { get; set; }
        }

        public class ChildrenAndBedsText
        {
            public List<AgeInterval> age_intervals { get; set; }
            public int allow_children { get; set; }
            public List<ChildrenAtTheProperty> children_at_the_property { get; set; }
            public List<CribsAndExtraBed> cribs_and_extra_beds { get; set; }
        }

        public class ChildrenAtTheProperty
        {
            public int highlight { get; set; }
            public string text { get; set; }
        }

        public class CommonKitchenFac
        {
            public string name { get; set; }
            public int id { get; set; }
        }

        public class CompositePriceBreakdown
        {
            public StrikethroughAmount strikethrough_amount { get; set; }
            public int has_long_stays_monthly_rate_price { get; set; }
            public List<PriceDisplayConfig> price_display_config { get; set; }
            public List<Benefit> benefits { get; set; }
            public AllInclusiveAmountHotelCurrency all_inclusive_amount_hotel_currency { get; set; }
            public StrikethroughAmountPerNight strikethrough_amount_per_night { get; set; }
            public DiscountedAmount discounted_amount { get; set; }
            public GrossAmountHotelCurrency gross_amount_hotel_currency { get; set; }
            public NetAmount net_amount { get; set; }
            public ExcludedAmount excluded_amount { get; set; }
            public int has_long_stays_weekly_rate_price { get; set; }
            public IncludedTaxesAndChargesAmount included_taxes_and_charges_amount { get; set; }
            public ChargesDetails charges_details { get; set; }
            public GrossAmountPerNight gross_amount_per_night { get; set; }
            public GrossAmount gross_amount { get; set; }
            public List<Item> items { get; set; }
            public AllInclusiveAmount all_inclusive_amount { get; set; }
        }

        public class Crib
        {
            public int price_mode_n { get; set; }
            public string price_mode { get; set; }
            public int price { get; set; }
            public int guaranteed { get; set; }
            public string price_type { get; set; }
            public int price_type_n { get; set; }
            public int id { get; set; }
        }

        public class CribsAndExtraBed
        {
            public int highlight { get; set; }
            public string text { get; set; }
        }

        public class Data
        {
            public int ufi { get; set; }
            public int hotel_id { get; set; }
            public string hotel_name { get; set; }
            public string url { get; set; }
            public string hotel_name_trans { get; set; }
            public int review_nr { get; set; }
            public string arrival_date { get; set; }
            public string departure_date { get; set; }
            public string price_transparency_mode { get; set; }
            public string accommodation_type_name { get; set; }
            public double latitude { get; set; }
            public double longitude { get; set; }
            public string address { get; set; }
            public string address_trans { get; set; }
            public string city { get; set; }
            public string city_trans { get; set; }
            public string city_in_trans { get; set; }
            public string city_name_en { get; set; }
            public string district { get; set; }
            public string countrycode { get; set; }
            public double? distance_to_cc { get; set; }
            public string default_language { get; set; }
            public string country_trans { get; set; }
            public string currency_code { get; set; }
            public string zip { get; set; }
            public string timezone { get; set; }
            public string rare_find_state { get; set; }
            public int soldout { get; set; }
            public int available_rooms { get; set; }
            public int max_rooms_in_reservation { get; set; }
            public string average_room_size_for_ufi_m2 { get; set; }
            public int is_family_friendly { get; set; }
            public int is_closed { get; set; }
            public int is_crimea { get; set; }
            public int is_hotel_ctrip { get; set; }
            public int is_price_transparent { get; set; }
            public int is_genius_deal { get; set; }
            public int is_cash_accepted_check_enabled { get; set; }
            public int qualifies_for_no_cc_reservation { get; set; }
            public int hotel_include_breakfast { get; set; }
            public string cc1 { get; set; }
            public List<string> family_facilities { get; set; }
            public ProductPriceBreakdown product_price_breakdown { get; set; }
            public CompositePriceBreakdown composite_price_breakdown { get; set; }
            public List<PropertyHighlightStrip> property_highlight_strip { get; set; }
            public FacilitiesBlock facilities_block { get; set; }
            public List<TopUfiBenefit> top_ufi_benefits { get; set; }
            public LanguagesSpoken languages_spoken { get; set; }
            public List<string> spoken_languages { get; set; }
            public BreakfastReviewScore breakfast_review_score { get; set; }
            public WifiReviewScore wifi_review_score { get; set; }
            public MinRoomDistribution min_room_distribution { get; set; }
            public List<object> tax_exceptions { get; set; }
            public BookingHome booking_home { get; set; }
            public AggregatedData aggregated_data { get; set; }
            public LastReservation last_reservation { get; set; }
            public List<FreeFacilitiesCancelBreakfast> free_facilities_cancel_breakfast { get; set; }
            public List<RoomRecommendation> room_recommendation { get; set; }
            public HotelText hotel_text { get; set; }
            public List<int> districts { get; set; }
            public List<object> preferences { get; set; }
            public List<HotelImportantInformationWithCode> hotel_important_information_with_codes { get; set; }
            public Rooms rooms { get; set; }
            public List<Block> block { get; set; }
            public RawData rawData { get; set; }
        }

        public class DiscountedAmount
        {
            public double value { get; set; }
            public string amount_unrounded { get; set; }
            public string currency { get; set; }
            public string amount_rounded { get; set; }
        }

        public class ExcludedAmount
        {
            public string amount_rounded { get; set; }
            public string amount_unrounded { get; set; }
            public string currency { get; set; }
            public double value { get; set; }
        }

        public class ExtraBed
        {
            public string price { get; set; }
            public string price_type { get; set; }
            public int price_mode_n { get; set; }
            public string price_mode { get; set; }
            public int id { get; set; }
            public int price_type_n { get; set; }
        }

        public class FacilitiesBlock
        {
            public string name { get; set; }
            public string type { get; set; }
            public List<Facility> facilities { get; set; }
        }

        public class Facility
        {
            public string icon { get; set; }
            public string name { get; set; }
            public int facilitytype_id { get; set; }
            public int alt_facilitytype_id { get; set; }
            public string alt_facilitytype_name { get; set; }
            public int id { get; set; }
        }

        public class FitOccupancy
        {
            public int nr_adults { get; set; }
            public List<object> children_ages { get; set; }
        }

        public class FreeFacilitiesCancelBreakfast
        {
            public int facility_id { get; set; }
        }

        public class GrossAmount
        {
            public string amount_rounded { get; set; }
            public double value { get; set; }
            public string amount_unrounded { get; set; }
            public string currency { get; set; }
        }

        public class GrossAmountHotelCurrency
        {
            public string amount_rounded { get; set; }
            public string amount_unrounded { get; set; }
            public string currency { get; set; }
            public double value { get; set; }
        }

        public class GrossAmountPerNight
        {
            public string currency { get; set; }
            public string amount_unrounded { get; set; }
            public double value { get; set; }
            public string amount_rounded { get; set; }
        }

        public class GrossPrice
        {
            public string amountRounded { get; set; }
            public string currency { get; set; }
            public double value { get; set; }
        }

        public class GroupByPrice
        {
            [JsonProperty("free,per_night,0")]
            public List<string> freeper_night0 { get; set; }

            [JsonProperty("fixed,per_night,21.70")]
            public List<string> fixedper_night2170 { get; set; }
        }

        public class Highlight
        {
            public string icon { get; set; }
            public string translated_name { get; set; }
            public int? id { get; set; }
        }

        public class HotelImportantInformationWithCode
        {
            public string phrase { get; set; }
            public int executing_phase { get; set; }
            public int sentence_id { get; set; }
        }

        public class HotelText
        {
        }

        public class IconList
        {
            public string icon { get; set; }
            public int size { get; set; }
        }

        public class IncludedTaxesAndChargesAmount
        {
            public string amount_rounded { get; set; }
            public double value { get; set; }
            public string currency { get; set; }
            public string amount_unrounded { get; set; }
        }

        public class Info
        {
            public string timezone_offset { get; set; }
            public int? is_midnight { get; set; }
            public DateTime? refundable_date { get; set; }
            public string time_before_midnight { get; set; }
            public string time { get; set; }
            public string timezone { get; set; }
            public DateTime refundable_date_midnight { get; set; }
            public string refundable { get; set; }
            public string date_before { get; set; }
            public string date { get; set; }
            public string date_raw { get; set; }
            public string date_before_raw { get; set; }
            public int prepayment_at_booktime { get; set; }
        }

        public class Item
        {
            public ItemAmount item_amount { get; set; }
            public string kind { get; set; }
            public string name { get; set; }
            public string details { get; set; }
            public Base @base { get; set; }
            public string inclusion_type { get; set; }
            public string identifier { get; set; }
        }

        public class ItemAmount
        {
            public string amount_rounded { get; set; }
            public string currency { get; set; }
            public string amount_unrounded { get; set; }
            public double value { get; set; }
        }

        public class LanguagesSpoken
        {
            public List<string> languagecode { get; set; }
        }

        public class LastReservation
        {
            public object countrycode { get; set; }
            public string time { get; set; }
            public object country { get; set; }
        }

        public class MinRoomDistribution
        {
            public List<object> children { get; set; }
            public int adults { get; set; }
        }

        public class NetAmount
        {
            public string currency { get; set; }
            public string amount_unrounded { get; set; }
            public double value { get; set; }
            public string amount_rounded { get; set; }
        }

        public class Paymentterms
        {
            public Cancellation cancellation { get; set; }
            public Prepayment prepayment { get; set; }
        }

        public class Photo
        {
            public string url_original { get; set; }
            public string url_square180 { get; set; }
            public string url_square60 { get; set; }
            public string url_640x200 { get; set; }
            public string last_update_date { get; set; }
            public string url_max1280 { get; set; }
            public string url_max750 { get; set; }
            public string url_max300 { get; set; }
            public double ratio { get; set; }
            public int photo_id { get; set; }
        }

        public class Policy
        {
            public string @class { get; set; }
            public string content { get; set; }
            public string mealplan_vector { get; set; }
        }

        public class Prepayment
        {
            public string type_extended { get; set; }
            public string extended_type_translation { get; set; }
            public string description { get; set; }
            public string type { get; set; }
            public Info info { get; set; }
            public string simple_translation { get; set; }
            public string type_translation { get; set; }
            public Timeline timeline { get; set; }
        }

        public class PriceBreakdown
        {
            public string chargesInfo { get; set; }
            public GrossPrice grossPrice { get; set; }
            public List<object> benefitBadges { get; set; }
            public List<object> taxExceptions { get; set; }
        }

        public class PriceDisplayConfig
        {
            public string key { get; set; }
            public double value { get; set; }
        }

        public class PrivateBathroomHighlight
        {
            public int has_highlight { get; set; }
        }

        public class ProductPriceBreakdown
        {
            public GrossAmountPerNight gross_amount_per_night { get; set; }
            public AllInclusiveAmount all_inclusive_amount { get; set; }
            public List<Item> items { get; set; }
            public GrossAmount gross_amount { get; set; }
            public IncludedTaxesAndChargesAmount included_taxes_and_charges_amount { get; set; }
            public int? has_long_stays_weekly_rate_price { get; set; }
            public ChargesDetails charges_details { get; set; }
            public ExcludedAmount excluded_amount { get; set; }
            public int nr_stays { get; set; }
            public NetAmount net_amount { get; set; }
            public DiscountedAmount discounted_amount { get; set; }
            public GrossAmountHotelCurrency gross_amount_hotel_currency { get; set; }
            public List<Benefit> benefits { get; set; }
            public AllInclusiveAmountHotelCurrency all_inclusive_amount_hotel_currency { get; set; }
            public StrikethroughAmountPerNight strikethrough_amount_per_night { get; set; }
            public int has_long_stays_monthly_rate_price { get; set; }
            public List<PriceDisplayConfig> price_display_config { get; set; }
            public StrikethroughAmount strikethrough_amount { get; set; }
        }

        public class PropertyHighlightStrip
        {
            public List<IconList> icon_list { get; set; }
            public string name { get; set; }
        }

        public class RawData
        {
            public string checkinDate { get; set; }
            public bool isFirstPage { get; set; }
            public string reviewScoreWord { get; set; }
            public int optOutFromGalleryChanges { get; set; }
            public double latitude { get; set; }
            public List<string> photoUrls { get; set; }
            public string name { get; set; }
            public PriceBreakdown priceBreakdown { get; set; }
            public int mainPhotoId { get; set; }
            public int position { get; set; }
            public string wishlistName { get; set; }
            public List<string> blockIds { get; set; }
            public string currency { get; set; }
            public int qualityClass { get; set; }
            public int reviewCount { get; set; }
            public Checkout checkout { get; set; }
            public double longitude { get; set; }
            public int accuratePropertyClass { get; set; }
            public int propertyClass { get; set; }
            public string checkoutDate { get; set; }
            public Checkin checkin { get; set; }
            public int rankingPosition { get; set; }
            public int ufi { get; set; }
            public double reviewScore { get; set; }
            public string countryCode { get; set; }
            public int id { get; set; }
            public bool isHighlightedHotel { get; set; }
        }

        public class RoomRecommendation
        {
            public int extra_babycots_price_in_hotel_currency { get; set; }
            public int extra_beds_for_children_price { get; set; }
            public int number_of_extra_babycots { get; set; }
            public int extra_beds_for_adults_price_in_hotel_currency { get; set; }
            public int extra_babycots_price { get; set; }
            public int number_of_extra_beds_for_children { get; set; }
            public int children { get; set; }
            public int adults { get; set; }
            public int babies { get; set; }
            public string block_id { get; set; }
            public int total_extra_bed_price_in_hotel_currency { get; set; }
            public int extra_beds_for_adults_price { get; set; }
            public int number_of_extra_beds_for_adults { get; set; }
            public int extra_beds_for_children_price_in_hotel_currency { get; set; }
            public int number_of_extra_beds_and_babycots_total { get; set; }
            public int total_extra_bed_price { get; set; }
        }

        public class Rooms : Dictionary<string, RoomDetails> { }
        
            public class RoomDetails
            {
                public List<Photo> photos { get; set; }
            }
            
        

        public class Root
        {
            public bool status { get; set; }
            public string message { get; set; }
            public long timestamp { get; set; }
            public Data data { get; set; }
        }

        public class Stage
        {
            public string stage_translation { get; set; }
            public string limit_timezone { get; set; }
            public string limit_until { get; set; }
            public string u_fee_remaining { get; set; }
            public string limit_from_raw { get; set; }
            public double? stage_fee { get; set; }
            public int b_number { get; set; }
            public int effective_number { get; set; }
            public string limit_until_date { get; set; }
            public string u_stage_fee_pretty { get; set; }
            public double? fee { get; set; }
            public int current_stage { get; set; }
            public string b_state { get; set; }
            public string fee_remaining_pretty { get; set; }
            public int is_effective { get; set; }
            public string limit_from { get; set; }
            public string limit_from_time { get; set; }
            public string text_refundable { get; set; }
            public string date_until { get; set; }
            public string limit_until_time { get; set; }
            public double? fee_remaining { get; set; }
            public string u_fee_remaining_pretty { get; set; }
            public string stage_fee_pretty { get; set; }
            public string limit_from_date { get; set; }
            public string u_fee_pretty { get; set; }
            public string limit_until_raw { get; set; }
            public string text { get; set; }
            public int fee_rounded { get; set; }
            public string u_fee { get; set; }
            public string u_stage_fee { get; set; }
            public string fee_pretty { get; set; }
            public int is_free { get; set; }
            public string date_from { get; set; }
            public string amount_pretty { get; set; }
            public double? amount { get; set; }
            public int? after_checkin { get; set; }
        }

        public class StrikethroughAmount
        {
            public string amount_rounded { get; set; }
            public string amount_unrounded { get; set; }
            public string currency { get; set; }
            public double value { get; set; }
        }

        public class StrikethroughAmountPerNight
        {
            public string amount_rounded { get; set; }
            public string currency { get; set; }
            public string amount_unrounded { get; set; }
            public double value { get; set; }
        }

        public class Timeline
        {
            public string u_currency_code { get; set; }
            public string policygroup_instance_id { get; set; }
            public List<Stage> stages { get; set; }
            public string currency_code { get; set; }
            public int nr_stages { get; set; }
        }

        public class TopUfiBenefit
        {
            public string translated_name { get; set; }
            public string icon { get; set; }
        }

        public class WifiReviewScore
        {
            public double rating { get; set; }
        }

        


    }
}
