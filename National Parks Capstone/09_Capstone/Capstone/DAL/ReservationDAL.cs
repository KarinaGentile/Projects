using Capstone.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Capstone.DAL
{
    public class ReservationDAL : IReservationDAL
    {
        //Declaring SQL queries and connection string for later use
        private const string getReservation = @"SELECT * FROM reservation WHERE site_id = @siteID";
        private const string makeReservation = @"INSERT INTO reservation (site_id, name, from_date, to_date, create_date) VALUES ((Select site_id from site where campground_id = @campgroundId and site_number = @sitenumber) , @reservationName, @arriveDate, @departDate, GETDATE()); SELECT CAST(SCOPE_IDENTITY() as int)";
        private string ConnectionString;

        //Setting connection string in the constructor
        public ReservationDAL(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        //Method returns reservations for later use with the menu system
        public List<Reservation> GetReservation(int siteId)
        {

            List<Reservation> reservations = new List<Reservation>();

            try
            {

                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(getReservation, conn);
                    cmd.Parameters.AddWithValue("@site-id", siteId);
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        Reservation reservation = new Reservation(Convert.ToInt32(rdr["reservation_id"]), Convert.ToInt32(rdr["site_id"]), Convert.ToString(rdr["name"]), Convert.ToDateTime(rdr["from_date"]), Convert.ToDateTime(rdr["to_date"]), Convert.ToDateTime(rdr["create_date"]));
                        reservations.Add(reservation);
                    }
                }

            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return reservations;

        }

        //Method creates reserveration for the user
        public int MakeReservation(int campgroundId, int siteNumPick, string reservationName, DateTime fromDate, DateTime toDate)
        {
            int reservationId = 0;

            try
            {

                using (SqlConnection connect = new SqlConnection(ConnectionString))
                {
                    connect.Open();

                    SqlCommand cmd = new SqlCommand(makeReservation, connect);
                    cmd.Parameters.AddWithValue("@sitenumber", siteNumPick);
                    cmd.Parameters.AddWithValue("@reservationName", reservationName);
                    cmd.Parameters.AddWithValue("@arriveDate", fromDate);
                    cmd.Parameters.AddWithValue("@departDate", toDate);
                    cmd.Parameters.AddWithValue("@campgroundId", campgroundId);
                    reservationId = (int)cmd.ExecuteScalar();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return reservationId;
        }

    }
}
