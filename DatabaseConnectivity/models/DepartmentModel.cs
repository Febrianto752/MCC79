using DatabaseConnectivity.database;
using DatabaseConnectivity.objects;
using System.Data.SqlClient;

namespace DatabaseConnectivity.models
{
    class DepartmentModel
    {
        public static List<Department> FindAllDepartment()
        {
            SqlConnection connection = DB.Connection();
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
                else
                {
                    Console.WriteLine("Data not found!");
                }

                reader.Close();
            }

            catch (Exception ex)
            {
                Console.WriteLine("something error");
                Console.WriteLine(ex.Message);
            }
            connection.Close();
            return departments;
        }
    }
}
