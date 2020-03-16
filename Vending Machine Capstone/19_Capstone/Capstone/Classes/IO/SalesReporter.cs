using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Capstone;

namespace Capstone
{
    public static class SalesReporter
    {
        /// <summary>
        /// Sales report reports total sales for each session
        /// </summary>
        /// <param name="inventory"></param>
        public static void Report(Dictionary<string, VendingMachineItem> inventory)
        {
            decimal totalSales = 0m;

            using (StreamWriter sw = new StreamWriter(Environment.CurrentDirectory + $"\\{DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss")}_SalesReport.txt"))
            {
                foreach (KeyValuePair<string, VendingMachineItem> inventoryItem in inventory)
                {
                    totalSales += inventoryItem.Value.Price * (5 - inventoryItem.Value.Quantity);
                    sw.WriteLine($"{inventoryItem.Value.ProductName}|{5 - inventoryItem.Value.Quantity}");
                }
                sw.WriteLine();
                sw.WriteLine($"Total Sales :{totalSales:C}");
            }
        }
    }
}