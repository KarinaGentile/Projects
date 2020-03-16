using Capstone.Classes;
using Capstone.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Text;

namespace Capstone.Views
{

    public class ReservationMenu : CLIMenu
    {

      

        private IParkDAO ParkDAO;
        private ICampgroundDAO CampDAO;
        private ISiteDAO SiteDAO;
        private IReservationDAL ResDal;
        public int chosen;
        public int campchoice;

        public ReservationMenu(int campchoice, int chosen, IParkDAO parkDAO, ICampgroundDAO campDAO, ISiteDAO siteDAO, IReservationDAL resDal) : base ("Reservations Menu")
        {
            this.campchoice = campchoice;
            this.chosen = chosen;
            ParkDAO = parkDAO;
            CampDAO = campDAO;
            SiteDAO = siteDAO;
            ResDal = resDal;
        }

        protected override bool ExecuteSelection(string choice)
        {
            
            Console.WriteLine("What is your arrival date?");
            DateTime fromdate = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("What is your departure date?");
            DateTime todate = Convert.ToDateTime(Console.ReadLine());



            List<Site> sites = SiteDAO.GetAvailableSites(campchoice, fromdate, todate);
            decimal fee = CampDAO.GetDayFee(campchoice);
            int numDays = Convert.ToInt32((todate - fromdate).TotalDays);
            decimal dailyPrice = fee * numDays;
            foreach (Site site in sites)
            {
                Console.WriteLine($"#: {site.SiteNumber} Max Occ.: {site.MaxOccupancy} Accessible: {site.Accessible} RV Length: {site.MaxRVLength} Utility: {site.Utilities} Cost: {dailyPrice:C}");
            }
            Console.WriteLine();
            int sitepick = GetInteger("Please Select a Site Number.");
            string resName = GetString("Please enter the reservation name.");
            int resId = ResDal.MakeReservation(campchoice, sitepick, resName, fromdate, todate);
            Console.WriteLine($"The reservation has been made and the confirmation ID is: {resId}");
            Pause("");

            


            return true;
        }

        

        private void PrintHeader()
        {
            SetColor(ConsoleColor.DarkGreen);
            Console.WriteLine(@"
   __                                _   _                 
  /__\ ___  ___  ___ _ ____   ____ _| |_(_) ___  _ __  ___ 
 / \/// _ \/ __|/ _ \ '__\ \ / / _` | __| |/ _ \| '_ \/ __|
/ _  \  __/\__ \  __/ |   \ V / (_| | |_| | (_) | | | \__ \
\/ \_/\___||___/\___|_|    \_/ \__,_|\__|_|\___/|_| |_|___/
                                                                                                                                          
            ");
            ResetColor();
        }
        protected override void BeforeDisplayMenu()
        {
            PrintHeader();
            List<Campground> camps = CampDAO.GetCampground(chosen);
            foreach (Campground camp in camps)
            {
                Console.WriteLine($" #: {camp.CampgroundId,-1} Name: {camp.Name,-10} Open: {CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(camp.OpenFromM),-5} Close: {CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(camp.OpenToM),-5} Daily Fee: {"$" + Math.Round((camp.DailyFee), 2),5}");
            }

        }



        protected override void SetMenuOptions()
        {
            menuOptions.Add("1", "Which Campground?");
            
        }
    }
}
