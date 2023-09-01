
using Practica.Entities;
using Practica3.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica3.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SupplierManager suppliersManager = new SupplierManager();
            ShippersManager shippersManager = new ShippersManager();
            while (true)
            {
                Console.WriteLine("Seleccione una opción:");
                Console.WriteLine("1. Trabajar con Suppliers");
                Console.WriteLine("2. Trabajar con Shippers");
                Console.WriteLine("3. Salir");

                int opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        suppliersManager.ManageSuppliers();
                        break;
                    case 2:
                        shippersManager.ManageShippers();
                        break;
                    case 3:
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
