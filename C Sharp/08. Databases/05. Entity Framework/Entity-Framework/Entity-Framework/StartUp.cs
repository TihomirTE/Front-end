using Entity_Framework.Nortwind;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Framework
{
    public class StartUp
    {
        public static void Main()
        {
            // Task 1
            using (var dbContext = new NorthwndEntities())
            {
                var categories = dbContext
                    .Categories
                    .Where(c => c.CategoryID == 1)
                    .Select(c => c.CategoryName)
                    .ToList();

                Console.WriteLine(categories.FirstOrDefault());
            }

            // Task 2
            CRUD_Operations.AddCustomer("DB", "Telerik", "Gosho", "Merindjei", "Mladost",
                                        "Sofia", "Sofia", "1715", "0888121212", "1234");

        }
    }
}
