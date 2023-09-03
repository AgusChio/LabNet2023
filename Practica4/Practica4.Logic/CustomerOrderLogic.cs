using Practica4.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Practica4.Logic
{
    public class CustomerOrderLogic : BaseLogic
    {
        public List<Customers> GetCustomersInWAWthOrdersAfter1997()
        {
            var customersInWA = _context.Customers
                .Where(c => c.Region == "WA")
                .ToList();

            var ordersAfter1997 = _context.Orders
                .Where(o => o.OrderDate > new DateTime(1997, 1, 1))
                .ToList();

            var result = customersInWA
                .Join(
                    ordersAfter1997,
                    customer => customer.CustomerID,
                    order => order.CustomerID,
                    (customer, order) => customer
                )
                .ToList();

            return result;
        }

        public List<Customers> GetCustomersWithOrder()
        {
            var customersWithOrder = _context.Customers
            .Where(c => _context.Orders.Any(o => o.CustomerID == c.CustomerID))
            .ToList();

            return customersWithOrder;
        }
    }

}
