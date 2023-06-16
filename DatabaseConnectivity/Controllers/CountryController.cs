using DatabaseConnectivity.Models;
using DatabaseConnectivity.utils;
using DatabaseConnectivity.views;

namespace DatabaseConnectivity.Controllers
{
    class CountryController
    {
        private Country _country = new Country();
        private CountryView _countryView = new CountryView();
        private Region _region = new Region();
        public void ListMenu()
        {
            Console.Clear();
            Console.WriteLine("Loading...");
            List<Country> countries = _country.FindAll();
            _countryView.GetAll(countries);

            Console.WriteLine("\n\nMain menu : ");
            Console.WriteLine("1. Create Country");
            Console.WriteLine("2. Search Country");
            Console.WriteLine("3. Edit Country");
            Console.WriteLine("4. Delete Country");
            Console.WriteLine("5. Back");
            Console.WriteLine("*************");
            Console.Write("Pilihan : ");

            int pilihan = default;

            try
            {
                pilihan = int.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid choice input : ");
                Console.ReadKey();
                ListMenu();
            }

            switch (pilihan)
            {
                case 1:
                    CreateMenu();
                    break;
                case 2:
                    SearchMenu();
                    break;
                case 3:
                    EditMenu();
                    break;
                case 4:
                    DeleteMenu();
                    break;
                case 5:
                    new MainController().MainMenu();
                    break;
                default:
                    Console.WriteLine("Invalid choice input!!!");
                    Console.ReadKey();
                    ListMenu();
                    break;
            }
        }

        public void CreateMenu()
        {
            Console.Clear();
            Console.WriteLine("*** Create Country ***");
            Console.Write("Country id (2 characters) : ");
            string countryId = Console.ReadLine().ToUpper();
            Console.Write("Country Name : ");
            string countryName = Console.ReadLine();

            List<Region> regions = _region.FindAll();
            Console.WriteLine("Pilihan region : ");
            int i = 1;
            foreach (Region region in regions)
            {
                Console.WriteLine($"{i}. {region.Name}");
                i++;
            }

            Console.Write($"region (1 - {i - 1}) : ");

            int pilihanRegion = default;

            // validation pilihan region input
            try
            {
                pilihanRegion = int.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid Input!!!");
                Console.ReadKey();
                ListMenu();
            }

            if (pilihanRegion > i - 1 || pilihanRegion < 1)
            {
                Console.WriteLine("Pilihan tidak tersedia!!!");
                Console.ReadKey();
                ListMenu();
            }

            // validation id country
            bool validId = Validation.MustBeTwoChar(countryId);


            if (validId)
            {
                Country country = _country.FindCountryById(countryId);

                if (country.Id is null)
                {
                    int affectedRows = _country.Create(countryId, countryName, regions[pilihanRegion - 1].Id);

                    if (affectedRows > 0)
                    {
                        Console.WriteLine("Successfull created country!!!");
                        Console.ReadKey();
                        ListMenu();
                    }
                    else
                    {
                        Console.WriteLine("Failed to created country!!!");
                        Console.ReadKey();
                        ListMenu();
                    }
                }
                else
                {
                    Console.WriteLine("country id already exist!!!");
                    Console.ReadKey();
                    ListMenu();
                }


            }
            else
            {
                Console.WriteLine("country id must be 2 characthers");
                Console.ReadKey();
                ListMenu();
            }
        }

        public void SearchMenu()
        {
            Console.Clear();
            Console.WriteLine("*** Search Region By Id ***");
            Console.Write("Enter country id : ");

            string countryId = Console.ReadLine().ToUpper();

            Country country = _country.FindCountryById(countryId);

            if (country.Id is null)
            {
                Console.WriteLine("country id is wrong!!!");
                Console.ReadKey();
                ListMenu();
            }

            _countryView.GetById(country);

            Console.ReadKey();
            ListMenu();
        }

        public void EditMenu()
        {
            Console.Clear();
            Console.WriteLine("*** Edit Country ***");

            Console.Write("Enter country id : ");
            string countryId = Console.ReadLine().ToUpper();

            Country country = _country.FindCountryById(countryId);

            if (country.Id is null)
            {
                Console.WriteLine("country not found!!!");
                Console.ReadKey();
                ListMenu();
            }

            Console.Clear();
            _countryView.PreviousData(country);

            Console.WriteLine("*** Edit Country ***");
            Console.Write("Country name : ");
            string regionName = Console.ReadLine();

            List<Region> regions = _region.FindAll();
            Console.WriteLine("Pilihan region : ");
            int i = 1;
            foreach (Region region in regions)
            {
                Console.WriteLine($"{i}. {region.Name}");
                i++;
            }

            Console.Write($"region (1 - {i - 1}) : ");

            int pilihanRegion = default;

            // validation pilihan region input
            try
            {
                pilihanRegion = int.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid input!!!");
                Console.ReadKey();
                ListMenu();
            }

            if (pilihanRegion > i - 1 || pilihanRegion < 1)
            {
                Console.WriteLine("Pilihan tidak tersedia!!!");
                Console.ReadKey();
                ListMenu();
            }

            int affectedRows = _country.Update(countryId, regionName, pilihanRegion);

            if (affectedRows > 0)
            {
                Console.WriteLine("Successfull updated country!!!");
                Console.ReadKey();
                ListMenu();
            }
            else
            {
                Console.WriteLine("Failed to updated country!!!");
                Console.ReadKey();
                ListMenu();
            }
        }

        public void DeleteMenu()
        {
            Console.Clear();
            Console.WriteLine("*** Delete Country ***");
            Console.Write("Enter country id : ");

            string countryId = Console.ReadLine().ToUpper();

            Country country = _country.FindCountryById(countryId);

            if (country.Id is not null)
            {
                int affectedRows = _country.Delete(countryId);

                if (affectedRows > 0)
                {
                    Console.WriteLine("Successfull deleted country!!!");
                    Console.ReadKey();
                    ListMenu();
                }
                else
                {
                    Console.WriteLine("Failed to deleted country!!!");
                    Console.ReadKey();
                    ListMenu();
                }
            }
            else
            {
                Console.WriteLine("country is not found!!!");
                Console.ReadLine();
                ListMenu();
            }
        }
    }
}
