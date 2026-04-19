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
    /// Interaction logic for MyTrips.xaml
    /// </summary>
    public partial class MyTrips : Window
    {
        public MyTrips()
        {
            InitializeComponent();
            LoadTrips();
        }

        private void LoadTrips()
        {
            using(var db = new TripRadarContext())
            {
                SavedFlightTrips.ItemsSource = db.SavedFlights.ToList();
                SavedHotelTrips.ItemsSource = db.SavedHotels.ToList();
            }
        }

        private void DeleteFlight_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var flight = button.DataContext as SavedFlight;

            using (var db = new TripRadarContext())
            {
                var delFlight = db.SavedFlights.Find(flight.Id);
                db.SavedFlights.Remove(delFlight);
                db.SaveChanges();
            }
            LoadTrips();
        }

        private void DeleteHotel_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var hotel = button.DataContext as SavedHotel;

            using (var db = new TripRadarContext())
            {
                var delHotel = db.SavedHotels.Find(hotel.Id);
                db.SavedHotels.Remove(delHotel);
                db.SaveChanges();
            }
            LoadTrips();
        }
    }
}
