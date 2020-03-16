using Capstone.Classes;
using System;
using System.Collections.Generic;

namespace Capstone.DAL
{
    public interface IReservationDAL
    {
        //Declaring the interface for use with ReservationDAL
        List<Reservation> GetReservation(int siteId);
        int MakeReservation(int campgroundId, int siteNumPick, string reservationName, DateTime fromDate, DateTime toDate);

    }
}