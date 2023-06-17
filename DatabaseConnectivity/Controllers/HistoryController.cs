using DatabaseConnectivity.Models;
using DatabaseConnectivity.views;

namespace DatabaseConnectivity.Controllers
{

    class HistoryController
    {
        private History _history = new History();
        private HistoryView _historyView = new HistoryView();

        public void ListMenu()
        {
            Console.Clear();
            Console.WriteLine("Loading...");

            List<History> histories = _history.FindAll();
            _historyView.GetAll(histories);

            Console.WriteLine("\nPress any key for back!");
            Console.ReadLine();
            new MainController().Menu();
        }
    }
}
