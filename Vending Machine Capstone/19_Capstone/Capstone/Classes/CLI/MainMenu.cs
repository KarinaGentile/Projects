using System;
using System.Collections.Generic;
using System.Text;


namespace Capstone
{
    /// <summary>
    /// Main Menu shows the user the available items and directs them to the purchase sub-menu or to exit
    /// </summary>
    public class MainMenu
    {
        public VendingMachine VM { get; }

        public MainMenu(VendingMachine vm)
        {
            this.VM = vm;
        }
        public void DisplayMainMenu()

        {
            bool keepGoing = true;
            while (keepGoing)
            {
                Console.Clear();
                DisplayLogo();
                Console.WriteLine("1) Display Vending Machine Items");
                Console.WriteLine("2) Purchase"); // go to PurchaseMenu
                Console.WriteLine("3) Exit");
                Console.Write("Please Enter Selection: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Dictionary<string, VendingMachineItem> items = VM.Inventory;
                        DisplayItems(items);
                        Console.WriteLine("\nPress Enter to Return to Main Menu Selection.");
                        break;
                    case "2":
                        PurchaseMenu pm = new PurchaseMenu(VM);
                        pm.DisplayPurchaseMenu();
                        break;
                    case "3":
                        keepGoing = false;
                        continue;
                    case "4":
                        SalesReporter.Report(VM.Inventory);
                        Console.WriteLine($"A sales report has been generated");
                        break;
                    default:
                        Console.WriteLine("Invalid Menu Option. Please try again.");
                        continue;
                }
                Console.ReadLine();
            }
        }

        public void DisplayItems(Dictionary<string, VendingMachineItem> items)
        {
            Console.WriteLine("\n\t\t------------------------------------------------");
            Console.WriteLine("\t\t|{0, 0} | {1,-20} | {2,5} | {3,8} |", "ID", "ITEM", "PRICE", "REMAINING");
            Console.WriteLine("\t\t------------------------------------------------");
            foreach (KeyValuePair<string, VendingMachineItem> kvp in items)
            
            {
                string quantity = "";
               
                if (kvp.Value.Quantity == 0)
                {
                    quantity = "SOLD OUT";
                }
            else
                {
                   quantity = kvp.Value.Quantity.ToString();
                }
                Console.WriteLine($"\t\t|{kvp.Key, 0} | {kvp.Value.ProductName, -20} | {kvp.Value.Price, 5:C} | {quantity, 8}  |");
            }
            Console.WriteLine("\t\t------------------------------------------------");
        }

        public void DisplayLogo()
        {
            ConsoleColor saveColor = Console.ForegroundColor;
            SetRandomColor();
            Console.WriteLine("___    __                        ______  ___      __________           _____________________ ");
            Console.WriteLine("__ |  / /_________________       ___   |/  /_____ __  /___(_)______    __( __ )_  __ \\_  __ \\");
            SetRandomColor();
            Console.WriteLine("__ | / /_  _ \\_  __ \\  __ \\________  /|_/ /_  __ `/  __/_  /_  ___/    _  __  |  / / /  / / /");
            SetRandomColor();
            Console.WriteLine("__ |/ / /  __/  / / / /_/ //_____/  /  / / / /_/ // /_ _  / / /__      / /_/ // /_/ // /_/ / ");
            SetRandomColor();
            Console.WriteLine("_____/  \\___//_/ /_/\\____/       /_/  /_/  \\__,_/ \\__/ /_/  \\___/      \\____/ \\____/ \\____/  ");
            Console.WriteLine("\n");
            Console.ForegroundColor = saveColor;
        }

        static private void SetRandomColor()
        {
            Array colors = Enum.GetValues(typeof(ConsoleColor));
            Random rand = new Random();
            int ix = rand.Next(1, colors.Length);
            ConsoleColor color = (ConsoleColor)colors.GetValue(ix);
            Console.ForegroundColor = color;
        }

    }

}


