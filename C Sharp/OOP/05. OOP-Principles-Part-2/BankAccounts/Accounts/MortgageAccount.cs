namespace BankAccounts.Accounts
{
    using BankAccounts.Customers;
    using BankAccounts.Interfaces;

    class MortgageAccount : Account, IAcounts, IDeposit
    {
        // constructor -> inherit from Account.class
        public MortgageAccount(Customer customer, decimal balance, decimal interestRate) 
            : base(customer, balance, interestRate)
        {
        }

        // Override method for calculation interest rate
        public override decimal CalculateInterest(int months)
        {
            if ((months > 0 && months <= 12) && (Customer.CustomerType == CustomerType.Company))
            {
                return base.CalculateInterest(months) / 2;
            }
            if ((months > 0 && months <= 6) && (Customer.CustomerType == CustomerType.Individual))
            {
                return 0;
            }

            return base.CalculateInterest(months);
        }

    }
}
