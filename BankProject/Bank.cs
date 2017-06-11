using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject
{
    public static class Bank
    {
        private static BankModel db = new BankModel();
        public static Account CreateAccount(string emailAddress, decimal amount, AccountTypes typeOfAccount)
        {
            var account = new Account(emailAddress, typeOfAccount);
            account.Deposit(amount);
            account.CreatedDate = DateTime.Now;
            db.Accounts.Add(account);
            db.SaveChanges();
            return account;
        }

        public static List<Account> GetAllAccountsByEmailAddress(string emailAddress)
        {
            return db.Accounts.Where(a => a.EmailAddress == emailAddress).ToList();
        }
        public static decimal Deposit(int accountNumber, decimal amount)
        {
            var account = db.Accounts.Where(a => a.AccountNumber == accountNumber).FirstOrDefault();
            if (account == null)
                throw new ArgumentException("Account not found");

            var newBalance = account.Deposit(amount);

            var transaction = new Transaction
            {
                TransactionDate = DateTime.Now,
                Description = "Banch Deposit",
                TransactionType = TransactionTypes.Credit,
                Amount = amount,
                AccountNumber = accountNumber
            };
            db.Transactions.Add(transaction);
            db.SaveChanges();
            return newBalance;

        }
        public static decimal Withdraw(int accountNumber, decimal amount)
        {
            var account = db.Accounts.Where(a => a.AccountNumber == accountNumber).FirstOrDefault();
            if (account == null)
                throw new ArgumentException("Account not found");

            var newBalance = account.Withdraw(amount);

            var transaction = new Transaction
            {
                TransactionDate = DateTime.Now,
                Description = "Banch Withdraw",
                TransactionType = TransactionTypes.Debit,
                Amount = amount,
                AccountNumber = accountNumber
            };
            db.Transactions.Add(transaction);
            db.SaveChanges();
            return newBalance;
        }

        public static List<Transaction> GetAllTransactionsByAccount(int acccountNumber)
        {
            return db.Transactions.Where(t => t.AccountNumber == acccountNumber).OrderByDescending(t => t.TransactionDate).ToList();
        }

        public static Account GetAccountbyAccountNumber(int id)

        {
            return db.Accounts.Find(id);
        }

        public static void EditAccount(Account account)
        {
            var oldAccount = db.Accounts.Find(account.AccountNumber);
            db.Entry(oldAccount).State = System.Data.Entity.EntityState.Modified;
            oldAccount.TypeOfAccount = account.TypeOfAccount;
            db.SaveChanges();
        }
        
        public static void DeleteAccount(int id)

        {
            Account account = db.Accounts.Find(id);
            db.Accounts.Remove(account);
            db.SaveChanges();
        }

    }

}


    

