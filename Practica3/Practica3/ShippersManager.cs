using Practica.Entities;
using Practica3.Entities.DTO;
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
            List<ShippersDTO> shippersDTO = _shippersLogic.GetAll();
            foreach (var shipper in shippersDTO)
            {
                Console.WriteLine($"ID: {shipper.ShipperID}");
                Console.WriteLine($"Nombre de la empresa: {shipper.CompanyName}");
                Console.WriteLine();
            }
        }

        public void AddShipper()
        {
            ShippersDTO newShipperDTO = new ShippersDTO();

            Console.Write("Ingrese el nombre de la empresa: ");
            newShipperDTO.CompanyName = Console.ReadLine();
            Console.Write("Ingrese el número de teléfono: ");
            newShipperDTO.Phone = Console.ReadLine();

            try
            {
                _shippersLogic.Add(newShipperDTO);
                Console.WriteLine("Transportista agregado exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al agregar el transportista: {ex.Message}");
            }
        }


        public void UpdateShipper()
        {
            ShowAllShippers();

            Console.Write("Ingrese el ID del transportista a actualizar: ");
            if (!int.TryParse(Console.ReadLine(), out int shipperIDToUpdate))
            {
                Console.WriteLine("ID no válido. Intente nuevamente.");
                return;
            }

            ShippersDTO updatedShipperDTO = new ShippersDTO();
            updatedShipperDTO.ShipperID = shipperIDToUpdate;

            Console.Write("Ingrese el nuevo nombre de la empresa: ");
            updatedShipperDTO.CompanyName = Console.ReadLine();
            Console.Write("Ingrese el nuevo número de teléfono: ");
            updatedShipperDTO.Phone = Console.ReadLine();

            Console.Write("¿Está seguro de actualizar este transportista? (si/no): ");
            string confirmacionActualizar = Console.ReadLine();

            if (confirmacionActualizar.Equals("si", StringComparison.OrdinalIgnoreCase))
            {
                try
                {
                    _shippersLogic.Update(updatedShipperDTO);
                    Console.WriteLine("Transportista actualizado exitosamente.");
                    ShowAllShippers();
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
            ShowAllShippers();

            Console.Write("Ingrese el ID del transportista a eliminar: ");
            int shipperIDToDelete = int.Parse(Console.ReadLine());

            ShippersDTO dto = _shippersLogic.GetById(shipperIDToDelete);
            Shippers shipperToDelete = new Shippers
            {
                ShipperID = dto.ShipperID,
                CompanyName = dto.CompanyName,
                Phone = dto.Phone
            };

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