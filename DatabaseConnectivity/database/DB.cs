using System.Data.SqlClient;

namespace DatabaseConnectivity.database
{

    class DB
    {
        private string connectionString = "Data Source=FEBRIANTO-PC;Database=db_hr;Integrated Security=True;Connect Timeout=30;Encrypt=False;";

        public SqlConnection Connection()
        {

            return new SqlConnection(connectionString);
        }
    }
}
