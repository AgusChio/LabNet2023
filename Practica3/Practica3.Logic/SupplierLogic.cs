using Practica.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Practica3.Entities.DTO;


namespace Practica3.Logic
{
    public class SupplierLogic : BaseLogic, IRepository<SuppliersDTO>
    {
        public List<SuppliersDTO> GetAll()
        {
            var suppliers = _context.Suppliers.ToList();
            var suppliersDTO = suppliers.Select(supplier => new SuppliersDTO
            {
                SupplierID = supplier.SupplierID,
                CompanyName = supplier.CompanyName,
                ContactName = supplier.ContactName,
                ContactTitle = supplier.ContactTitle,
                Address = supplier.Address,
                City = supplier.City,
                Region = supplier.Region,
                PostalCode = supplier.PostalCode,
                Country = supplier.Country,
                Phone = supplier.Phone,
                Fax = supplier.Fax
            }).ToList();

            return suppliersDTO;
        }

        public void Add(SuppliersDTO newSupplierDTO)
        {
            if (newSupplierDTO == null)
            {
                throw new ArgumentNullException(nameof(newSupplierDTO), "El proveedor no puede ser nulo.");
            }

            if (string.IsNullOrEmpty(newSupplierDTO.CompanyName) || 
                string.IsNullOrEmpty(newSupplierDTO.ContactName) || 
                string.IsNullOrEmpty(newSupplierDTO.ContactTitle) ||
                string.IsNullOrEmpty(newSupplierDTO.Address) ||
                string.IsNullOrEmpty(newSupplierDTO.Region) ||
                string.IsNullOrEmpty(newSupplierDTO.City) || 
                string.IsNullOrEmpty(newSupplierDTO.PostalCode) || 
                string.IsNullOrEmpty(newSupplierDTO.Country) ||
                string.IsNullOrEmpty(newSupplierDTO.Phone) ||
                string.IsNullOrEmpty(newSupplierDTO.Fax))
            {
                throw new ArgumentException("Este campo no puede esatr vacio.", nameof(newSupplierDTO.CompanyName));
            }

            if (!Regex.IsMatch(newSupplierDTO.CompanyName, @"^[A-Za-z\s]+$"))
            {
                throw new ArgumentException("El nombre de la empresa no puede contener números.", nameof(newSupplierDTO.CompanyName));
            }

            if (!Regex.IsMatch(newSupplierDTO.Phone, @"^[0-9]+$"))
            {
                throw new ArgumentException("El número de teléfono solo puede contener dígitos numéricos.", nameof(newSupplierDTO.Phone));
            }


            if (!Regex.IsMatch(newSupplierDTO.PostalCode, @"^[0-9]+$"))
            {
                throw new ArgumentException("El número postal solo puede contener dígitos numéricos.", nameof(newSupplierDTO.PostalCode));
            }

            if (newSupplierDTO.Phone.Length > 24)
            {
                throw new ArgumentException("El número de teléfono no puede tener más de 24 caracteres.", nameof(newSupplierDTO.Phone));
            }

            if (!Regex.IsMatch(newSupplierDTO.Fax, @"^[0-9]+$"))
            {
                throw new ArgumentException("El Fax solo puede contener dígitos numéricos.", nameof(newSupplierDTO.Fax));
            }



            var newSupplier = new Suppliers
            {
                CompanyName = newSupplierDTO.CompanyName,
                ContactName = newSupplierDTO.ContactName,
                ContactTitle = newSupplierDTO.ContactTitle,
                Address = newSupplierDTO.Address,
                City = newSupplierDTO.City,
                Region = newSupplierDTO.Region,
                PostalCode = newSupplierDTO.PostalCode,
                Country = newSupplierDTO.Country,
                Phone = newSupplierDTO.Phone,
                Fax = newSupplierDTO.Fax
            };

            _context.Suppliers.Add(newSupplier);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var supplierAEliminar = _context.Suppliers.Find(id);

            if (supplierAEliminar == null)
            {
                throw new ArgumentException($"No se encontró ningún proveedor con el ID {id} para eliminar.");
            }

            _context.Suppliers.Remove(supplierAEliminar);
            _context.SaveChanges();
        }


        public void Update(SuppliersDTO updatedSupplierDTO)
        {

            var supplierAActualizar = _context.Suppliers.Find(updatedSupplierDTO.SupplierID);


            supplierAActualizar.Region = updatedSupplierDTO?.Region;
            supplierAActualizar.Fax = updatedSupplierDTO?.Fax;


            _context.SaveChanges();
        }

        public SuppliersDTO GetById(int id)
        {
            var supplier = _context.Suppliers.Find(id) ?? throw new ArgumentException($"No se encontró ningún proveedor con el ID {id}.");

            var supplierDTO = new SuppliersDTO
            {
                SupplierID = supplier.SupplierID,
                CompanyName = supplier.CompanyName,
                ContactName = supplier.ContactName,
                ContactTitle = supplier.ContactTitle,
                Address = supplier.Address,
                City = supplier.City,
                Region = supplier.Region,
                PostalCode = supplier.PostalCode,
                Country = supplier.Country,
                Phone = supplier.Phone,
                Fax = supplier.Fax
            };

            return supplierDTO;
        }
    }
}
