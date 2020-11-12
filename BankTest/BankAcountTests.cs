using Bank;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace BankTest
{
    [TestClass]
    public class BankAcountTests
    {
        [TestMethod]
        public void Credit_withValidAmount_UpdateBalance()
        {
            double beginningBalance = 10.99;
            double creditAmount = 5.00;
            double expected = 15.99;
            BankAcount acount = new BankAcount("Érik", beginningBalance);
            //Act
            acount.Credit(creditAmount);

            //Assert
            double actual = acount.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not credit correct");
        }

        

        


        [TestMethod]
        public void Debit_WithValidAmount_UpdateBalance()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            BankAcount acount = new BankAcount("Érik", beginningBalance);
            //Act
            acount.Debit(debitAmount);

            //Assert
            double actual = acount.Balance;
           Assert.AreEqual(expected, actual, 0.001, "Account not debited correct");
        }



        [TestMethod]
        public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            double begginingBalance = 11.99;
            double debitAmount = -10.00;
            BankAcount acount = new BankAcount("Érik", begginingBalance);

            //act and assert
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => acount.Debit(debitAmount));
        }



        [TestMethod]
        public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 20.00;
            BankAcount account = new BankAcount("Érik", beginningBalance);

            // Act
            try
            {
                account.Debit(debitAmount);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                // Assert
                StringAssert.Contains(e.Message, BankAcount.DebitAmountExceedsBalanceMessage);
                return;
            }
            Assert.Fail("The expected exception was not thrown.");
        }



    }
}
