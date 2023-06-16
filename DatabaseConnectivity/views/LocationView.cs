using DatabaseConnectivity.Models;

namespace DatabaseConnectivity.views
{
    class LocationView
    {

        public void GetAll(List<Location> locations)
        {
            Console.Clear();

            Console.WriteLine("*** Location List ***\n");

            if (locations.Count > 0)
            {
                foreach (var location in locations)
                {
                    Console.WriteLine("===========================");
                    Console.WriteLine("ID location      : {0}", location.Id);
                    Console.WriteLine("Street Address   : {0}", location.StreetAddress);
                    Console.WriteLine("Postal Code      : {0}", location.PostalCode);
                    Console.WriteLine("City             : {0}", location.City);
                    Console.WriteLine("State Province   : {0}", location.StateProvince);
                    Console.WriteLine("Country ID       : {0}", location.CountryId);
                    Console.WriteLine("===========================");
                }
            }
            else
            {
                Console.WriteLine("Location data is empty!!!");
            }

        }
    }
}
