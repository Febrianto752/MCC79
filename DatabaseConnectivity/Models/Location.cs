using DatabaseConnectivity.database;
using System.Data.SqlClient;

namespace DatabaseConnectivity.Models
{
    class Location
    {
        public int Id { get; set; }
        public string? StreetAddress { get; set; }
        public string? PostalCode { get; set; }
        public string? City { get; set; }
        public string? StateProvince { get; set; }
        public string? CountryId { get; set; }

        public List<Location> FindAll()
        {
            SqlConnection connection = new DB().Connection();
            connection.Open();
            List<Location> locations = new List<Location>();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM tb_m_locations";

                using SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var location = new Location();
                        location.Id = reader.GetInt32(0);
                        location.StreetAddress = reader.IsDBNull(1) ? null : reader.GetString(1);
                        location.PostalCode = reader.IsDBNull(2) ? null : reader.GetString(2);
                        location.City = reader.IsDBNull(3) ? null : reader.GetString(3);
                        location.StateProvince = reader.IsDBNull(4) ? null : reader.GetString(4);
                        location.CountryId = reader.IsDBNull(5) ? null : reader.GetString(5);

                        locations.Add(location);
                    }
                }

                reader.Close();
            }

            catch (Exception ex)
            {
                connection.Close();
                return locations;
            }
            connection.Close();
            return locations;
        }

    }
}
