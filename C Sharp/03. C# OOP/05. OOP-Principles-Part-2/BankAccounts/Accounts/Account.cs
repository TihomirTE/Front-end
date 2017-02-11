namespace BankAccounts.Accounts
{
    using System;

    using BankAccounts.Customers;
    using BankAccounts.Interfaces;

    public abstract class Account : IAcounts, IDeposit
    {
        // constructor for Account class
        public Account(Customer customer, decimal balance, decimal interestRate)
        {
            this.Customer = customer;
            this.Balance = balance;
            this.InterestRate = interestRate;
        }

        // properties
        public decimal Balance { get; protected set; }

        public Customer Customer { get; protected set; }

        public decimal InterestRate { get; protected set; }


        // virtual method for calculation (can be overriden from children classes)
        public virtual decimal CalculateInterest(int months)
        {
            return ((this.InterestRate / 100) * this.Balance) * months ;
        }

        // method for calculation of the balance from deposit money ->
        // it is inherit from all account's children
        public void DepositMoney(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("The amount must be greater than 0");
            }

            this.Balance += amount;
        }
    }
}
