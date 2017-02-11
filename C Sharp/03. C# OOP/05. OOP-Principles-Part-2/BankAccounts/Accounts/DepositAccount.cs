namespace BankAccounts.Accounts
{
    using System;

    using BankAccounts.Customers;
    using BankAccounts.Interfaces;

    class DepositAccount : Account, IAcounts, IDeposit, IWithDrawMoney
    {
        // constructor
        public DepositAccount(Customer customer, decimal balance, decimal interestRate) 
            : base(customer, balance, interestRate)
        {
        }

        // calculation method
        public override decimal CalculateInterest(int months)
        {
            if (this.Balance > 0 && this.Balance < 1000)
            {
                return 0;
            }

            return base.CalculateInterest(months);
        }

        // method for the calculation of the current balance from withdrawing money
        public decimal WithDrawMoney(decimal amount)
        {
            if (amount > this.Balance)
            {
                throw new ArgumentException("The amount of withdraw money is greater than the balance");
            }

            return this.Balance -= amount;
        }
    }
}
