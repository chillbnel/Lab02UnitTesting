using System;

namespace Lab02UnitTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            double currentBalance = 5000;
            HomeScreen(currentBalance);
        }

        static void HomeScreen(double currentBalance)
        {
            string userEntry;

            Console.WriteLine("Welcome to BANK Corps ATM, Please select from the following:\n" +
                "1. View Balance\n" +
                "2. Withdraw Money\n" +
                "3. Add Money\n" +
                "4. Exit\n" +
                "Enter 1, 2, 3, or 4 to continue");

            userEntry = Console.ReadLine();
            MenuSelect(userEntry, currentBalance);
        }

        static void MenuSelect(string userEntry, double currentBalance)
        {
            int userEntryInt = 0;
            if (int.TryParse(userEntry, out userEntryInt))
            {
                switch (userEntryInt)
                {
                    case 1:
                        ViewBalance(currentBalance);
                        break;
                    case 2:
                        currentBalance = WithdrawMoney(currentBalance);
                        break;
                    case 3:
                        currentBalance = DepositMoney(currentBalance);
                        break;
                    default:
                        break;
                }
            }
          HomeScreen(currentBalance);
        }

        static void ViewBalance(double currentBalance)
        {
            Console.WriteLine("Your current balance is :" + currentBalance + ". Hit 'Enter' to return to main menu.");
            Console.ReadLine();
        } 

        static double WithdrawMoney(double currentBalance)
        {
            double newBalance = 0;
            Console.WriteLine("How much would you like to withdraw? (Up to " + currentBalance + "): ");

            double userWithdrawl = Convert.ToDouble(Console.ReadLine());

            do
            {
                Console.WriteLine("Insuffiecent funds. How much would you like to withdraw? (Up to " + currentBalance + "): ");
                userWithdrawl = Convert.ToDouble(Console.ReadLine());
            } while (userWithdrawl > currentBalance);

            newBalance = currentBalance - userWithdrawl;

            Console.WriteLine("Please take your " + userWithdrawl + " below.  Your remaining balance is: " + newBalance + ". Hit 'Enter' to continue.");
            Console.ReadLine();

            return newBalance;
        }

        static double DepositMoney(double currentBalance)
        {
            double newBalance = 0;
            Console.WriteLine("How much would you like to deposit? ");

            double userWithdrawl = Convert.ToDouble(Console.ReadLine());

            newBalance = currentBalance - userWithdrawl;

            Console.WriteLine("Your new balance is: " + newBalance + ". Hit 'Enter' to continue.");
            Console.ReadLine();

            return newBalance;
        }
    }
}
