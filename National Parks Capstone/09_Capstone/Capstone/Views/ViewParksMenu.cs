using Capstone.Classes;
using Capstone.DAL;
using System;
using System.Collections.Generic;
using System.IO;

namespace Capstone.Views
{
    /// <summary>
    /// The top-level menu in our Market Application
    /// </summary>
    public class ViewParksMenu : CLIMenu
    {
        // Store any private variables, including DAOs here....
        public string ConnectionString;
        private IParkDAO ParkDAO;
        private ICampgroundDAO CampDAO;
        private ISiteDAO SiteDAO;
        private IReservationDAL ReservationDAL;
        //private Campground Camp;
        //private Park Park;
        /// <summary>
        /// Constructor adds items to the top-level menu
        /// </summary>
        public ViewParksMenu(IParkDAO parkDao, ICampgroundDAO campDAO, ISiteDAO siteDAO, IReservationDAL reservationDAL) :
            base("ViewParksMenu")
        {

            ParkDAO = parkDao;
            CampDAO = campDAO;
            SiteDAO = siteDAO;
            ReservationDAL = reservationDAL;
        }

       

        protected override void SetMenuOptions()
        {
            List<Park> parks = ParkDAO.GetParks();

            foreach (Park park in parks)
            {
                menuOptions.Add(park.ParkID.ToString(), park.Name);
            }

            this.menuOptions.Add("B", "Back to Main Menu");
            this.quitKey = "B";
        }

        /// <summary>
        /// The override of ExecuteSelection handles whatever selection was made by the user.
        /// This is where any business logic is executed.
        /// </summary>
        /// <param name="choice">"Key" of the user's menu selection</param>
        /// <returns></returns>
        protected override bool ExecuteSelection(string choice)
        {
            List<Park> parks = ParkDAO.GetParks();
            //locate park that matches id typed
            int chosen = Convert.ToInt32(choice);
            Park chosenPark = null;
            foreach (Park park in parks)
            {
                if (chosen == park.ParkID)
                {
                    chosenPark = park;
                    break;
                }
            }
            ParkInfoMenu pif = new ParkInfoMenu(chosen, CampDAO, ParkDAO, SiteDAO, ReservationDAL);
            pif.Run();

            return true;

        }

        protected override void BeforeDisplayMenu()
        {
            PrintHeader();
        }

        protected override void AfterDisplayMenu()
        {
            base.AfterDisplayMenu();
            SetColor(ConsoleColor.Green);
            Console.WriteLine("");
            ResetColor();
        }

        private void PrintHeader()
        {
            SetColor(ConsoleColor.DarkGreen);
            Console.WriteLine(@"
        _                   ___           _        
 /\   /(_) _____      __   / _ \__ _ _ __| | _____ 
 \ \ / / |/ _ \ \ /\ / /  / /_)/ _` | '__| |/ / __|
  \ V /| |  __/\ V  V /  / ___/ (_| | |  |   <\__ \
   \_/ |_|\___| \_/\_/   \/    \__,_|_|  |_|\_\___/
                                                 
            ");
            ResetColor();
        }

    }
}
