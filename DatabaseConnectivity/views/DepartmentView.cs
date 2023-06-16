using DatabaseConnectivity.Models;

namespace DatabaseConnectivity.views
{
    class DepartmentView
    {
        public void GetAll(List<Department> departments)
        {

            Console.Clear();

            Console.WriteLine("*** Department List ***\n");

            foreach (var deparment in departments)
            {
                Console.WriteLine("===========================");
                Console.WriteLine("ID deparment    : {0}", deparment.Id);
                Console.WriteLine("Name            : {0}", deparment.Name);
                Console.WriteLine("Location ID     : {0}", deparment.LocationId);
                Console.WriteLine("Manager ID      : {0}", deparment.ManagerId);
                Console.WriteLine("===========================");
            }





        }
    }
}
