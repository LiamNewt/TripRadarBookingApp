using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace TripRadar
{
    public partial class MainWindow : Window
    {
        private Hotel _selectedArea;
        public MainWindow()
        {
            InitializeComponent();
        }
    
        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        

        private async void SearchAirportsDepart(object sender, RoutedEventArgs e)
        {
           var service = new BookingApiService();
           var airports = await service.SearchAirports(SearchTextBoxDepart.Text);
           FlightsListBoxDepart.ItemsSource = airports;
        }

        private async void SearchAirportsArrive(object sender, RoutedEventArgs e)
        {
            var service = new BookingApiService();
            var airports = await service.SearchAirports(SearchTextBoxArrival.Text);
            FlightsListBoxArrival.ItemsSource = airports;

        }


        private async void CheckFlights_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var fromAirport = (Airport)FlightsListBoxDepart.SelectedItem;
                var toAirport = (Airport)FlightsListBoxArrival.SelectedItem;
                var numPassengers = int.Parse(((ComboBoxItem)Passengers.SelectedItem).Content.ToString());


                if (fromAirport == null || toAirport == null)
                {
                    MessageBox.Show("Please select both airports.");
                    return;
                }

                var departureDate = DepartureDatePicker.SelectedDate;

                if (departureDate == null)
                {
                    MessageBox.Show("Please select a departure date.");
                    return;
                }

                DateTime? returnDate = null;
                if (Return.IsChecked == true)
                {
                    if (ArrivalDatePicker.SelectedDate == null)
                    {
                        MessageBox.Show("Please enter a return date");
                        return;
                    }
                    returnDate = ArrivalDatePicker.SelectedDate;
                }

                var service = new BookingApiService();

                var flights = await service.SearchFlights(
                    fromAirport.ID,
                    toAirport.ID,
                    departureDate.Value,
                    numPassengers,
                    returnDate);

                var resultsFlight = new FlightResultsWindow(flights);
                resultsFlight.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error{ex.Message}");
            }
        }

        private void FlightsListBoxDepart_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = (Airport)FlightsListBoxDepart.SelectedItem;
            if (selected != null)
            {
                SearchTextBoxDepart.Text = selected.Name;
                FlightsListBoxDepart.Visibility = Visibility.Collapsed;
            }

        }

        private void FlightsListBoxArrival_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = (Airport)FlightsListBoxArrival.SelectedItem;
            if (selected != null)
            {
                SearchTextBoxArrival.Text = selected.Name;
                FlightsListBoxArrival.Visibility = Visibility.Collapsed; // hide list after selection
            }

        }

        //Hotel Button Click Events

        private async void SearchHotelDest_Click(object sender, RoutedEventArgs e)
        {
            var service = new HotelApiService();
            var hotels = await service.HotelAreaSearch(SearchTextBoxHotel.Text);
            HotelListBoxSearch.ItemsSource = hotels;

        }

        private void HotelListBoxSearch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = (Hotel)HotelListBoxSearch.SelectedItem;
            if (selected != null)
            {
                _selectedArea = selected;
                SearchTextBoxHotel.Text = selected.HotelName;
                HotelListBoxSearch.Visibility = Visibility.Collapsed;
            }
        }


        private async void SearchHotelAv_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var checkInDate = FromDatePicker.SelectedDate;
                var checkOutDate = ToDatePicker.SelectedDate;
                var guestsNum= int.Parse(((ComboBoxItem)Guests.SelectedItem).Content.ToString());

                var service = new HotelApiService();

                var hotelsList = await service.HotelsAvailable(
                    _selectedArea.DestID,
                    checkInDate.Value,
                    checkOutDate.Value,
                    guestsNum
                    );

                var resultsHotels = new HotelsAvailList(hotelsList);
                resultsHotels.Left = this.Left + 510;
                resultsHotels.Top = this.Top + 170;
                resultsHotels.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");

            }
        }




    }
}
