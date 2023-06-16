using DatabaseConnectivity.database;
using System.Data.SqlClient;

namespace DatabaseConnectivity.Models
{
    class Department
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? LocationId { get; set; }
        public int? ManagerId { get; set; }

        public Department() { }

        public List<Department> FindAll()
        {
            SqlConnection connection = new DB().Connection();
            connection.Open();
            List<Department> departments = new List<Department>();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;

                command.CommandText = "SELECT * FROM tb_m_departments";

                using SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var department = new Department();

                        department.Id = reader.GetInt32(0);
                        department.Name = reader.IsDBNull(1) ? null : reader.GetString(1);
                        department.LocationId = reader.IsDBNull(1) ? null : reader.GetInt32(2);
                        department.ManagerId = reader.IsDBNull(1) ? null : reader.GetInt32(3);

                        departments.Add(department);
                    }
                }

                reader.Close();
            }

            catch (Exception ex)
            {
                connection.Close();
                return departments;
            }
            connection.Close();
            return departments;
        }
    }
}
