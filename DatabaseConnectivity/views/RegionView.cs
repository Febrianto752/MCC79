using DatabaseConnectivity.Models;

namespace DatabaseConnectivity.views
{
    class RegionView
    {
        public void GetAll(List<Region> regions)
        {
            Console.Clear();

            Console.WriteLine("*** Region List ***\n");

            foreach (var region in regions)
            {
                Console.WriteLine("===========================");
                Console.WriteLine("ID Region   : {0}", region.Id);
                Console.WriteLine("Region Name : {0}", region.Name);
                Console.WriteLine("===========================");
            }

        }

        public void GetById(Region region)
        {
            Console.Clear();
            Console.WriteLine("*** Region Detail ***");
            Console.WriteLine("ID : {0}", region.Id);
            Console.WriteLine("Region Name : {0}", region.Name);
        }


    }
}
