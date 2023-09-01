using Practica.Entities;
using System;
using System.Collections.Generic;

namespace Practica3.Logic
{
    public class ShippersManager
    {
        private readonly ShippersLogic _shippersLogic;

        public ShippersManager()
        {
            _shippersLogic = new ShippersLogic();
        }

        public void ManageShippers()
        {
            List<Shippers> shippers = new List<Shippers>();

            while (true)
            {
                Console.WriteLine("Seleccione una opción para Shippers:");
                Console.WriteLine("1. Mostrar todos");
                Console.WriteLine("2. Agregar nuevo");
                Console.WriteLine("3. Actualizar");
                Console.WriteLine("4. Borrar");
                Console.WriteLine("5. Volver al menú principal");
                Console.WriteLine("6. Salir");

                int opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        ShowAllShippers();
                        break;
                    case 2:
                        AddShipper();
                        break;
                    case 3:
                        UpdateShipper();
                        break;
                    case 4:
                        DeleteShipper();
                        break;
                    case 5:
                        return;
                    case 6:
                        Console.WriteLine("Saliendo...");
                        return;
                    default:
                        Console.WriteLine("Opción no válida. Intente nuevamente.");
                        break;
                }
            }
        }

        public void ShowAllShippers()
        {
            List<Shippers> shippers = _shippersLogic.GetAll();
            foreach (var shipper in shippers)
            {
                Console.WriteLine($"{shipper.ShipperID}: {shipper.CompanyName}");
            }
        }

        public void AddShipper()
        {
            Shippers newShipper = new Shippers();
            Console.Write("Ingrese el nombre de la empresa: ");
            newShipper.CompanyName = Console.ReadLine();
            Console.Write("Ingrese el número de teléfono: ");
            newShipper.Phone = Console.ReadLine();

            try
            {
                _shippersLogic.Add(newShipper);
                Console.WriteLine("Transportista agregado exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al agregar el transportista: {ex.Message}");
            }
        }
        public void UpdateShipper()
        {
            List<Shippers> shippers = _shippersLogic.GetAll();
            foreach (var shipper in shippers)
            {
                Console.WriteLine($"{shipper.ShipperID}: {shipper.CompanyName}");
            }

            Console.Write("Ingrese el ID del transportista a actualizar: ");
            if (!int.TryParse(Console.ReadLine(), out int shipperIDToUpdate))
            {
                Console.WriteLine("ID no válido. Intente nuevamente.");
                return;
            }

            var shipperToUpdate = shippers.Find(s => s.ShipperID == shipperIDToUpdate);

            if (shipperToUpdate == null)
            {
                Console.WriteLine($"No se encontró ningún transportista con el ID {shipperIDToUpdate}.");
                return;
            }

            Console.WriteLine($"Transportista encontrado: {shipperToUpdate.CompanyName}");
            Console.Write("Ingrese el nuevo nombre de la empresa: ");
            shipperToUpdate.CompanyName = Console.ReadLine();
            Console.Write("Ingrese el nuevo número de teléfono: ");
            shipperToUpdate.Phone = Console.ReadLine();

            Console.Write("¿Está seguro de actualizar este transportista? (si/no): ");
            string confirmacionActualizar = Console.ReadLine();

            if (confirmacionActualizar.Equals("si", StringComparison.OrdinalIgnoreCase))
            {
                try
                {
                    _shippersLogic.Update(shipperToUpdate);
                    Console.WriteLine("Transportista actualizado exitosamente.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al actualizar el transportista: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Actualización cancelada.");
            }
        }

        public void DeleteShipper()
        {
            List<Shippers> shippers = _shippersLogic.GetAll();
            foreach (var shipper in shippers)
            {
                Console.WriteLine($"{shipper.ShipperID}: {shipper.CompanyName}");
            }

            Console.Write("Ingrese el ID del transportista a eliminar: ");
            if (!int.TryParse(Console.ReadLine(), out int shipperIDToDelete))
            {
                Console.WriteLine("ID no válido. Intente nuevamente.");
                return;
            }

            var shipperToDelete = shippers.Find(s => s.ShipperID == shipperIDToDelete);

            if (shipperToDelete == null)
            {
                Console.WriteLine($"No se encontró ningún transportista con el ID {shipperIDToDelete}.");
                return;
            }

            Console.WriteLine($"ID: {shipperToDelete.ShipperID}");
            Console.WriteLine($"Nombre de la empresa: {shipperToDelete.CompanyName}");
            Console.WriteLine($"Teléfono: {shipperToDelete.Phone}");

            Console.Write("¿Está seguro de que desea eliminar este transportista? (si/no): ");
            string confirmacion = Console.ReadLine();

            if (confirmacion.Equals("si", StringComparison.OrdinalIgnoreCase))
            {
                try
                {
                    _shippersLogic.Delete(shipperIDToDelete);
                    Console.WriteLine("Transportista eliminado exitosamente.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al eliminar el transportista: {ex.Message}");
                }
            }
            else if (confirmacion.Equals("no", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Eliminación cancelada.");
            }
            else
            {
                Console.WriteLine("Respuesta no válida. Por favor, ingrese 'si' o 'no'.");
            }
        }
    }
}
