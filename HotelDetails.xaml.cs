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
using DataManagement;

namespace TripRadar
{
    /// <summary>
    /// Interaction logic for HotelDetails.xaml
    /// </summary>
    public partial class HotelDetails : Window
    {
        public HotelDetails(List<Hotel>hotelDetails)
        {
            InitializeComponent();
            HotelDetailsPage.ItemsSource = hotelDetails;
        }

        private void AddHotel_Click(object sender, RoutedEventArgs e)//add hotel to trips button handler
        {
            try
            {
                //button
                var button = sender as Button;
                var hotel = button.DataContext as Hotel;

                if (hotel == null)
                {
                    return;
                }

                using (var db = new TripRadarContext()) //add to database
                {
                    db.SavedHotels.Add(new SavedHotel
                    {
                        HotelDetName = hotel.HotelDetName,
                        City = hotel.City,
                        Address = hotel.Address,
                        PricePNight = hotel.PricePNight,
                        ImageUrl = hotel.ImageUrl,
                        Arrival = hotel.Arrival,
                        Departure = hotel.Departure,
                        RoomType = hotel.RoomType,
                        SavedOn = DateTime.Now
                    });
                    db.SaveChanges();
                    MessageBox.Show("Saved Hotel to My Trips");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
