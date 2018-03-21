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

        public static Customer GetCustomerById(NorthwndEntities northwind, string customerId)
        {
            var customer = northwind.Customers.FirstOrDefault(c => c.CustomerID == customerId);

            return customer;
        }

        public static void ModifyCompanyName(string customerId, string companyName)
        {
            var northwind = new NorthwndEntities();
            var customer = GetCustomerById(northwind, customerId);
            customer.CompanyName = companyName;
            northwind.SaveChanges();
        }

        public static void DeleteCustomer(string customerId)
        {
            var northwind = new NorthwndEntities();
            var customer = GetCustomerById(northwind, customerId);
            northwind.Customers.Remove(customer);
            northwind.SaveChanges();
        }
    }
}
