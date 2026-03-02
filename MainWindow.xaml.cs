using System;
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

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var airportName = SearchTextBox?.Text ?? string.Empty;
            var app = new TripRadarApp();
            var result = await app.SearchFlights(airportName);

            if (result?.data != null && result.data.Any())
            {
                FlightsListBox.ItemsSource = result.data.Select(data => $"{data.name} ({data.code}) - {data.cityName}");
            }
            else
            {
                MessageBox.Show("No results found.", "Search Results", MessageBoxButton.OK, MessageBoxImage.Information);
                FlightsListBox.ItemsSource = null;
            }
        }
    }
}
