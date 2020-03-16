using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Reservation
    {

        //Declaring Reservation Class Properties

        public int ReservationId { get; set; }
        public int SiteId { get; set; }
        public string Name { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public DateTime CreateDate { get; set; }

        //Setting Properties to variables in the construtor

        public Reservation(int reservationId, int siteId, string name, DateTime fromDate, DateTime toDate, DateTime createDate)
        {

            ReservationId = reservationId;
            SiteId = siteId;
            Name = name;
            FromDate = fromDate;
            ToDate = toDate;
            CreateDate = createDate;

        }

    }
}
