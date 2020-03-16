using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone
{
    /// <summary>
    /// Stocks Vending Machine Inventory from provided file.
    /// The file is expected to be in the current working directory.
    /// </summary>
    public class Stocker
    {
        
        public string[] GetStock()
        {
            string inputfile = "vendingmachine.csv";
            string[] stock;
            try 
            { 
                stock = File.ReadAllLines(Environment.CurrentDirectory + "\\" + inputfile);        
                return stock;
            }
            catch
            {
                Console.WriteLine(@"
  /$$$$$$  /$$   /$$ /$$$$$$$$        /$$$$$$  /$$$$$$$$        /$$$$$$  /$$$$$$$  /$$$$$$$  /$$$$$$$$ /$$$$$$$ 
 /$$__  $$| $$  | $$| __  $$__ /     /$$__  $$| $$_____ /      /$$__  $$| $$__  $$| $$__  $$| $$_____ /|$$__  $$
| $$  \ $$| $$  | $$   | $$         | $$  \ $$| $$            | $$  \ $$| $$  \ $$| $$  \ $$| $$      | $$  \ $$
| $$  | $$| $$  | $$   | $$         | $$  | $$| $$$$$         | $$  | $$| $$$$$$$/| $$  | $$| $$$$$   | $$$$$$$/
| $$  | $$| $$  | $$   | $$         | $$  | $$| $$__/         | $$  | $$| $$__  $$| $$  | $$| $$__/   | $$__  $$
| $$  | $$| $$  | $$   | $$         | $$  | $$| $$            | $$  | $$| $$  \ $$| $$  | $$| $$      | $$  \ $$
|  $$$$$$/|  $$$$$$/   | $$         |  $$$$$$/| $$            |  $$$$$$/| $$  | $$| $$$$$$$/| $$$$$$$$| $$  | $$
 \______/  \______/    |__/          \______/ |__/             \______/ |__/  |__/|_______/ |________/|__/  |__/
                                                                                                                
                                                                                                                
                                                                                                                
");
                Console.ReadLine();
  
            }
            return new string[] {  };
        }
       
    }
}
