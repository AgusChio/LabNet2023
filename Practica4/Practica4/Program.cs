using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Practica4.Entities;
using Practica4.Logic;

namespace Practica4.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Seleccione una opción:");
                Console.WriteLine("1. Consultar clientes por ID");
                Console.WriteLine("2. Consultar productos sin stock");
                Console.WriteLine("3. Consultar productos con stock mayor a 3 unidades");
                Console.WriteLine("4. Consultar clientes que están en la región WA");
                Console.WriteLine("5. Consultar producto con ID 789");
                Console.WriteLine("6. Consultar los nombres de los clientes en minuscula y mayuscula");
                Console.WriteLine("7. Consultar clientes con pedidos después de 01/01/1997 en la región WA");
                Console.WriteLine("8. Salir");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        ConsultarClientes();
                        break;
                    case "2":
                        ConsultarProductosSinStock();
                        break;
                    case "3":
                        ConsultarProductosConStockMayor3();
                        break;
                    case "4":
                        ConsultarClientesEnWA();
                        break;
                    case "5":
                        ConsultarProducto789();
                        break;
                    case "6":
                        ConsultarNombresClientes();
                        break;
                    case "7":
                        ConsultarClientesConPedidosEnWA();
                        break;
                    case "8":
                        Console.WriteLine("Saliendo...");
                        return;
                    default:
                        Console.WriteLine("Opción no válida. Intente nuevamente.");
                        break;
                }
            }
        }

        static void ConsultarClientes()
        {
            CustomerLogic customerLogic = new CustomerLogic();

            Console.Write("Ingrese el CustomerID del cliente que desea buscar: ");
            string customerIdToFind = Console.ReadLine().ToUpper();

            var customer = customerLogic.GetCustomerById(customerIdToFind);

            if (customer != null)
            {
                Console.WriteLine($"Customer ID: {customer.CustomerID}");
                Console.WriteLine($"Company Name: {customer.CompanyName}");
                Console.WriteLine($"Contact Title: {customer.ContactTitle}");
                Console.WriteLine($"Address: {customer.Address}");
                Console.WriteLine($"City: {customer.City}");
                Console.WriteLine($"Region: {customer.Region}");
                Console.WriteLine($"PostalCode: {customer.PostalCode}");
                Console.WriteLine($"Country: {customer.Country}");
                Console.WriteLine($"Phone: {customer.Phone}");
                Console.WriteLine($"Fax: {customer.Fax}");
            }
            else
            {
                Console.WriteLine($"No se encontró ningún cliente con el ID {customerIdToFind}.");
            }
            Console.Write("¿Desea buscar otro cliente? (si/no): ");
            string respuesta = Console.ReadLine();

            if (!respuesta.Equals("si", StringComparison.OrdinalIgnoreCase))
            {
                return;
            }
        }

        static void ConsultarProductosSinStock()
        {
            ProductsLogic productsLogic = new ProductsLogic();

            var productsWithoutStock = productsLogic.GetProductsWithoutStock();

            Console.WriteLine("Productos sin stock:");
            foreach (var product in productsWithoutStock)
            {
                Console.WriteLine($"Product ID: {product.ProductID}");
                Console.WriteLine($"Product Name: {product.ProductName}");
                Console.WriteLine($"Stock: {product.UnitsInStock}");
                Console.WriteLine();
            }
        }

        static void ConsultarProductosConStockMayor3()
        {
            ProductsLogic productsLogic = new ProductsLogic();

            var productsWithAdequateStock = productsLogic.SearchProductsWithAdequateStock();

            Console.WriteLine("Productos con stock mayor a 3 unidades:");
            foreach (var product in productsWithAdequateStock)
            {
                Console.WriteLine($"Product ID: {product.ProductID}");
                Console.WriteLine($"Product Name: {product.ProductName}");
                Console.WriteLine($"Stock: {product.UnitsInStock}");
                Console.WriteLine();
            }
        }

        static void ConsultarClientesEnWA()
        {
            CustomerLogic customerLogic = new CustomerLogic();

            var customersInWA = customerLogic.GetCustomerInWA();

            Console.WriteLine("Clientes en la región WA:");
            foreach (var customer in customersInWA)
            {
                Console.WriteLine($"Customer ID: {customer.CustomerID}");
                Console.WriteLine($"Company Name: {customer.CompanyName}");
                Console.WriteLine($"City: {customer.City}");
                Console.WriteLine($"Region: {customer.Region}");
                Console.WriteLine($"Country: {customer.Country}");
                Console.WriteLine();
            }
        }

        static void ConsultarProducto789()
        {
            ProductsLogic productsLogic = new ProductsLogic();

            Products producto789 = productsLogic.GetProductById789();

            if (producto789 != null)
            {
                Console.WriteLine($"Product ID: {producto789.ProductID}");
                Console.WriteLine($"Product Name: {producto789.ProductName}");
            }
            else
            {
                Console.WriteLine($"El producto con ID 789 es nulo");
            }
        }

        static void ConsultarNombresClientes()
        {
            CustomerLogic customerLogic = new CustomerLogic();

            var customerNamesFormatted = customerLogic.GetCustomerNames();

            Console.WriteLine("Nombres de clientes en mayuscula y minusculas:");
            foreach (var formattedName in customerNamesFormatted)
            {
                Console.WriteLine(formattedName);
            }
        }

        static void ConsultarClientesConPedidosEnWA()
        {
            CustomerOrderLogic orderCustomerLogic = new CustomerOrderLogic();

            var customersInWAWithOrders = orderCustomerLogic.GetCustomersInWAWthOrdersAfter1997();

            Console.WriteLine("Clientes en la región WA con pedidos después de 01/01/1997:");
            foreach (var customer in customersInWAWithOrders)
            {
                Console.WriteLine($"Customer ID: {customer.CustomerID}");
                Console.WriteLine($"Company Name: {customer.CompanyName}");
                Console.WriteLine($"City: {customer.City}");
                Console.WriteLine($"Region: {customer.Region}");
                Console.WriteLine($"Country: {customer.Country}");
                Console.WriteLine();
            }
        }
    }
}
