using DatabaseConnectivity.Models;

namespace DatabaseConnectivity.views
{
    class JobView
    {
        public void GetAll(List<Job> jobs)
        {

            Console.Clear();

            Console.WriteLine("*** Country List ***\n");

            if (jobs.Count > 0)
            {
                foreach (var job in jobs)
                {
                    Console.WriteLine("===========================");
                    Console.WriteLine("ID job      : {0}", job.Id);
                    Console.WriteLine("Title       : {0}", job.Title);
                    Console.WriteLine("Min Salary  : {0}", job.MinSalary);
                    Console.WriteLine("Max Salary  : {0}", job.MaxSalary);
                    Console.WriteLine("===========================");
                }
            }
            else
            {
                Console.WriteLine("Job data is empty!!!");
            }
        }

    }
}
