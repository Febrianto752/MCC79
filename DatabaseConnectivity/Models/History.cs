using DatabaseConnectivity.database;
using System.Data.SqlClient;

namespace DatabaseConnectivity.Models
{
    class History
    {
        public DateTime? StartDate { get; set; }
        public int EmployeeId { get; set; }
        public DateTime? EndDate { get; set; }
        public int DepartMentId { get; set; }
        public string JobId { get; set; }

        public List<History> FindAll()
        {
            SqlConnection connection = new DB().Connection();
            connection.Open();
            List<History> histories = new List<History>();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM tb_tr_histories";

                using SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var history = new History();
                        history.StartDate = reader.GetDateTime(0);
                        history.EmployeeId = reader.GetInt32(1);
                        history.EndDate = reader.IsDBNull(2) ? null : reader.GetDateTime(2);
                        history.DepartMentId = reader.GetInt32(3);
                        history.JobId = reader.GetString(4);

                        histories.Add(history);
                    }
                }

                reader.Close();
            }

            catch (Exception ex)
            {
                connection.Close();
                return histories;
            }
            connection.Close();
            return histories;
        }
    }
}
