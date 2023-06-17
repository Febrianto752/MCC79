using DatabaseConnectivity.ModelView;

namespace DatabaseConnectivity.Controllers
{
    class MainController
    {
        public void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("*** Main Menu ***");
            Console.WriteLine("1. Get all regions");
            Console.WriteLine("2. Get all countries");
            Console.WriteLine("3. Get all locations");
            Console.WriteLine("4. Get all departments");
            Console.WriteLine("5. Get all employees");
            Console.WriteLine("6. Get all jobs");
            Console.WriteLine("7. Get all histories");
            Console.WriteLine("8. Linq");
            Console.WriteLine("9. Exit");
            Console.WriteLine("******************");
            Console.Write("pilihan : ");

            int pilihan = default;

            try
            {
                pilihan = int.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid choice input!!!");
                Console.ReadKey();
                MainMenu();
            }

            switch (pilihan)
            {
                case 1:
                    new RegionController().ListMenu();
                    break;
                case 2:
                    new CountryController().ListMenu();
                    break;
                case 3:
                    new LocationController().ListMenu();
                    break;
                case 4:
                    new DepartmentController().ListMenu();
                    break;
                case 5:
                    new EmployeeController().ListMenu();
                    break;
                case 6:
                    new JobController().ListMenu();
                    break;
                case 7:
                    new HistoryController().ListMenu();
                    break;
                case 8:
                    new LinqMV().TaskMenu();
                    break;
                case 9:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice input!!!");
                    Console.ReadKey();
                    MainMenu();
                    break;
            }
        }
    }
}
