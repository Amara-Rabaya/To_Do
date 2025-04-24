using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Tranning_pro.Models;

namespace Tranning_pro.Repositories
{
    public class CityRepository
    {
        private string connectionString;

        public CityRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public List<City> GetAll()
        {
            List<City> cities = new List<City>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetAllCities", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cities.Add(new City
                    {
                        cityName = reader["cityName"].ToString(),
                        governorate = reader["governorate"].ToString(),
                        country = reader["country"].ToString(),
                        cityRank = reader["cityRank"] != DBNull.Value ? Convert.ToInt32(reader["cityRank"]) : 0,
                        populations = reader["populations"] != DBNull.Value ? Convert.ToInt32(reader["populations"]) : 0
                    });
                }
            }

            return cities;
        }

        public void Insert(City city)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("insretCity", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cityID", city.cityID);
                cmd.Parameters.AddWithValue("@cityName", city.cityName);
                cmd.Parameters.AddWithValue("@governorate", city.governorate ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@country", city.country ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@cityRank", city.cityRank);
                cmd.Parameters.AddWithValue("@populations", city.populations);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
