using DatabaseConnectivity.database;
using System.Data.SqlClient;

namespace DatabaseConnectivity.models
{
    class Employee
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? HireDate { get; set; }
        public int Salary { get; set; }
        public decimal comissionPct { get; set; }
        public int ManagerId { get; set; }
        public string? JobId { get; set; }
        public int DepartmentId { get; set; }

        public Employee() { }

        public static List<Employee> FindAllEmployee()
        {
            SqlConnection connection = new DB().Connection();
            connection.Open();
            List<Employee> employees = new List<Employee>();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM tb_m_employees";

                using SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var employee = new Employee();
                        employee.Id = reader.GetInt32(0);
                        employee.FirstName = reader.GetString(1);
                        employee.LastName = reader.GetString(2);
                        employee.Email = reader.GetString(3);
                        employee.PhoneNumber = reader.GetString(4);
                        employee.HireDate = reader.GetDateTime(5);
                        employee.Salary = reader.GetInt32(6);
                        employee.comissionPct = reader.GetDecimal(7);
                        employee.ManagerId = reader.IsDBNull(8) ? 0 : reader.GetInt32(8);
                        employee.JobId = reader.GetString(9);
                        employee.DepartmentId = reader.GetInt32(10);

                        employees.Add(employee);
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
            return employees;
        }
    }
}
