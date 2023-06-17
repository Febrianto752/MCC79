using DatabaseConnectivity.Models;

namespace DatabaseConnectivity.views
{
    class HistoryView
    {

        public void GetAll(List<History> histories)
        {

            Console.Clear();

            Console.WriteLine("*** History List ***\n");

            if (histories.Count > 0)
            {
                foreach (var history in histories)
                {
                    Console.WriteLine("===========================");
                    Console.WriteLine("Start Date   : {0}", history.StartDate);
                    Console.WriteLine("Employee ID  : {0}", history.EmployeeId);
                    Console.WriteLine("End Date     : {0}", history.EndDate);
                    Console.WriteLine("Job ID       : {0}", history.JobId);
                    Console.WriteLine("===========================");
                }
            }
            else
            {
                Console.WriteLine("History data is empty!!!");
            }

        }
    }
}
