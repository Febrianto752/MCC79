using DatabaseConnectivity.Models;
using DatabaseConnectivity.views;

namespace DatabaseConnectivity.Controllers
{

    class EmployeeController
    {
        private Employee _employee = new Employee();
        private EmployeeView _employeeView = new EmployeeView();
        public void ListMenu()
        {
            Console.Clear();
            Console.WriteLine("Loading...");

            List<Employee> employees = _employee.FindAll();
            _employeeView.GetAll(employees);

            Console.WriteLine("\nPress any key for back!");
            Console.ReadLine();
            new MainController().Menu();
        }
    }
}
