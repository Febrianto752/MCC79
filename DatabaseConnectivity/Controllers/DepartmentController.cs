using DatabaseConnectivity.Models;
using DatabaseConnectivity.views;

namespace DatabaseConnectivity.Controllers
{
    class DepartmentController
    {
        private Department _department = new Department();
        private DepartmentView _departmentView = new DepartmentView();
        public void ListMenu()
        {
            Console.Clear();
            Console.WriteLine("Loading...");

            List<Department> departments = _department.FindAll();
            _departmentView.GetAll(departments);

            Console.WriteLine("\nPress any key for back!");
            Console.ReadLine();
            new MainController().Menu();
        }
    }
}
