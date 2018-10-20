using System;
using Xunit;
using Lab02UnitTesting;
using static Lab02UnitTesting.Program;

namespace ATMTest
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(500)]
        [InlineData(2000)]
        public void CanDeposit(double deposit)
        {
            double currentBalance = 5000;
            Assert.Equal(currentBalance + deposit, DepositMoney(currentBalance, deposit));
        }

        [Theory]
        [InlineData(500)]
        [InlineData(2000)]
        public void CanWithdraw(double withrawal)
        {
            double currentBalance = 5000;
            Assert.Equal(currentBalance - withrawal, WithdrawMoney(currentBalance, withrawal));
        }
    }
}
