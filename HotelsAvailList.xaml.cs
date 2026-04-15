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
    /// Interaction logic for HotelsAvailList.xaml
    /// </summary>
    public partial class HotelsAvailList : Window
    {
        public HotelsAvailList(List<Hotel>hotelsAvailable)
        {
            InitializeComponent();
            HotelsAvailable.ItemsSource = hotelsAvailable;
        }

        private async void ViewHotel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var button = sender as Button;
                var hotel = button.DataContext as Hotel;
                if (hotel == null)
                {
                    return;
                }
                
                var service = new HotelApiService();
                var details = await service.HotelDetails(
                    hotel.DestID, 
                    hotel.checkIn, 
                    hotel.checkOut, 
                    hotel.Guests
                );
                var HotelDetailsResults = new HotelDetails(details);
                HotelDetailsResults.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening hotel details: {ex.Message}");

            }
        }
    }
}
