﻿using DatabaseConnectivity.database;
using System.Data;
using System.Data.SqlClient;

namespace DatabaseConnectivity.Models
{
    class Region
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public Region() { }

        public List<Region> FindAll()
        {
            SqlConnection connection = new DB().Connection();
            connection.Open();
            List<Region> regions = new List<Region>();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM tb_m_regions";

                using SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var region = new Region();
                        region.Id = reader.GetInt32(0);
                        region.Name = reader.GetString(1);

                        regions.Add(region);
                    }
                }

                reader.Close();
            }

            catch (Exception ex)
            {
                return regions;
            }
            connection.Close();
            return regions;
        }

        public Region FindById(int id)
        {
            SqlConnection connection = new DB().Connection();
            connection.Open();
            Region region = new Region();

            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM tb_m_regions WHERE id = (@region_id)";

                // membuat parameter
                SqlParameter pRegionId = new SqlParameter();
                pRegionId.ParameterName = "@region_id";
                pRegionId.Value = id;
                pRegionId.SqlDbType = SqlDbType.Int;

                // menambahkan parameter ke command
                command.Parameters.Add(pRegionId);

                // Menalankan command
                using SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        region.Id = reader.GetInt32(0);
                        region.Name = reader.GetString(1);
                    }
                }


                reader.Close();
            }

            catch (Exception ex)
            {
                connection.Close();
                return region;
            }
            connection.Close();
            return region;
        }

        public int Create(string name)
        {
            int result;
            SqlConnection connection = new DB().Connection();
            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "INSERT INTO tb_m_regions VALUES ((@region_name))";
                command.Transaction = transaction;

                // membuat parameter
                SqlParameter pRegionName = new SqlParameter();
                pRegionName.ParameterName = "@region_name";
                pRegionName.Value = name;
                pRegionName.SqlDbType = SqlDbType.VarChar;

                // menambahkan parameter ke command
                command.Parameters.Add(pRegionName);

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

        public int Update(int id, string name)
        {
            int result = 0;
            SqlConnection connection = new DB().Connection();
            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "Update tb_m_regions set name=(@region_name) WHERE id=(@region_id)";
                command.Transaction = transaction;

                // membuat parameter
                SqlParameter pRegionName = new SqlParameter();
                pRegionName.ParameterName = "@region_name";
                pRegionName.Value = name;
                pRegionName.SqlDbType = SqlDbType.VarChar;

                // menambahkan parameter ke command
                command.Parameters.Add(pRegionName);

                // membuat parameter
                SqlParameter pRegionId = new SqlParameter();
                pRegionId.ParameterName = "@region_id";
                pRegionId.Value = id;
                pRegionId.SqlDbType = SqlDbType.Int;

                // menambahkan parameter ke command
                command.Parameters.Add(pRegionId);

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

        public int Delete(int id)
        {
            int result = 0;
            SqlConnection connection = new DB().Connection();
            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "Delete FROM tb_m_regions WHERE id=(@region_id)";
                command.Transaction = transaction;

                // membuat parameter
                SqlParameter pRegionId = new SqlParameter();
                pRegionId.ParameterName = "@region_id";
                pRegionId.Value = id;
                pRegionId.SqlDbType = SqlDbType.Int;

                // menambahkan parameter ke command
                command.Parameters.Add(pRegionId);

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
