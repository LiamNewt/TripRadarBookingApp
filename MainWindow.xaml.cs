using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace TripRadar
{
    public partial class MainWindow : Window
    {

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

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AccountBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MyTripsBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void CheckFlights_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var fromAirport = (Airport)FlightsListBoxDepart.SelectedItem;
                var toAirport = (Airport)FlightsListBoxArrival.SelectedItem;

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

                var service = new BookingApiService();

                var flights = await service.SearchFlights(
                    fromAirport.ID,
                    toAirport.ID,
                    departureDate.Value);

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
    }
}
