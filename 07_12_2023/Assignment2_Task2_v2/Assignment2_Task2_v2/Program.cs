using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_Task2_v2
{
    public interface IBankAccount
    {
        void Deposit();
        void Withdraw();
    }
    abstract class BankAccount : IBankAccount
    {

        //private string ACCOUNTNUMBER;
        //public string accountNumber
        //{
        //    get { return ACCOUNTNUMBER; } 
        //    set { accountNumber = ACCOUNTNUMBER; } 
        //}
        public string accountNumber { set; get; }
        public string name { set; get; }        
        public double balance { set; get; }
        public double amount { set; get; }
        public BankAccount(string AccountNumber, string Name, double Balance)
        {
            accountNumber = AccountNumber;
            name = Name;
            balance = Balance;
        }
        public virtual void Deposit()
        {
            Console.WriteLine($"Enter Amount to Deposit\n");
            amount = double.Parse(Console.ReadLine());
            balance += amount;
            Console.WriteLine($"Amount {amount} has been desposited in your account titled as:{name}");
            Console.WriteLine($"Your New Balance is {balance} ");

        }
        public virtual void Withdraw()
        {
            Console.WriteLine($"Enter Amount to Withdraw\n");
            amount = double.Parse(Console.ReadLine());
            if (amount <= balance)
            {
                balance -= amount;
                Console.WriteLine($"Amount {amount} has been desposited in your account titled as: {name}");
                Console.WriteLine($"Your Remaining Balance is {balance} ");
            }
            else
            {
                Console.WriteLine($"Low Balance. Enter Valid amount");
            }
        }
        public abstract void DisplayAccountInfo();
        

    }
    class SavingsAccount : BankAccount
    {
        public double interestrate { set; get; }
       public  SavingsAccount(string AccountNumber, string Name, double Balance, double Interestrate) : base(AccountNumber, Name, Balance)
        {
            interestrate = Interestrate;
        }
        public override void Deposit()
        {
            Console.WriteLine($"Enter Amount to Deposit\n");
            amount = double.Parse(Console.ReadLine());
            balance =amount+amount*interestrate;
            Console.WriteLine($"Amount {amount} has been desposited in your account");
            Console.WriteLine($"Your New Balance is {balance} ");

        }
        public override void DisplayAccountInfo()
        {
            Console.WriteLine($"Your Account info is given as: ");
            Console.WriteLine($" \nAccount Number :{accountNumber}\n Name: {name}\n Current Balance: {balance} ");
        }
    }
    class CheckingAccount : BankAccount
    {
        public CheckingAccount(string AccountNumber, string Name, double Balance) : base(AccountNumber, Name, Balance)
        { }
        public override void Withdraw()
        {
            Console.WriteLine($"Enter Amount to Withdraw\n");
            amount = double.Parse(Console.ReadLine());
            if (amount <= balance)
            {
                balance -= amount;
                Console.WriteLine($"Amount {amount} has been withdrawn your account");
                Console.WriteLine($"Your Remaining Balance is {balance} ");
            }
            else
            {
                Console.WriteLine($"Low Balance. Enter Valid amount");
            }
        }
        public override void DisplayAccountInfo()
        {
            Console.WriteLine($"Your Account info is: ");
            Console.WriteLine($" \nAccount Number :{accountNumber}\n Name: {name}\n Current Balance: {balance} ");
        }
    }
    class Bank
    {
       public List<BankAccount> BankAccounts { set; get; }
        public Bank()
        {
            BankAccounts = new List<BankAccount>();
        }
        public void addAccount(BankAccount account)
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
            Bank UBL=new Bank();
            SavingsAccount Account1 = new SavingsAccount("ABC123","Usama",0,0.11);
            CheckingAccount Account2 = new CheckingAccount("XYZ246", "Hameed", 100);
            UBL.addAccount(Account1);
            UBL.addAccount(Account2);
            Account1.Deposit();
            Account2.Deposit();
            Account2.Withdraw();
            UBL.DepositToAccount(Account1, 50000);
            UBL.WithdrawFromAccount(Account1, 25000);
            foreach(BankAccount account in UBL.BankAccounts)
            {
                Console.WriteLine(account.name);
                Console.WriteLine(account.accountNumber);
                Console.WriteLine(account.balance);
                Console.WriteLine(account);
            }
            Console.ReadKey();
        }
    }
}
