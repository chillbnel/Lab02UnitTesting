using System;

namespace Lab02UnitTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            HomeScreen();
        }

        static void HomeScreen()
        {
            string userEntry;
            int userEntryInt = 0;

            Console.WriteLine("Welcome to BANK Corps ATM, Please select from the following:\n" +
                "1. View Balance\n" +
                "2. Withdraw Money\n" +
                "3. Add Money\n" +
                "4. Exit\n");

            userEntry = Console.ReadLine();

            switch (userEntryInt)//takes user to the selected action
            {
                case 1:
                    Console.WriteLine("Your current balance is :" + ViewBalance());
                    break;
                case 2:
                    Console.WriteLine("How much would you like to withdraw? (Up to " + ViewBalance() + "): ");
                   
                    double userWithdrawl = Console.ReadLine();
                    do
                    {
                        Console.WriteLine("Insuffiecent funds. How much would you like to withdraw? (Up to " + ViewBalance() + "): ");
                        userWithdrawl = Console.ReadLine();
                    } while (userWithdrawl > ViewBalance());

                    break;
                case 3:
                    break;
                default:
                    break;
            }
        }

        static double ViewBalance()
        {
            return 5000;
        } 

        static double WithdrawMoney(double amountWithdrawn)
        {
            if (ViewBalance() > amountWithdrawn)
            {
                return (ViewBalance() - amountWithdrawn);
            }
            return (ViewBalance() - amountWithdrawn);
        }
    }
}
