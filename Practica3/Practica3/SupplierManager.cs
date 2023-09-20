using Practica.Entities;
using Practica3.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Practica3.Logic
{
    public class SupplierManager
    {
        private readonly SupplierLogic _supplierLogic;

        public SupplierManager()
        {
            _supplierLogic = new SupplierLogic();
        }

        public void ManageSuppliers()
        {
            while (true)
            {
                Console.WriteLine("Seleccione una opción para Suppliers:");
                Console.WriteLine("1. Mostrar todos");
                Console.WriteLine("2. Agregar nuevo");
                Console.WriteLine("3. Actualizar");
                Console.WriteLine("4. Borrar");
                Console.WriteLine("5. Volver al menú principal");

                int opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        ShowAllSuppliers();
                        break;
                    case 2:
                        AddSupplier();
                        break;
                    case 3:
                        UpdateSupplier();
                        break;
                    case 4:
                        DeleteSupplier();
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Opción no válida. Intente nuevamente.");
                        break;
                }
            }
        }

        public void ShowAllSuppliers()
        {
            List<SuppliersDTO> suppliers = _supplierLogic.GetAll();

            foreach (var supplier in suppliers)
            {
                Console.WriteLine($"ID: {supplier.SupplierID}");
                Console.WriteLine($"Nombre de la empresa: {supplier.CompanyName}");
                Console.WriteLine($"Nombre de contacto: {supplier.ContactName}");
                Console.WriteLine($"Título de contacto: {supplier.ContactTitle}");
                Console.WriteLine($"Dirección: {supplier.Address}");
                Console.WriteLine($"Ciudad: {supplier.City}");
                Console.WriteLine($"Código Postal: {supplier.PostalCode}");
                Console.WriteLine($"País: {supplier.Country}");
                Console.WriteLine($"Teléfono: {supplier.Phone}");
                Console.WriteLine();
            }
        }

        public void AddSupplier()
        {
            SuppliersDTO newSupplierDTO = new SuppliersDTO();

            Console.Write("Ingrese el nombre de la empresa: ");
            newSupplierDTO.CompanyName = Console.ReadLine();
            Console.Write("Ingrese el nombre de contacto: ");
            newSupplierDTO.ContactName = Console.ReadLine();
            Console.Write("Ingrese el título de contacto: ");
            newSupplierDTO.ContactTitle = Console.ReadLine();
            Console.Write("Ingrese la dirección: ");
            newSupplierDTO.Address = Console.ReadLine();
            Console.Write("Ingrese la ciudad: ");
            newSupplierDTO.City = Console.ReadLine();
            Console.Write("Ingrese la región: ");
            newSupplierDTO.Region = Console.ReadLine();
            Console.Write("Ingrese el código postal: ");
            newSupplierDTO.PostalCode = Console.ReadLine();
            Console.Write("Ingrese el país: ");
            newSupplierDTO.Country = Console.ReadLine();
            Console.Write("Ingrese el teléfono: ");
            newSupplierDTO.Phone = Console.ReadLine();
            Console.Write("Ingrese el fax: ");
            newSupplierDTO.Fax = Console.ReadLine();    

            try
            {
                _supplierLogic.Add(newSupplierDTO);
                Console.WriteLine("Proveedor agregado exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al agregar el proveedor: {ex.Message}");
            }
        }

        public void UpdateSupplier()
        {
            ShowAllSuppliers();
            SuppliersDTO updatedSupplierDTO = new SuppliersDTO();
            Console.Write("Ingrese el ID del proveedor a actualizar: ");
            int supplierIDToUpdate = int.Parse(Console.ReadLine());

            SuppliersDTO supplierToUpdate = _supplierLogic.GetById(supplierIDToUpdate);


                Console.WriteLine($"Proveedor actual:");
                Console.WriteLine($"ID: {supplierToUpdate.SupplierID}");
                Console.WriteLine($"Nombre de la empresa: {supplierToUpdate.CompanyName}");
                Console.WriteLine($"Nombre de contacto: {supplierToUpdate.ContactName}");
                Console.WriteLine($"Título de contacto: {supplierToUpdate.ContactTitle}");
                Console.WriteLine($"Dirección: {supplierToUpdate.Address}");
                Console.WriteLine($"Ciudad: {supplierToUpdate.City}");
                Console.WriteLine($"Código Postal: {supplierToUpdate.PostalCode}");
                Console.WriteLine($"País: {supplierToUpdate.Country}");
                Console.WriteLine($"Teléfono: {supplierToUpdate.Phone}");
                Console.WriteLine($"Region: {supplierToUpdate.Region}");
                Console.WriteLine($"Fax: {supplierToUpdate.Fax}");

                Console.WriteLine("Ingrese la nueva region: ");
                updatedSupplierDTO.Region = Console.ReadLine();
                Console.WriteLine("Ingrese el nuevo fax: ");
                updatedSupplierDTO.Fax = Console.ReadLine();

                try
                {
                    _supplierLogic.Update(new SuppliersDTO
                    {
                        SupplierID = supplierToUpdate.SupplierID,
                        CompanyName = supplierToUpdate.CompanyName,
                        ContactName = supplierToUpdate.ContactName,
                        ContactTitle = supplierToUpdate.ContactTitle,
                        Address = supplierToUpdate.Address,
                        City = supplierToUpdate.City,
                        PostalCode = supplierToUpdate.PostalCode,
                        Country = supplierToUpdate.Country,
                        Region = updatedSupplierDTO.Region,
                        Phone = supplierToUpdate.Phone,
                        Fax = updatedSupplierDTO.Fax,
                    });
                    Console.WriteLine("Proveedor actualizado exitosamente.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al actualizar el proveedor: {ex.Message}");
                }
        }

        public void DeleteSupplier()
        {
            ShowAllSuppliers();

            Console.Write("Ingrese el ID del proveedor a eliminar: ");
            int supplierIDToDelete = int.Parse(Console.ReadLine());

            SuppliersDTO supplierToDelete = _supplierLogic.GetById(supplierIDToDelete);

            if (supplierToDelete != null)
            {
                Console.WriteLine($"Proveedor a eliminar:");
                Console.WriteLine($"ID: {supplierToDelete.SupplierID}");
                Console.WriteLine($"Nombre de la empresa: {supplierToDelete.CompanyName}");
                Console.WriteLine($"Nombre de contacto: {supplierToDelete.ContactName}");
                Console.WriteLine($"Título de contacto: {supplierToDelete.ContactTitle}");
                Console.WriteLine($"Dirección: {supplierToDelete.Address}");
                Console.WriteLine($"Ciudad: {supplierToDelete.City}");
                Console.WriteLine($"Código Postal: {supplierToDelete.PostalCode}");
                Console.WriteLine($"País: {supplierToDelete.Country}");
                Console.WriteLine($"Teléfono: {supplierToDelete.Phone}");
                Console.WriteLine();

                Console.Write("¿Está seguro de que desea eliminar este proveedor? (si/no): ");
                string confirmacion = Console.ReadLine();

                if (confirmacion.Equals("si", StringComparison.OrdinalIgnoreCase))
                {
                    _supplierLogic.Delete(supplierToDelete.SupplierID);
                    Console.WriteLine("Proveedor eliminado exitosamente.");
                }
                else if (confirmacion.Equals("no", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Eliminación cancelada.");
                }
                else
                {
                    Console.WriteLine("Respuesta no validada");
                }
            }
            else
            {
                Console.WriteLine($"No se encontró ningún proveedor con el ID {supplierIDToDelete}.");
            }
        }
    }
}