using Capstone.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Capstone.DAL
{
    public class SiteDAL : ISiteDAO
    {

        //Declaring SQL query and connection string for later use
        public const string getSites = @"SELECT DISTINCT TOP 5 * FROM campground 
        JOIN site ON campground.campground_id = site.campground_id 
        WHERE campground.campground_id = @CampgroundId AND 
        (campground.open_from_mm <= @OpenFromM AND campground.open_to_mm >= @OpenToM)
        AND site.site_id NOT IN ( SELECT site.site_id FROM campground 
        JOIN site ON campground.campground_id = site.campground_id 
        LEFT JOIN reservation ON site.site_id = 
        reservation.site_id WHERE campground.campground_id = @CampgroundId 
        AND NOT (reservation.to_date <= @FromDate OR 
        reservation.from_date >= @ToDate OR reservation.from_date IS NULL))";

        private string ConnectionString;

        //Setting connection string in the constructor
        public SiteDAL(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        //Returns availibable sites for later use in the menu system
        public List<Site> GetAvailableSites(int campgroundId, DateTime fromDate, DateTime toDate)
        {
            List<Site> availableSites = new List<Site>();

            try
            {

                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(getSites, conn);
                    cmd.Parameters.AddWithValue("@CampgroundId", campgroundId);
                    cmd.Parameters.AddWithValue("@FromDate", fromDate);
                    cmd.Parameters.AddWithValue("@ToDate", toDate);
                    cmd.Parameters.AddWithValue("@OpenFromM", fromDate.Month);
                    cmd.Parameters.AddWithValue("@OpenToM", toDate.Month);
                    SqlDataReader result = cmd.ExecuteReader();

                    while (result.Read())
                    {
                        Site availableSite = new Site(Convert.ToInt32(result["site_id"]), Convert.ToString(result["name"]), Convert.ToInt32(result["site_number"]), Convert.ToInt32(result["max_occupancy"]), Convert.ToInt32(result["accessible"]), Convert.ToInt32(result["max_rv_length"]), Convert.ToInt32(result["utilities"]), Convert.ToInt32(result["campground_id"]));
                        availableSites.Add(availableSite);
                    }
                }

            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return availableSites;
        }

    }
}
