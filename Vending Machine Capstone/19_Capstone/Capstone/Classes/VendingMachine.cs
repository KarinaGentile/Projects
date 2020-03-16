using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    /// <summary>
    /// The Vending Machine gets filled when the application is launched.
    /// It dispenses items and keeps track of its inventory.
    /// </summary>
    public class VendingMachine
    {
        #region Properties
        public decimal Balance { get; set; }
        public Dictionary<string, VendingMachineItem> Inventory { get; } = new Dictionary<string, VendingMachineItem>();
        #endregion

        #region Methods
        public void FillSlots(string[] stockList)
        {
            foreach (string line in stockList)
            {
                string[] item = line.Split("|");
                Inventory.Add(item[0], new VendingMachineItem(item[1], decimal.Parse(item[2]), item[3]));
            }
        }

        public void DispenseItem(string selection)
        {

            Balance -= Inventory[selection].Price;
            Inventory[selection].Quantity--;

            Auditor.Audit($"{Inventory[selection].ProductName} {selection} {Balance + Inventory[selection].Price} {Balance:C}");
        }

        public void FeedMoney(int money)
        {
                Balance += money;
            
            Auditor.Audit($"FEED MONEY {money:C} {Balance:C}");
        }

        public void MakeChange()
        {
            decimal balanceToReturn = Balance;
            Balance = 0;
            Auditor.Audit($"MAKE CHANGE {balanceToReturn:C} {Balance:C}");
        }
        #endregion
    }
}