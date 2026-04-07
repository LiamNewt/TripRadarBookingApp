using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;

namespace TripRadar
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var splashScreen = new Startup();
            splashScreen.Show();

            System.Threading.Thread.Sleep(2000);

            var MainWindow = new MainWindow();
            MainWindow.Show();

            splashScreen.Close();
        }
    }
    internal class Program
    {

    }

    

}


