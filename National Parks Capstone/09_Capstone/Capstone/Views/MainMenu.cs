using Capstone.Classes;
using Capstone.DAL;
using System;
using System.Collections.Generic;

namespace Capstone.Views
{
    /// <summary>
    /// The top-level menu in our Market Application
    /// </summary>
    public class MainMenu : CLIMenu
    {
        // DAOs - Interfaces to our data objects can be stored here...
        protected IParkDAO parkDAO;
        protected ICampgroundDAO campDAO;
        protected ISiteDAO siteDAO;
        protected IReservationDAL resDal;


        /// <summary>
        /// Constructor adds items to the top-level menu. YOu will likely have parameters for one or more DAO's here...
        /// </summary>
        public MainMenu(IParkDAO parkDAO, ICampgroundDAO campDAO, ISiteDAO siteDAO, IReservationDAL resDal) : base("Main Menu")
        {
            //Camp = camp;
            //Park = park;
            this.parkDAO = parkDAO;
            this.campDAO = campDAO;
            this.siteDAO = siteDAO;
            this.resDal = resDal;
        }



        protected override void SetMenuOptions()
        {
            this.menuOptions.Add("1", "View Parks");
            this.menuOptions.Add("Q", "Quit Program");
        }

        /// <summary>
        /// The override of ExecuteSelection handles whatever selection was made by the user.
        /// This is where any business logic is executed.
        /// </summary>
        /// <param name="choice">"Key" of the user's menu selection</param>
        /// <returns></returns>
        protected override bool ExecuteSelection(string choice)
        {
            switch (choice)
            {
                case "1": // Create and show the sub-menu
                    ViewParksMenu sm = new ViewParksMenu(parkDAO, campDAO, siteDAO, resDal);
                    sm.Run();
                    return true;    // Keep running the main menu
            }
            return true;
        }

        protected override void BeforeDisplayMenu()
        {
            PrintHeader();
        }


        private void PrintHeader()
        {
            SetColor(ConsoleColor.DarkGreen);
            Console.WriteLine(@"
     __      _   _                   _     ___           _        
  /\ \ \__ _| |_(_) ___  _ __   __ _| |   / _ \__ _ _ __| | _____ 
 /  \/ / _` | __| |/ _ \| '_ \ / _` | |  / /_)/ _` | '__| |/ / __|
/ /\  / (_| | |_| | (_) | | | | (_| | | / ___/ (_| | |  |   <\__ \
\_\ \/ \__,_|\__|_|\___/|_| |_|\__,_|_| \/    \__,_|_|  |_|\_\___/                                                            
");

            ResetColor();
        }
    }
}
