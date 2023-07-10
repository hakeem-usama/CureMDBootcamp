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
        public int balance;

        public BankAccount(int ACCOUNTnUMBER, string NAME, int Balance)
            {
            accountNumber = ACCOUNTnUMBER;
            name = NAME;
            balance = Balance;
            }
        public int Deposit(int amount)
        {
            balance += amount;
            Console.WriteLine($"Amount {amount} has been desposited in your account");
            Console.WriteLine($"Your New Balance is {balance} ");
            return balance;
        }
        public int Withdraw(int amount)
        {
            balance-= amount;
            Console.WriteLine($"Amount {amount} has been desposited in your account");
            Console.WriteLine($"Your Remaining Balance is {balance} ");
            return balance;
        }
        public void AccountInfo()
        {
            Console.WriteLine($"Account Info is: \nAccount Number :{accountNumber}\n Name: {name}\n Current Balance: {balance} ");

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
