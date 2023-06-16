using DatabaseConnectivity.Models;
using DatabaseConnectivity.views;

namespace DatabaseConnectivity.Controllers
{
    class LocationController
    {
        private Location _location = new Location();
        private LocationView _locationView = new LocationView();
        public void ListMenu()
        {
            Console.Clear();
            Console.WriteLine("Loading...");

            List<Location> locations = _location.FindAll();
            _locationView.GetAll(locations);

            Console.WriteLine("\nPress any key for back!");
            Console.ReadLine();
            new MainController().MainMenu();

        }
    }
}
