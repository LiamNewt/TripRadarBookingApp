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

        private void AddFlightTrip_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
