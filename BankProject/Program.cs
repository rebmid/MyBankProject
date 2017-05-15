using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject
{
    class Program
{
    static void Main(string[] args)
    {
        //var account = Bank.CreateAccount("test@test.com", 100, "Savings");
        //Console.WriteLine($"AccountNumber: {account.AccountNumber}, Type: {account.TypeOfAccount}, Balance: {account.Balance:C}, Email Address: {account.EmailAddress}");

        //var account2 = Bank.CreateAccount("test2@test.com", 200, "Checking");
        //Console.WriteLine($"AccountNumber: {account2.AccountNumber}, Type: {account2.TypeOfAccount}, Balance: {account2.Balance}, Email Address: {account2.EmailAddress}");

        Console.WriteLine("**********Welcome to my bank!***********************");

        while (true)
        {

            Console.WriteLine("0.Exit");
            Console.WriteLine("1. Create an account");
            Console.WriteLine("2. Deposit");
            Console.WriteLine("3. Withdraw");
            Console.WriteLine("4. Print all accounts");
            Console.WriteLine("5. Show All Transactions");
            Console.Write("Please select a choice from above: ");
            var option = Console.ReadLine();
            switch (option)
            {
                case "0":
                    return;

                case "1":
                    Console.Write("Email Address: ");
                    var emailAddress = Console.ReadLine();
                    Console.Write("Please choose from the type of account: ");
                    var accountTypes = Enum.GetNames(typeof(AccountTypes));
                    for (int i = 0; i < accountTypes.Length; i++)
                    {
                            Console.WriteLine($"{i + 1}.  {accountTypes[i]}");
                    }
                    var typeOfAccount = (AccountTypes) (Convert.ToInt32(Console.ReadLine()) - 1);
                    Console.Write("Amount: ");
                    var amount = Convert.ToDecimal(Console.ReadLine());

                    var account = Bank.CreateAccount(emailAddress, amount, typeOfAccount);
                    Console.WriteLine($"AccountNumber: {account.AccountNumber}, Type: {account.TypeOfAccount}, Balance: {account.Balance:C}, Email Address: {account.EmailAddress}");

                    break;
                case "2":
                        PrintAllAccounts();
                        Console.WriteLine("Pick an account number to deposit:");
                        var accountNum = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Amount to deposit: ");
                        amount = Convert.ToDecimal(Console.ReadLine());
                        Bank.Deposit(accountNum, amount);
                        Console.WriteLine("Deposit successfull");
                        break;
                case "3":
                        PrintAllAccounts();
                        Console.WriteLine("Pick an account number to withdraw:");
                        accountNum = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Amount to withdraw: ");
                        amount = Convert.ToDecimal(Console.ReadLine());
                        Bank.Withdraw(accountNum, amount);
                        Console.WriteLine("Deposit successfull");
                        break;
                    case "4":
                        PrintAllAccounts();
                        break;
                    case "5":
                        PrintAllAccounts();
                        Console.WriteLine("Pick an account number to see transactions:");
                        accountNum = Convert.ToInt32(Console.ReadLine());
                        var transactions = Bank.GetAllTransactionsByAccount(accountNum);
                        foreach (var tran in transactions)
                        {
                            Console.WriteLine($"Transactionid: {tran.TransactionId}, Description: {tran.Description}, Amount: {tran.Amount} Type of transaction: {tran.TransactionType}, Date: {tran.TransactionDate}");
                        }
                        break;
                    default:
                    break;
            }
        }
    }

        private static void PrintAllAccounts()
        {
            var accounts = Bank.GetAllAccounts();
            foreach (var a in accounts)
            {
                Console.WriteLine($"AccountNumber: {a.AccountNumber}, Type: {a.TypeOfAccount}, Balance: {a.Balance:C}, Email Address: {a.EmailAddress}");
            }
        }
    }
}
