using Capstone.Classes;
using Capstone.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Views
{
    public class ParkInfoMenu : CLIMenu
    {


        private ICampgroundDAO campDAO;
        private IParkDAO ParkDAO;
        private ISiteDAO SiteDAO;
        private IReservationDAL ReservationDAL;
        public int chosen;

        public ParkInfoMenu(int chosen, ICampgroundDAO campp, IParkDAO parkDAO, ISiteDAO siteDAO, IReservationDAL reservationDAL) : base("Park Information")
        {
            this.chosen = chosen;
            campDAO = campp;
            ParkDAO = parkDAO;
            SiteDAO = siteDAO;
            ReservationDAL = reservationDAL;
        }

        protected override bool ExecuteSelection(string choice)
        {

            CampgroundMenu cif = new CampgroundMenu(chosen, campDAO, ParkDAO, SiteDAO, ReservationDAL);
            cif.Run();

            return true;
        }

        protected void DisplayCampgrounds()
        {
            menuOptions.Clear();
            List<Campground> camps = campDAO.GetCampground(chosen);

            foreach (Campground camp in camps)
            {
                menuOptions.Add(camp.CampgroundId.ToString(), camp.Name);
            }

            this.menuOptions.Add("B", "Back to Main Menu");
            this.quitKey = "B";

            this.Run();
        }

        protected override void SetMenuOptions()
        {
            menuOptions.Add("1", "View Campgrounds");

            menuOptions.Add("B", "Back to Previous Menu");
            quitKey = "B";
        }

        private void PrintHeader()
        {
            SetColor(ConsoleColor.DarkGreen);
            Console.WriteLine(@"
   ___           _       _____        __       
  / _ \__ _ _ __| | __   \_   \_ __  / _| ___  
 / /_)/ _` | '__| |/ /    / /\/ '_ \| |_ / _ \ 
/ ___/ (_| | |  |   <  /\/ /_ | | | |  _| (_) |
\/    \__,_|_|  |_|\_\ \____/ |_| |_|_|  \___/ 
                                                 
            ");
            ResetColor();
        }
        protected override void BeforeDisplayMenu()
        {

            List<Park> parks = ParkDAO.GetParks();

            Park chosenPark = null;

            foreach (Park park in parks)
            {
                if (park.ParkID == chosen)
                {
                    chosenPark = park;
                }
            }

            PrintHeader();
            //Finish adding info with cw's
            Console.WriteLine($"Name: {chosenPark.Name}");
            Console.WriteLine($"Location: {chosenPark.Location}");
            Console.WriteLine($"Establised: {chosenPark.EstablishDateString}");
            Console.WriteLine($"Area: {chosenPark.Area} sq. km.");
            Console.WriteLine($"Annual Visitors: {chosenPark.Visitors}");
            Console.WriteLine("");
            Console.WriteLine(chosenPark.Description);

        }
    }
}
