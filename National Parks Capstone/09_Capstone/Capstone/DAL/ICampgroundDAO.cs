using Capstone.Classes;
using System.Collections.Generic;

namespace Capstone.DAL
{

    //Declaring the Interface for use with CampgroundDAL
    public interface ICampgroundDAO
    {
        List<Campground> GetCampground(int parkId);

        decimal GetDayFee(int campchoice);
    }
}