using Entity_Framework.Nortwind;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Framework
{
    public class CRUD_Operations
    {
        public static string AddCustomer(string customerId, string companyName, string contactName, string contactTitle,
            string address, string city, string region, string postalCode, string phone, string fax)
        {
            var northwind = new NorthwndEntities();
            var customer = new Customer()
            {
                CustomerID = customerId,
                CompanyName = companyName,
                ContactName = contactName,
                ContactTitle = contactTitle,
                Address = address,
                City = city,
                Region = region,
                PostalCode = postalCode,
                Phone = phone,
                Fax = fax,
            };

            northwind.Customers.Add(customer);
            northwind.SaveChanges();
            return customer.CustomerID;
        }
    }
}
