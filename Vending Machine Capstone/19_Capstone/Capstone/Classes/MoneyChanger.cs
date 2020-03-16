using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    /// <summary>
    /// The MoneyChanger makes change from the vending machine balance with the least number of coins possible
    /// when the user finishes their transaction.
    /// </summary>
    public class MoneyChanger
    {
        public int Quarters { get; private set; }
        public int Dimes { get; private set; }
        public int Nickels { get; private set; }
        public int Pennies { get; private set; }

        public MoneyChanger(decimal balance)
        {
            int balanceInPennies = (int)(balance * 100);
            Quarters = balanceInPennies / 25;
            balanceInPennies = balanceInPennies % 25;
            Dimes = balanceInPennies / 10;
            balanceInPennies = balanceInPennies % 10;
            Nickels = balanceInPennies / 5;
            Pennies = balanceInPennies % 5;
        }
    }
}
