using Capstone.Classes;
using Capstone.DAL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace Capstone.Views
{
    public class CampgroundMenu : CLIMenu
    {
        public int chosen;
        protected IParkDAO ParkDAO;
        protected ICampgroundDAO CampDAO;
        protected ISiteDAO SiteDAO;
        protected IReservationDAL ResDal;
        public CampgroundMenu(int chosen, ICampgroundDAO campDAO, IParkDAO parkDAO, ISiteDAO siteDAO, IReservationDAL resDal) : base("Campground")
        {
            this.chosen = chosen;
            CampDAO = campDAO;
            ParkDAO = parkDAO;
            SiteDAO = siteDAO;
            ResDal = resDal;
        }

        protected override bool ExecuteSelection(string choice)
        { // implement 
            int campchoice = int.Parse(choice);
            ReservationMenu rem = new ReservationMenu(campchoice, chosen, ParkDAO, CampDAO, SiteDAO, ResDal);
            rem.Run();
            return true;
        }
        protected override void SetMenuOptions()
        {
            menuOptions.Add("1", "Search For Available Reservations");
            menuOptions.Add("B", "Back to Previous Menu");
            quitKey = "B"; 
        }
        private void PrintHeader()
        {
            SetColor(ConsoleColor.DarkGreen);
            Console.WriteLine(@"
   ___                                                      _     
  / __\__ _ _ __ ___  _ __   __ _ _ __ ___  _   _ _ __   __| |___ 
 / /  / _` | '_ ` _ \| '_ \ / _` | '__/ _ \| | | | '_ \ / _` / __|
/ /__| (_| | | | | | | |_) | (_| | | | (_) | |_| | | | | (_| \__ \
\____/\__,_|_| |_| |_| .__/ \__, |_|  \___/ \__,_|_| |_|\__,_|___/
                     |_|    |___/                                                                                
            ");
            ResetColor();
        }
        protected override void BeforeDisplayMenu()
        {
            PrintHeader();
            //Finish adding info with cw's
            
            List<Campground> camps = CampDAO.GetCampground(chosen);
            foreach (Campground camp in camps)
            {
                Console.WriteLine($" #: {camp.CampgroundId,-1} Name: {camp.Name,-10} Open: {CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(camp.OpenFromM),-5} Close: {CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(camp.OpenToM),-5} Daily Fee: {"$" + Math.Round((camp.DailyFee), 2),5}");
            }

        }




    }
}
