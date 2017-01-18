namespace BankAccounts.Interfaces
{
    interface IAcounts
    {
        // properties
        
        decimal Balance { get; }

        decimal InterestRate { get; }

        decimal CalculateInterest(int months);
    }
}
