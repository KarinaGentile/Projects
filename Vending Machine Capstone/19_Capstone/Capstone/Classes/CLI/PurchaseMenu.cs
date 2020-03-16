using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    /// <summary>
    /// Purchase menu is a Main menu which guides the user through the purchase process flow
    /// of adding money, selecting their option(s), and finishing the transaction.
    /// </summary>
    public class PurchaseMenu : MainMenu
    {
        #region Constructor
        public PurchaseMenu(VendingMachine vm) : base(vm)
        {
        }
        #endregion

        #region Methods
        public void DisplayPurchaseMenu()
        {
            string input;
            bool keepGoing = true;
            while (keepGoing)
            {
                Console.Clear();
                DisplayLogo();

                Console.WriteLine("1) Feed Money"); // allow user to input whole dollar amount repeatedly
                Console.WriteLine("2) Select Product"); //Display items & allow user to select using sortId
                Console.WriteLine("3) Finish Transaction");
                Console.WriteLine("\n");

                Console.WriteLine($"Current Money Provided: {VM.Balance:c}");
                Console.Write("Please Enter Selection: ");
                input = Console.ReadLine();

                switch (input)
                {
                    case "1": //Feedmoney
                        GetUsersPayment();
                        continue;
                    case "2": //Select product
                        Dictionary<string, VendingMachineItem> items = VM.Inventory;
                        DisplayItems(items);
                        SelectItem(items);
                        break;
                    case "3": //Finish Transaction
                        MoneyChanger change = new MoneyChanger(VM.Balance);
                        VM.MakeChange();
                        PrintChange(change);
                        keepGoing = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Menu Option. Please Try Again.");
                        continue;
                }

                Console.ReadLine();
            }

            MainMenu m = new MainMenu(VM);
            m.DisplayMainMenu();

        }

        public void SelectItem(Dictionary<string, VendingMachineItem> items)
        {
            Console.Write("Please select item: ");
            string selection = Console.ReadLine().ToUpper();

            if (!items.ContainsKey(selection))
            {
                Console.WriteLine("Invalid Selection. Try Again.");
            }
            else if (items[selection].Quantity < 1)
            {
                Console.WriteLine("Out of stock. Please make a different selection.");
            }
            else if (VM.Balance < items[selection].Price)
            {
                Console.WriteLine($"Sorry! You have insufficient funds. Please try again");

            }
            else
            {
                VM.DispenseItem(selection);
                DisplayDispenseMessage(selection, items[selection]);
            }
        }

        public void DisplayDispenseMessage(string selection, VendingMachineItem item)
        {
            Console.Clear();
            Console.WriteLine($"{item.ProductName} is yours for only {item.Price:C}.");
            Console.WriteLine($"{item.PurchaseMessage}");
            Console.WriteLine($"You have {VM.Balance:C} remaining - can we tempt you with anything else?");
            Console.WriteLine($"Press Enter to Return to Menu.");
        }


        public void GetUsersPayment()
        {
            Console.Write("Please deposit money from your bank (Whole Dollar Only): ");
            string input = Console.ReadLine();



            if (!int.TryParse(input, out int value))
            {
                Console.WriteLine($"FEED ERROR! Please enter a whole dollar amount.");
            }
            if (value < 0)
            {
                Console.WriteLine($"FEED ERROR! Please enter a whole dollar amount.");
            }
            else
            {    
                VM.FeedMoney(value);
                Console.WriteLine($"{value:C} added.");
            }
            Console.ReadLine();
        }

        public void PrintChange(MoneyChanger change)
        {
            Console.WriteLine($"Here is your change: {change.Quarters} Quarters, {change.Dimes} Dimes, {change.Nickels} Nickels, and {change.Pennies} Pennies");
        }
        #endregion
    }
}