using Capstone.Classes;
using Capstone.DAL;
using Capstone.Views;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;

namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get the connection string from the appsettings.json file
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            string connectionString = configuration.GetConnectionString("Project");

            /********************************************************************
            // If you do not want to use CLIMenu, you can remove the following
            *********************************************************************/
            // Create any DAOs needed here, and then pass them into main menu...
            ParkDAL parkDal = new ParkDAL(connectionString);
            CampgroundDAL campDal = new CampgroundDAL(connectionString);
            SiteDAL siteDal = new SiteDAL(connectionString);
            ReservationDAL reservationDAL = new ReservationDAL(connectionString);






            MainMenu mainMenu = new MainMenu(parkDal, campDal, siteDal, reservationDAL);  // You'll probably be adding daos to the constructor

            //Run the menu.
            mainMenu.Run();


        }
    }
}
