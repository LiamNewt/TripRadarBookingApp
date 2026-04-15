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
    /// Interaction logic for HotelDetails.xaml
    /// </summary>
    public partial class HotelDetails : Window
    {
        public HotelDetails(List<Hotel>hotelDetails)
        {
            InitializeComponent();
            foreach (var hotel in hotelDetails)
            {
                MessageBox.Show($"Photo count: {hotel.Photos?.Count}\nFirst photo: {hotel.Photos?.FirstOrDefault()}");
            }
            HotelDetailsPage.ItemsSource = hotelDetails;
        }
    }
}
