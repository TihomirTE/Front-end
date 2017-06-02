using System;
using Entity_Framework.Nortwind;
using System.Linq;

namespace Entity_Framework
{
    public class StartUp
    {
        public static void Main()
        {
            // Task 1
            var dbContext = new NorthwndEntities();

            var categories = dbContext
                .Categories
                .Where(c => c.CategoryID == 1)
                .Select(c => c.CategoryName)
                .ToList();

            Console.WriteLine(categories.FirstOrDefault());

            // Task 2
            CRUD_Operations.AddCustomer("DataBases", "Pr", "Pesho", "Merindji", "Mladost1",
            "Plovdiv", "Plovdiv", "4001", "0888121213", "12345");

            CRUD_Operations.ModifyCompanyName("DataBases", "Pro");

            CRUD_Operations.DeleteCustomer("BONAP");

            // Task 3
            FindCustomerOrdersByYearAndCountry(dbContext, 1997, "Canada");
        }

        // Task 3
        private static void FindCustomerOrdersByYearAndCountry(NorthwndEntities northwind, int year, string country)
        {
            var countryName = new Country();
            northwind.Orders
                .Where(o => o.OrderDate.Value.Year == year && new Country().Name == country)
                .Select(ord => ord.Customer)
                .GroupBy(c => c.CompanyName)
                .ToList().ForEach(customer => Console.WriteLine("- " + customer.Key));
        }
    }
}
