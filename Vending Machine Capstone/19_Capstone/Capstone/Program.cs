using System;

namespace Capstone
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.SetWindowSize(100, 40);

            Stocker stocker = new Stocker();
            string[] stockList = stocker.GetStock();

            VendingMachine vm = new VendingMachine();
            vm.FillSlots(stockList);
            MainMenu menu = new MainMenu(vm);
            menu.DisplayMainMenu();
        }
    }
}
