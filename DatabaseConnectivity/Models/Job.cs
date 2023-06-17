using DatabaseConnectivity.database;
using System.Data.SqlClient;

namespace DatabaseConnectivity.Models
{
    class Job
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public int MinSalary { get; set; }
        public int MaxSalary { get; set; }

        public List<Job> FindAll()
        {
            SqlConnection connection = new DB().Connection();
            connection.Open();
            List<Job> jobs = new List<Job>();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM tb_m_jobs";

                using SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var job = new Job();
                        job.Id = reader.GetString(0);
                        job.Title = reader.GetString(1);
                        job.MinSalary = reader.GetInt32(2);
                        job.MaxSalary = reader.GetInt32(3);

                        jobs.Add(job);
                    }
                }

                reader.Close();
            }

            catch (Exception ex)
            {
                connection.Close();
                return jobs;
            }
            connection.Close();
            return jobs;
        }
    }
}
