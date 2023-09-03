using System;
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
                Console.WriteLine("8. Consultar los tres primeros clientes en la región WA");
                Console.WriteLine("9. Consultar los productos ordenados por nombre");
                Console.WriteLine("10. Consultar los productos ordenados por stock");
                Console.WriteLine("11. Consultar las categorias asociadas a los productos");
                Console.WriteLine("12. Consultar el primer producto");
                Console.WriteLine("13. Consultar clientes con ordenes asociadas");
                Console.WriteLine("14. Salir");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Consultas.ConsultarClientes();
                        break;
                    case "2":
                        Consultas.ConsultarProductosSinStock();
                        break;
                    case "3":
                        Consultas.ConsultarProductosConStockMayor3();
                        break;
                    case "4":
                        Consultas.ConsultarClientesEnWA();
                        break;
                    case "5":
                        Consultas.ConsultarProducto789();
                        break;
                    case "6":
                        Consultas.ConsultarNombresClientes();
                        break;
                    case "7":
                        Consultas.ConsultarClientesConPedidosEnWA();
                        break;
                    case "8":
                        Consultas.ConsultarPrimeros3ClientesEnWA();
                        break;
                    case "9":
                        Consultas.ConsultarProductosOrdenadosPorNombre();
                        break;
                    case "10":
                        Consultas.ConsultarProductosOrdenadosPorStock();
                        break;
                    case "11":
                        Consultas.ConsultarCategoriasAsociadasProductos();
                        break;
                    case "12":
                        Consultas.ConsultarPrimerProducto();
                        break;
                    case "13":
                        Consultas.ConsultarClientesConOrdenes();
                        break;
                    case "14":
                        Console.WriteLine("Saliendo...");
                        return;
                    default:
                        Console.WriteLine("Opción no válida. Intente nuevamente.");
                        break;
                }
            }
        }
    }
}
