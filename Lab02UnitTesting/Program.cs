using System;

namespace Lab02UnitTesting
{
    public class Program
    {
        public static void Main(string[] args)
        {
            double currentBalance = 5000;
            HomeScreen(currentBalance);
        }

        /// <summary>
        /// Method used to display ATM main menu
        /// </summary>
        /// <param name="currentBalance">The user's current account balance</param>
        static void HomeScreen(double currentBalance)
        {

            Console.WriteLine("Welcome to BANK Corps ATM, Please select from the following:\n" +
                "MAIN MENU\n" +
                "1. View Balance\n" +
                "2. Withdraw Money\n" +
                "3. Add Money\n" +
                "4. Exit\n" +
                "Enter 1, 2, 3, or 4 to continue");
            try
            {
                int userEntry = int.Parse(Console.ReadLine());
                MenuSelect(userEntry, currentBalance);
            }
            catch
            {

            }

        }

        /// <summary>
        /// Method used to take the user's menu input and call corresponding method
        /// </summary>
        /// <param name="userEntry">Menu item selected</param>
        /// <param name="currentBalance">The user's current account balance</param>
        static void MenuSelect(int userEntry, double currentBalance)
        {
                switch (userEntry)
                {
                    case 1:
                        Console.Clear();
                        ViewBalance(currentBalance);
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("WITHDRAW FUNDS\n" +
                                          "How much would you like to withdraw? (Up to " + currentBalance + "): ");
                        double userWithdrawl = Convert.ToDouble(Console.ReadLine());
                        currentBalance = WithdrawMoney(currentBalance, userWithdrawl);
                        Console.WriteLine("Please take your " + userWithdrawl + " below.  Your remaining balance is: " + currentBalance + ". Hit 'Enter' to continue.");
                        Console.ReadLine();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("DEPOSIT FUNDS\n" +
                                          "How much would you like to deposit? ");
                        double userDeposit = Convert.ToDouble(Console.ReadLine());
                        currentBalance = DepositMoney(currentBalance, userDeposit);
                        Console.WriteLine("Your new balance is: " + currentBalance + ". Hit 'Enter' to continue.");
                        Console.ReadLine();
                        break;
                    default:
                        break;
                }
            HomeScreen(currentBalance);
        }

        /// <summary>
        /// Method displays the user's account balance
        /// </summary>
        /// <param name="currentBalance">The user's current account balance</param>
        static void ViewBalance(double currentBalance)
        {
            Console.WriteLine("YOUR BALANCE\n"
                + "Your current balance is: " + currentBalance + ". Hit 'Enter' to return to main menu.");
            Console.ReadLine();
        }

        /// <summary>
        /// Method is used to conduct a user withdrawl; ensures that the money has sufficent funds
        /// </summary>
        /// <param name="currentBalance">The user's current account balance</param>
        /// <returns>The new account balance</returns>
        public static double WithdrawMoney(double currentBalance, double userWithdrawl)
        {
            if (userWithdrawl > currentBalance)
            {
                throw new Exception("You do not have enough money in your account to withdraw this amount.");
            }
            else
            {
                currentBalance = currentBalance - userWithdrawl;
            }

            return currentBalance;
        }

        /// <summary>
        /// Method is used to conduct a user desposit
        /// </summary>
        /// <param name="currentBalance">The user's current account balance</param>
        /// <returns>The new account balance</returns>
        public static double DepositMoney(double currentBalance, double userDeposit)
        {
            if (userDeposit > 0)
            {
                currentBalance = currentBalance + userDeposit;
            }
            else
            {
                throw new Exception("Please enter a positive amount to deposit.");
            }

            return currentBalance;
        }
    }
}
