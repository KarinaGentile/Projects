using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Park
    {

        //Declaring Park Class Properties

        public int ParkID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime EstablishDate { get; set; }
        public string EstablishDateString { get { return EstablishDate.ToShortDateString(); } }
        public int Area { get; set; }
        public int Visitors { get; set; }
        public string Description { get; set; }

        //Setting properties to variables in the constructor

        public Park(int parkId, string name, string location, DateTime establishDate, int area, int visitors, string description)
        {

            ParkID = parkId;
            Name = name;
            Location = location;
            EstablishDate = establishDate;
            Area = area;
            Visitors = visitors;
            Description = description;

        }

    }
}
