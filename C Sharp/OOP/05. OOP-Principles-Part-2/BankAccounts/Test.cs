namespace BankAccounts
{
    using System;
    using System.Collections.Generic;

    using BankAccounts.Accounts;
    using BankAccounts.Customers;

    public class Test
    {
         

        static void Main()
        {
            int months = 10;

            // List of account with positive interest rate
            Console.WriteLine("Accounts");
            List<Account> customerAccounts = new List<Account>
            {
                new LoanAccount(new Customer("Krajbi OOD", CustomerType.Company), 25000, 4),
                new DepositAccount(new Customer("Ivan", CustomerType.Individual), 1500, 3),
                new MortgageAccount(new Customer("Pesho",  CustomerType.Individual), 50000, 2)
            };

            foreach (var account in customerAccounts)
            {

                Console.WriteLine("{0} with {1} has monthly interest rate of {2} % and {3} lv. for {4} months ",
                    account.Customer.CustomerName, account.GetType().Name,  account.InterestRate, account.CalculateInterest(months), months);
            }
            Console.WriteLine();
            Console.WriteLine("WithDraw method");
            DepositAccount deposit = new DepositAccount(new Customer("Gosho", CustomerType.Individual), 2300, 1);
            Console.WriteLine($"{deposit.Customer.CustomerName} has {deposit.Balance} lv. in the account");
            deposit.WithDrawMoney(1200);
            Console.WriteLine($"{deposit.Customer.CustomerName} has {deposit.Balance} lv. in the account after withdraw money");
            Console.WriteLine();

            Console.WriteLine("Deposit method");
            LoanAccount loan = new LoanAccount(new Customer("IT EOOD", CustomerType.Company), 35000, 2);
            Console.WriteLine($"{loan.Customer.CustomerName} has {loan.Balance} lv. in the account");
            loan.DepositMoney(15000);
            Console.WriteLine($"{loan.Customer.CustomerName} has {loan.Balance} lv. in the account after deposit money");
            Console.WriteLine();

            // WithDraw more money than has in the account
            // Uncomment it for checking
            /*DepositAccount withdraw = new DepositAccount(new Customer("Pesho", CustomerType.Individual), 3000, 1);
            Console.WriteLine($"{withdraw.Customer.CustomerName} has {withdraw.Balance} lv. in the account");
            withdraw.WithDrawMoney(3500);
            Console.WriteLine($"{withdraw.Customer.CustomerName} has {withdraw.Balance} lv. in the account after withdraw money");
            Console.WriteLine();*/
        }
    }
}
