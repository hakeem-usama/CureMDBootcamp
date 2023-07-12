using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_Task2
{
    class BankAccount
    {
        public int accountNumber;
        public string name;
        public double balance;

        public BankAccount(int AccountNumber, string NAME, int Balance)
        {
            accountNumber = AccountNumber;
            name = NAME;
            balance = Balance;
        }
        public virtual double Deposit(int amount)
        {
            balance += amount;
            Console.WriteLine($"Amount {amount} has been desposited in your account");
            Console.WriteLine($"Your New Balance is {balance} ");
            return balance;
        }
        public virtual double Withdraw(int amount)
        {
            balance -= amount;
            Console.WriteLine($"Amount {amount} has been desposited in your account");
            Console.WriteLine($"Your Remaining Balance is {balance} ");
            return balance;
        }
        public  void DisplayAccountInfo()
        {
            Console.WriteLine($"Account Info is: \nAccount Number :{accountNumber}\n Name: {name}\n Current Balance: {balance} ");

        }
    }
    class SavingsAccount:BankAccount
    {
        public double intrestRate;
                public double AmountwithIntreset;
        public SavingsAccount(int AccountNumber, string NAME, int Balance,double IntrestRate):base (AccountNumber,NAME,Balance)
        {
            intrestRate = IntrestRate;
        }
        public override double Deposit(int amount)
        {
            AmountwithIntreset= amount+ amount*intrestRate;
            balance += AmountwithIntreset;
            Console.WriteLine($"Amount {amount} has been desposited with 11% intreset in your account");
            Console.WriteLine($"Your New Balance is {balance} ");
            return balance;
        }
    }
    class CheckingAccount:BankAccount
    {
        public double amount;
        public CheckingAccount(int AccountNumber, string NAME, int Balance) : base(AccountNumber, NAME, Balance)
        {
            
            
        }
        public override double Withdraw(int amount)
        {
            if (amount > balance)
                Console.WriteLine("ERROR....\nEntered Amount Exceed the Available amount in Your Account");
            return balance;
        }

    }
    class Bank
    {
        public List<BankAccount> BankAccounts { get; set; }
        public Bank()
        {
            BankAccounts = new List<BankAccount>();
        }
        public void AddAccount(BankAccount account)
        {
            BankAccounts.Add(account);
            Console.WriteLine($"Account is added in bank detail is as:\nAcount Number:{account.accountNumber}\nAccount Title: {account.name}\nAmount in Account: {account.balance}");
        }
        public void DepositToAccount(BankAccount account, int amountToDeposit)
        {
            account.balance += amountToDeposit;
            Console.WriteLine($"Amount {amountToDeposit} is deposited in account title {account.name}\nNew balance is {account.balance}");
        }
        public void WithdrawFromAccount(BankAccount account, int amountToWithDraw)
        {
            if (amountToWithDraw <= account.balance)
            {
                account.balance -= amountToWithDraw;
                Console.WriteLine($"Amount {amountToWithDraw} is widthdrawn from account title {account.name}\nRemaining balance is {account.balance}");
            }
            else
            {
                Console.WriteLine($"Insufficent Balance");
            }
            }

    }
    class Program
    {
        static void Main(string[] args)
        {
            //BankAccount Haris =new BankAccount (123, "Haris", 100);
            //BankAccount Mohsin = new BankAccount(7463, "Chishti", 1000000);
            //Haris.Deposit(200);
            //Mohsin.Deposit(200000);
            //Haris.DisplayAccountInfo();
            Bank HBL = new Bank();
            SavingsAccount Haris = new SavingsAccount(1234, "Haris", 500, 0.11);
            CheckingAccount Mohsin = new CheckingAccount(1234, "mohsin", 500);
            HBL.AddAccount(Haris);
            HBL.AddAccount(Mohsin);
            foreach(BankAccount account in HBL.BankAccounts)
            {
                Console.WriteLine(account.name);
            }



            Console.ReadKey();
        }
    }
}