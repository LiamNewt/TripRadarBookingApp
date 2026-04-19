using DataManagement;
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
    /// Interaction logic for FlightDetails.xaml
    /// </summary>
    public partial class FlightDetails : Window
    {
        public FlightDetails(List<Flight> flightDetails)
        {
            InitializeComponent();
            FlightDetailsPage.ItemsSource = flightDetails;
        }

        private void AddFlightTrip_Click(object sender, RoutedEventArgs e)//add flight to my trips button handler
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

                using (var db = new TripRadarContext()) //add to database
                {
                    db.SavedFlights.Add(new SavedFlight
                    {
                        DepartureAirport = flight.DepartureAirport,
                        ArrivalAirport = flight.ArrivalAirport,
                        DepartureTime = flight.DepartureTime,
                        ArrivalTime = flight.ArrivalTime,
                        AirlineCode = flight.AirlineCode,
                        Price = flight.Price,
                        CabinClass = flight.CabinClass,
                        SavedOn = DateTime.Now,
                        ReturnDepartureAirport = flight.ReturnDepartureAirport,
                        ReturnArrivalAirport = flight.ReturnArrivalAirport,
                        ReturnDepartureTime = flight.ReturnDepartureTime,
                        ReturnArrivalTime = flight.ReturnArrivalTime
                    });
                    db.SaveChanges();
                    MessageBox.Show("Saved Flight to My Trips");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }

        }
    }
}
