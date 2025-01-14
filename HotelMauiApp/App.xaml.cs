using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using HotelMauiApp.Models;
using HotelMauiApp.Services;


namespace HotelMauiApp
{
    public partial class App : Application
    {
        private static HotelManagementDb _database;
        public static HotelManagementDb Database
        {
            get
            {
                if (_database == null)
                {
                    string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "HotelManagementDb.db3");
                    _database = new HotelManagementDb(
                        new RestService<Room>("Room"),
                        new RestService<Booking>("Booking"),
                        new RestService<Notification>("Notification"),
                        new RestService<Review>("Review"));
                }
                return _database;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
