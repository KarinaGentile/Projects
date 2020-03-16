using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Campground
    {

        //Declaring Campground Class Properties

        public int CampgroundId { get; set; }
        public int ParkId { get; set; }
        public string Name { get; set; }
        public int OpenFromM { get; set; }
        public int OpenToM { get; set; }
        public decimal DailyFee { get; set; }


        //Setting Properties to variables in the constructor
        public Campground(int campgroundId, int parkId, string name, int openFromM, int openToM, decimal dailyFee)
        {

            CampgroundId = campgroundId;
            ParkId = parkId;
            Name = name;
            OpenFromM = openFromM;
            OpenToM = openToM;
            DailyFee = dailyFee;

        }

    }
}
