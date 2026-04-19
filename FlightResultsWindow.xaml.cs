using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TripRadar
{
    /// <summary>
    /// Interaction logic for FlightResultsWindow.xaml
    /// </summary>
    public partial class FlightResultsWindow : Window
    {
        public FlightResultsWindow(List<Flight>flights)
        {
            InitializeComponent();
            FlightsItemControl.ItemsSource = flights;
        }

        private async void AddFlight_Click(object sender, RoutedEventArgs e) //view flight details button handler
        {
            try
            {
                //button
                var button = sender as Button;
                var flight = button.DataContext as Flight;
                if (flight == null)
                {
                    return;
                }

                //service
                var service = new BookingApiService();
                var details = await service.FlightDetails(
                    flight.Token

                );
                var flightDetailsResults = new FlightDetails(details);
                flightDetailsResults.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding flight: {ex.Message}");

            }
        }
    }
}
