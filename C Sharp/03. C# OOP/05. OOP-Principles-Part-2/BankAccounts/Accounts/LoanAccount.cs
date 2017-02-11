namespace BankAccounts.Accounts
{
    using System;

    using BankAccounts.Customers;
    using BankAccounts.Interfaces;

    class LoanAccount : Account, IAcounts, IDeposit
    {
        // constructor
        public LoanAccount(Customer customer, decimal balance, decimal interestRate) 
            : base(customer, balance, interestRate)
        {
        }

        // calculation method
        public override decimal CalculateInterest(int months)
        {
            if (months <= 0)
            {
                throw new ArgumentException("Montths must be positive value");
            }

            if (this.Customer.CustomerType == CustomerType.Company && months <= 2)
            {
                return 0;
            }

            if (this.Customer.CustomerType == CustomerType.Individual && months <= 3)
            {
                return 0;
            }

            return base.CalculateInterest(months);
        }
    }
}
