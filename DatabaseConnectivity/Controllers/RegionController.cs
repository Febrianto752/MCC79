using DatabaseConnectivity.Models;
using DatabaseConnectivity.views;

namespace DatabaseConnectivity.Controllers
{

    class RegionController
    {
        // instance region model
        private Region _region = new Region();
        private RegionView _regionView = new RegionView();
        private GeneralView _generalView = new GeneralView();

        public void ListMenu()
        {
            List<Region> regions = _region.FindAll();
            _regionView.GetAll(regions);

            Console.WriteLine("\n\nMain menu : ");
            Console.WriteLine("1. Create Region");
            Console.WriteLine("2. Search Region");
            Console.WriteLine("3. Edit Region");
            Console.WriteLine("4. Delete Region");
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
                _generalView.ErrorMessage("Invalid Input!!!");
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
                    new MainController().Menu();
                    break;
                default:
                    _generalView.ErrorMessage("Invalid Input!!!");
                    Console.ReadKey();
                    ListMenu();
                    break;
            }
        }

        public void CreateMenu()
        {
            Console.Clear();
            Console.WriteLine("*** Create Region ***");
            Console.Write("Region Name : ");
            string regionName = Console.ReadLine();

            int affectedRows = _region.Create(regionName);

            if (affectedRows > 0)
            {
                _generalView.SuccessMessage("Successfull created region!!!");
                Console.ReadKey();

                ListMenu();
            }
            else
            {
                _generalView.ErrorMessage("Failed to created region!!!");
                Console.ReadKey();

                ListMenu();
            }
        }

        public void SearchMenu()
        {
            Console.Clear();
            Console.WriteLine("*** Search Region By Id ***");
            Console.Write("Enter region id : ");

            int regionId = default;

            try
            {
                regionId = int.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                _generalView.ErrorMessage("invalid region id input!!!");
                Console.ReadKey();
                SearchMenu();
            }

            Region region = _region.FindById(regionId);

            if (region.Id == null)
            {
                _generalView.ErrorMessage("region is not found!!!");
                Console.ReadKey();
                ListMenu();
            }

            _regionView.GetById(region);

            Console.ReadKey();
            ListMenu();
        }

        public void EditMenu()
        {
            Console.Clear();
            Console.WriteLine("*** Edit Region ***");
            Console.Write("Enter region id : ");

            int regionId = default;

            try
            {
                regionId = int.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                _generalView.ErrorMessage("invalid region id input!!!");
                Console.ReadKey();
                ListMenu();
            }

            Console.Clear();
            Console.WriteLine("*** Edit Region ***");
            Console.Write("Region name : ");
            string regionName = Console.ReadLine();

            int affectedRows = _region.Update(regionId, regionName);

            if (affectedRows > 0)
            {
                Console.WriteLine("Successfull updated region!!!");
                Console.ReadKey();
                ListMenu();
            }
            else
            {
                Console.WriteLine("Failed to updated region!!!");
                Console.ReadKey();
                ListMenu();
            }
        }

        public void DeleteMenu()
        {
            Console.Clear();
            Console.WriteLine("*** Delete Region ***");
            Console.Write("Enter region id : ");

            int regionId = default;

            try
            {
                regionId = int.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine("invalid region id input!!!");
                Console.ReadKey();
                ListMenu();
            }

            int affectedRows = _region.Delete(regionId);

            if (affectedRows > 0)
            {
                Console.WriteLine("Successfull deleted region!!!");
                Console.ReadKey();
                ListMenu();
            }
            else
            {
                Console.WriteLine("Failed to deleted region!!!");
                Console.ReadKey();
                ListMenu();
            }
        }
    }
}
