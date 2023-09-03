using Practica4.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica4.Logic
{
    public class CustomerLogic : BaseLogic
    {
        public Customers GetCustomerById(String customerID)
        {
            string upperCaseCustomerID = customerID.ToUpper();

            return _context.Customers.FirstOrDefault(customer => customer.CustomerID == upperCaseCustomerID);
        }

        public List<Customers> GetCustomerInWA()
        {
            var customersInWA = _context.Customers
                .Where(c => c.Region == "WA")
                .ToList();

            return customersInWA;
        }

        public List<string> GetCustomerNames()
        {
            var customerNames = _context.Customers.Select(customer => customer.CompanyName).ToList();

            var namesCombined = customerNames.Select(name => $"{name.ToUpper()} | {name.ToLower()}").ToList();

            return namesCombined;
        }
    }
}
