using DatabaseConnectivity.Models;

namespace DatabaseConnectivity.views
{
    class CountryView
    {
        public void GetAll(List<Country> countries)
        {

            Console.Clear();

            Console.WriteLine("*** Country List ***\n");

            foreach (var country in countries)
            {
                Console.WriteLine("===========================");
                Console.WriteLine("ID country   : {0}", country.Id);
                Console.WriteLine("Name         : {0}", country.Name);
                Console.WriteLine("Region ID    : {0}", country.RegionId);
                Console.WriteLine("===========================");
            }

        }

        public void GetById(Country country)
        {
            Console.Clear();
            Console.WriteLine("*** Country Detail ***");
            Console.WriteLine("ID : {0}", country.Id);
            Console.WriteLine("Country Name : {0}", country.Name);
            Console.WriteLine("Region ID : {0}", country.RegionId);
        }

        public void PreviousData(Country country)
        {
            Console.WriteLine("Previous Data Country :");
            Console.WriteLine("ID        : {0}", country.Id);
            Console.WriteLine("Name      : {0}", country.Name);
            Console.WriteLine("Region ID : {0}", country.RegionId);
            Console.WriteLine("\n\n");
        }

    }
}
