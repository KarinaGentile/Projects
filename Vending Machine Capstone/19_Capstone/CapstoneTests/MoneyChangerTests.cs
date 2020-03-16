using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone;


namespace CapstoneTests
{
    [TestClass]
    public class MoneyChangerTests
    {
        [DataTestMethod]

        public void ZeroDollarsReturnsNoChange()
        {
            MoneyChanger change = new MoneyChanger(0M);

            Assert.AreEqual(0, change.Pennies);
            Assert.AreEqual(0, change.Nickels);
            Assert.AreEqual(0, change.Dimes);
            Assert.AreEqual(0, change.Quarters);
        }

        [TestMethod]
        public void SmallChangeTests()
        {
            MoneyChanger change = new MoneyChanger(0.03M);
            Assert.AreEqual(3, change.Pennies);
            Assert.AreEqual(0, change.Nickels);
            Assert.AreEqual(0, change.Dimes);
            Assert.AreEqual(0, change.Quarters);

            change = new MoneyChanger(0.17M);
            Assert.AreEqual(2, change.Pennies);
            Assert.AreEqual(1, change.Nickels);
            Assert.AreEqual(1, change.Dimes);
            Assert.AreEqual(0, change.Quarters);

            change = new MoneyChanger(0.60M);
            Assert.AreEqual(0, change.Pennies);
            Assert.AreEqual(0, change.Nickels);
            Assert.AreEqual(1, change.Dimes);
            Assert.AreEqual(2, change.Quarters);

            change = new MoneyChanger(1.99M);
            Assert.AreEqual(4, change.Pennies);
            Assert.AreEqual(0, change.Nickels);
            Assert.AreEqual(2, change.Dimes);
            Assert.AreEqual(7, change.Quarters);
        }

        [TestMethod]
        public void LargeChangeTest()
        {
            MoneyChanger change = new MoneyChanger(105.69M);

            Assert.AreEqual(4, change.Pennies);
            Assert.AreEqual(1, change.Nickels);
            Assert.AreEqual(1, change.Dimes);
            Assert.AreEqual(422, change.Quarters);
        }
    }
}