using Practica4.Entities;
using System;
using System.Collections.Generic;

namespace Practica4.Logic
{
    public class Consultas
    {
        public static void ConsultarClientes()
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

        public static void ConsultarProductosSinStock()
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

        public static void ConsultarProductosConStockMayor3()
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

        public static void ConsultarClientesEnWA()
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

        public static void ConsultarProducto789()
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

        public static void ConsultarNombresClientes()
        {
            CustomerLogic customerLogic = new CustomerLogic();

            var customerNamesFormatted = customerLogic.GetCustomerNames();

            Console.WriteLine("Nombres de clientes en mayuscula y minusculas:");
            foreach (var formattedName in customerNamesFormatted)
            {
                Console.WriteLine(formattedName);
            }
        }

        public static void ConsultarClientesConPedidosEnWA()
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

        public static void ConsultarPrimeros3ClientesEnWA()
        {
            CustomerLogic customerLogic = new CustomerLogic();

            var first3CustomersInWA = customerLogic.Getfirst3CustomersInWA();

            Console.WriteLine("Primeros 3 clientes en la región WA:");
            foreach (var customer in first3CustomersInWA)
            {
                Console.WriteLine($"Customer ID: {customer.CustomerID}");
                Console.WriteLine($"Company Name: {customer.CompanyName}");
                Console.WriteLine($"City: {customer.City}");
                Console.WriteLine($"Region: {customer.Region}");
                Console.WriteLine($"Country: {customer.Country}");
                Console.WriteLine();
            }
        }

        public static void ConsultarProductosOrdenadosPorNombre()
        {
            ProductsLogic productsLogic = new ProductsLogic();

            var productsOrderedByName = productsLogic.GetProductsOrderedByName();

            Console.WriteLine("Productos ordenados por nombre:");
            foreach (var product in productsOrderedByName)
            {
                Console.WriteLine($"Product ID: {product.ProductID}");
                Console.WriteLine($"Product Name: {product.ProductName}");
                Console.WriteLine();
            }
        }

        public static void ConsultarProductosOrdenadosPorStock()
        {
            ProductsLogic productsLogic = new ProductsLogic();

            var productsOrderedByStock = productsLogic.GetproductOrderedByStock();

            Console.WriteLine("Productos ordenados por stock:");
            foreach (var product in productsOrderedByStock)
            {
                Console.WriteLine($"Product ID: {product.ProductID}");
                Console.WriteLine($"Product Name: {product.ProductName}");
                Console.WriteLine($"Stock: {product.UnitsInStock}");
                Console.WriteLine();
            }
        }

        public static void ConsultarCategoriasAsociadasProductos()
        {
            CategoryLogic categoryLogic = new CategoryLogic();

            List<Categories> categoriasAsociadas = categoryLogic.GetCategoriesAssociatedWithProducts();

            Console.WriteLine("Categorías asociadas a productos:");
            foreach (var categoria in categoriasAsociadas)
            {
                Console.WriteLine($"ID: {categoria.CategoryID}, Nombre: {categoria.CategoryName}");
            }

            Console.ReadLine();
        }

        public static void ConsultarPrimerProducto()
        {
            ProductsLogic productsLogic = new ProductsLogic();

            Products primerProducto = productsLogic.GetFirstProduct();

            if (primerProducto != null)
            {
                Console.WriteLine("Primer Producto:");
                Console.WriteLine($"Product ID: {primerProducto.ProductID}");
                Console.WriteLine($"Product Name: {primerProducto.ProductName}");
            }
            else
            {
                Console.WriteLine("No se encontraron productos.");
            }

            Console.ReadLine();
        }

        public static void ConsultarClientesConOrdenes()
        {
            CustomerOrderLogic customerOrderLogic = new CustomerOrderLogic();

            List<Customers> customers = customerOrderLogic.GetCustomersWithOrder();

            Console.WriteLine("Clientes con al menos una orden:");
            foreach (var customer in customers)
            {
                Console.WriteLine($"Customer ID: {customer.CustomerID}");
                Console.WriteLine($"Customer Name: {customer.ContactName}");
                Console.WriteLine();
            }
        }
    }
}
