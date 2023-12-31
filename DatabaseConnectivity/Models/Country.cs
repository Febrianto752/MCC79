﻿using DatabaseConnectivity.database;
using System.Data;
using System.Data.SqlClient;

namespace DatabaseConnectivity.Models
{
    class Country
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int RegionId { get; set; }

        public Country() { }

        public List<Country> FindAll()
        {
            SqlConnection connection = new DB().Connection();
            connection.Open();
            List<Country> countries = new List<Country>();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;

                command.CommandText = "SELECT * FROM tb_m_countries";

                using SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var country = new Country();
                        country.Id = reader.GetString(0);
                        country.Name = reader.GetString(1);
                        country.RegionId = reader.GetInt32(2);

                        countries.Add(country);
                    }
                }

                reader.Close();
            }

            catch (Exception ex)
            {
                connection.Close();
                return countries;
            }
            connection.Close();
            return countries;
        }

        public Country FindCountryById(string id)
        {
            SqlConnection connection = new DB().Connection();
            connection.Open();
            Country country = new Country();

            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM tb_m_countries WHERE id = (@country_id)";

                // membuat parameter
                SqlParameter pCountryId = new SqlParameter();
                pCountryId.ParameterName = "@country_id";
                pCountryId.Value = id;
                pCountryId.SqlDbType = SqlDbType.Char;

                // menambahkan parameter ke command
                command.Parameters.Add(pCountryId);

                // Menalankan command
                using SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        country.Id = reader.GetString(0);
                        country.Name = reader.GetString(1);
                        country.RegionId = reader.GetInt32(2);
                    }
                }

                reader.Close();
            }

            catch (Exception ex)
            {
                connection.Close();
                return country;
            }
            connection.Close();
            return country;
        }

        public int Create(string id, string name, int regionId)
        {
            int result = 0;
            SqlConnection connection = new DB().Connection();
            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "INSERT INTO tb_m_countries (id, name, region_id) VALUES ((@country_id) , (@country_name) , (@region_id))";

                command.Transaction = transaction;

                // membuat parameter
                SqlParameter pCountryId = new SqlParameter();
                pCountryId.ParameterName = "@country_id";
                pCountryId.Value = id;
                pCountryId.SqlDbType = SqlDbType.VarChar;

                // menambahkan parameter ke command
                command.Parameters.Add(pCountryId);

                // membuat parameter
                SqlParameter pCountryName = new SqlParameter();
                pCountryName.ParameterName = "@country_name";
                pCountryName.Value = name;
                pCountryName.SqlDbType = SqlDbType.VarChar;

                // menambahkan parameter ke command
                command.Parameters.Add(pCountryName);

                // membuat parameter
                SqlParameter pRegionIdCountry = new SqlParameter();
                pRegionIdCountry.ParameterName = "@region_id";
                pRegionIdCountry.Value = regionId;
                pRegionIdCountry.SqlDbType = SqlDbType.Int;

                // menambahkan parameter ke command
                command.Parameters.Add(pRegionIdCountry);

                // Menalankan command
                result = command.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                try
                {
                    transaction.Rollback();
                    return 0;
                }
                catch (Exception rollback)
                {
                    return 0;
                }
            }

            connection.Close();
            return result;
        }

        public int Update(string id, string name, int regionId)
        {
            int result;
            SqlConnection connection = new DB().Connection();
            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "Update tb_m_countries set name=(@country_name), region_id=(@region_id) WHERE id=(@country_id)";
                command.Transaction = transaction;

                // membuat parameter
                SqlParameter pRegionName = new SqlParameter();
                pRegionName.ParameterName = "@country_name";
                pRegionName.Value = name;
                pRegionName.SqlDbType = SqlDbType.VarChar;

                // menambahkan parameter ke command
                command.Parameters.Add(pRegionName);

                // membuat parameter
                SqlParameter pRegionId = new SqlParameter();
                pRegionId.ParameterName = "@region_id";
                pRegionId.Value = regionId;
                pRegionId.SqlDbType = SqlDbType.Int;

                // menambahkan parameter ke command
                command.Parameters.Add(pRegionId);

                // membuat parameter
                SqlParameter pCountryId = new SqlParameter();
                pCountryId.ParameterName = "@country_id";
                pCountryId.Value = id;
                pCountryId.SqlDbType = SqlDbType.VarChar;

                // menambahkan parameter ke command
                command.Parameters.Add(pCountryId);

                // Menalankan command
                result = command.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                try
                {
                    transaction.Rollback();
                    return 0;
                }
                catch (Exception rollback)
                {
                    return 0;
                }
            }

            connection.Close();
            return result;
        }

        public int Delete(string id)
        {
            int result = 0;
            SqlConnection connection = new DB().Connection();
            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "Delete FROM tb_m_countries WHERE id=(@country_id)";
                command.Transaction = transaction;

                // membuat parameter
                SqlParameter pCountryId = new SqlParameter();
                pCountryId.ParameterName = "@country_id";
                pCountryId.Value = id;
                pCountryId.SqlDbType = SqlDbType.VarChar;

                // menambahkan parameter ke command
                command.Parameters.Add(pCountryId);

                // Menalankan command
                result = command.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                try
                {
                    transaction.Rollback();
                    return 0;
                }
                catch (Exception rollback)
                {
                    return 0;
                }
            }

            connection.Close();
            return result;
        }
    }
}
