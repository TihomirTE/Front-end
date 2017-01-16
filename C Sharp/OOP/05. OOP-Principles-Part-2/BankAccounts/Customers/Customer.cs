namespace BankAccounts.Customers
{
    using System;

    public class Customer
    {
        // constructor
        public Customer(string customerName, CustomerType customerType)
        {
            this.CustomerName = customerName;
            this.CustomerType = customerType;
        }

        // properties
         public string CustomerName { get; set; }

        public CustomerType CustomerType { get; set; }
    }
}
