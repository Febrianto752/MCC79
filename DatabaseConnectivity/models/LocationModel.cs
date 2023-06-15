using DatabaseConnectivity.database;
using DatabaseConnectivity.objects;
using System.Data.SqlClient;

namespace DatabaseConnectivity.models
{
    class LocationModel
    {
        public static List<Location> FindAllLocation()
        {
            SqlConnection connection = DB.Connection();
            List<Location> locations = new List<Location>();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT l.id, l.street_address, l.postal_code , l.city, l.state_province, c.name AS country, r.name AS region FROM tb_m_locations l JOIN  tb_m_countries c ON l.country_id = c.id JOIN tb_m_regions r ON c.region_id = r.id";

                connection.Open();

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
                        string countryName = reader.IsDBNull(5) ? null : reader.GetString(5);
                        string regionName = reader.IsDBNull(6) ? null : reader.GetString(6);

                        Country country = new Country();
                        country.Name = countryName;

                        Region region = new Region();
                        region.Name = regionName;

                        country.Region = region;

                        location.Country = country;

                        locations.Add(location);
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
            return locations;
        }
    }
}
