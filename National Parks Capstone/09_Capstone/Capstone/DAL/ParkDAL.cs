using Capstone.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Capstone.DAL
{
    public class ParkDAL : IParkDAO
    {
        //Declaring the SQL query and connection string for later use
        private const string getParks = "SELECT * FROM park ORDER BY name";
        private string ConnectionString;

        //Setting ConnectionString in the constructor
        public ParkDAL(string connectionString)
        {
            ConnectionString = connectionString;
        }

        //Method returns all parks for later use in the menu system
        public List<Park> GetParks()
        {
            List<Park> parks = new List<Park>();

            try
            {

                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(getParks, conn);
                    SqlDataReader rdr = cmd.ExecuteReader();

                    int counter = 1;

                    while (rdr.Read())
                    {
                        Park park = new Park(Convert.ToInt32(rdr["Park_Id"]), Convert.ToString(rdr["name"]), Convert.ToString(rdr["location"]), Convert.ToDateTime(rdr["establish_date"]), Convert.ToInt32(rdr["area"]), Convert.ToInt32(rdr["visitors"]), Convert.ToString(rdr["description"]));
                        parks.Add(park);
                        counter++;
                    }
                }

            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return parks;
        }

    }
}
