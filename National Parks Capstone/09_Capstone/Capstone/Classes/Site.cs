using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Site
    {

        //Declaring Site Class Properties

        public int SiteId { get; set; }
        public string CampgroundName { get; set; }
        public int SiteNumber { get; set; }
        public int MaxOccupancy { get; set; }
        public bool Accessible { get; set; }
        public int MaxRVLength { get; set; }
        public bool Utilities { get; set; }
        public int CampgroundId { get; set; }

        //Setting properties to variables in the constructor

        public Site(int siteId, string campgroundName, int siteNumber, int maxOccupancy, int maxRVLength, int accessible, int utilities, int campgroundId)
        {

            SiteId = siteId;
            CampgroundName = campgroundName;
            SiteNumber = siteNumber;
            CampgroundId = campgroundId;
            MaxOccupancy = maxOccupancy;
            MaxRVLength = maxRVLength;
            
            //While not strictly necessary to do it this way, created if statements to convert bool into a 1 or 0 for the bit properties in the DB
            if (accessible == 1)
            {
                this.Accessible = true;
            }
            else
            {
                this.Accessible = false;
            }

            if (utilities == 1)
            {
                this.Utilities = true;
            }
            else
            {
                this.Utilities = false;
            }

        }

    }
}
