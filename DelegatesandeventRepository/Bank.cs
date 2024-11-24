using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public delegate void BalanceNotification();

namespace DelegatesandeventRepository
{
    public class Bank
    {
        private double balance;

        
        public event BalanceNotification InsufficientBalance;
        public event BalanceNotification LowBalance;
        public event BalanceNotification ZeroBalance;

       
        public Bank(double initialBalance)
        {
            balance = initialBalance;
            CheckBalance();
        }

       
        public void Credit(double amount)
        {
            balance += amount;
            Console.WriteLine($"Credited: {amount}");
            CheckBalance();
        }

       
        public void Debit(double amount)
        {
            if (amount > balance)
            {
                InsufficientBalance?.Invoke(); 
            }
            else
            {
                balance -= amount;
                Console.WriteLine($"Debited: {amount}");
                CheckBalance();
            }
        }

       
        private void CheckBalance()
        {
            if (balance == 0)
            {
                ZeroBalance?.Invoke(); 
            }
            else if (balance < 3000)
            {
                LowBalance?.Invoke(); 
            }
        }

       
        public double GetBalance() => balance;
    }

    public class Program
    {
        static void InsufficientBalanceMsg()
        {
            Console.WriteLine("Insufficient balance for this transaction.");
        }

        static void LowBalanceMsg()
        {
            Console.WriteLine("Warning: Low balance.");
        }

        static void ZeroBalanceMsg()
        {
            Console.WriteLine("Balance is zero.");
        }

        public static void Main()
        {
           
            Bank account = new Bank(2000);

            
            account.InsufficientBalance += InsufficientBalanceMsg;
            account.LowBalance += LowBalanceMsg;
            account.ZeroBalance += ZeroBalanceMsg;

            account.Credit(1000);  
            Console.WriteLine("Current Balance: " + account.GetBalance());

            account.Debit(500);    
            Console.WriteLine("Current Balance: " + account.GetBalance());

            account.Debit(3000);   
            Console.WriteLine("Current Balance: " + account.GetBalance());

            account.Debit(2500);   
            Console.WriteLine("Current Balance: " + account.GetBalance());
        }
    }
}
