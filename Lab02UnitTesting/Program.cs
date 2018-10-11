using System;

namespace Lab02UnitTesting
{
    public class Program
    {
        static void Main(string[] args)
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
            string userEntry;

            Console.WriteLine("Welcome to BANK Corps ATM, Please select from the following:\n" +
                "MAIN MENU\n" +
                "1. View Balance\n" +
                "2. Withdraw Money\n" +
                "3. Add Money\n" +
                "4. Exit\n" +
                "Enter 1, 2, 3, or 4 to continue");

            userEntry = Console.ReadLine();
            MenuSelect(userEntry, currentBalance);
        }

        /// <summary>
        /// Method used to take the user's menu input and call corresponding method
        /// </summary>
        /// <param name="userEntry">Menu item selected</param>
        /// <param name="currentBalance">The user's current account balance</param>
        static void MenuSelect(string userEntry, double currentBalance)
        {
            int userEntryInt = 0;

            if (int.TryParse(userEntry, out userEntryInt))
            {
                switch (userEntryInt)
                {
                    case 1:
                        Console.Clear();
                        ViewBalance(currentBalance);
                        break;
                    case 2:
                        Console.Clear();
                        currentBalance = WithdrawMoney(currentBalance);
                        break;
                    case 3:
                        Console.Clear();
                        currentBalance = DepositMoney(currentBalance);
                        break;
                    default:
                        break;
                }
            }

            Console.Clear();
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
        static double WithdrawMoney(double currentBalance)
        {
            double newBalance = 0;
            double userWithdrawl = 0;

            Console.WriteLine("WITHDRAW FUNDS\n"+
                "How much would you like to withdraw? (Up to " + currentBalance + "): ");
            try
            {
                userWithdrawl = Convert.ToDouble(Console.ReadLine());
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message + ". Please enter a number. Hit 'Enter' to continue.");
                Console.ReadLine();
                Console.Clear();
                WithdrawMoney(currentBalance);
            }


            while (userWithdrawl > currentBalance)
            {
                Console.Clear();
                Console.WriteLine("WITHDRAW FUNDS\n" + 
                    "Insuffiecent funds. How much would you like to withdraw? (Up to " + currentBalance + "): ");
                userWithdrawl = Convert.ToDouble(Console.ReadLine());
            } 

            newBalance = currentBalance - userWithdrawl;

            Console.WriteLine("Please take your " + userWithdrawl + " below.  Your remaining balance is: " + newBalance + ". Hit 'Enter' to continue.");
            Console.ReadLine();

            return newBalance;
        }

        /// <summary>
        /// Method is used to conduct a user desposit
        /// </summary>
        /// <param name="currentBalance">The user's current account balance</param>
        /// <returns>The new account balance</returns>
        static double DepositMoney(double currentBalance)
        {
            double newBalance = 0;
            double userDeposit = 0;

            Console.WriteLine("DEPOSIT FUNDS\n" +
                "How much would you like to deposit? ");

            try
            {
                userDeposit = Convert.ToDouble(Console.ReadLine());
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message + ". Please enter a number. Hit 'Enter' to continue.");
                Console.ReadLine();
                Console.Clear();
                DepositMoney(currentBalance);
            }


            newBalance = currentBalance + userDeposit;

            Console.WriteLine("Your new balance is: " + newBalance + ". Hit 'Enter' to continue.");
            Console.ReadLine();

            return newBalance;
        }
    }
}
