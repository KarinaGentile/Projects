using Capstone.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Capstone.DAL
{
    public class CampgroundDAL : ICampgroundDAO
    {
        //Declaring the connection string and SQL query for later use
        private const string getCampgrounds = @"SELECT * FROM campground WHERE park_id = @parkID ORDER BY name;";
        private string ConnectionString;

        //setting connnection string in the constructor
        public CampgroundDAL(string connectionString)
        {
            ConnectionString = connectionString;
        }

        //Method return the fee needed to display to the user for the cost of their stay
        public decimal GetDayFee(int campchoice)
        {
            decimal fee = 0m;
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string sql = "select daily_fee from campground where campground_id = @campchoice";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@campchoice", campchoice);
                SqlDataReader rdr = cmd.ExecuteReader();

                

                if (rdr.Read())
                {
                    fee = Convert.ToDecimal(rdr["daily_fee"]);
                }
            }
            return fee;
        }

        //Returns the campgrounds for use with the menu system
        public List<Campground> GetCampground(int parkId)
        {
            List<Campground> campgrounds = new List<Campground>();

            try
            {

                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(getCampgrounds, conn);
                    cmd.Parameters.AddWithValue("@parkID", parkId);
                    SqlDataReader rdr = cmd.ExecuteReader();

                    int counter = 1;

                    while (rdr.Read())
                    {
                        Campground campground = new Campground(Convert.ToInt32(rdr["campground_id"]), Convert.ToInt32(rdr["Park_Id"]), Convert.ToString(rdr["name"]), Convert.ToInt32(rdr["open_from_mm"]), Convert.ToInt32(rdr["open_to_mm"]), Convert.ToDecimal(rdr["daily_fee"]));
                        campgrounds.Add(campground);
                        counter++;
                    }
                }

            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return campgrounds;
        }

    }
}
