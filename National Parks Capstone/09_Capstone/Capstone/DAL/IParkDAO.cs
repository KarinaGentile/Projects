using Capstone.Classes;
using System.Collections.Generic;

namespace Capstone.DAL
{
    public interface IParkDAO
    {
        //Declaring the interface for use with ParkDAL
        List<Park> GetParks();
    }
}