using DatabaseConnectivity.Models;
using DatabaseConnectivity.views;

namespace DatabaseConnectivity.Controllers
{
    class JobController
    {
        private Job _job = new Job();
        private JobView _jobView = new JobView();
        public void ListMenu()
        {
            Console.Clear();
            Console.WriteLine("Loading...");

            List<Job> jobs = _job.FindAll();
            _jobView.GetAll(jobs);

            Console.WriteLine("\nPress any key for back!");
            Console.ReadLine();
            new MainController().Menu();
        }
    }
}
