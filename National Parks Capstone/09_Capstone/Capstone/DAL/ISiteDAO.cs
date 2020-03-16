using Capstone.Classes;
using System;
using System.Collections.Generic;

namespace Capstone.DAL
{
    public interface ISiteDAO
    {
        //Declaring the interface for use with SiteDAL
        List<Site> GetAvailableSites(int campgroundId, DateTime fromDate, DateTime toDate);
    }
}