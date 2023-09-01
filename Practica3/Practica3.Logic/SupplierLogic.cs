using Practica.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;


namespace Practica3.Logic
{
    public class SupplierLogic : BaseLogic , IRepository<Suppliers>
    {
        public List<Suppliers> GetAll()
        {
            return _context.Suppliers.ToList();
        }

        public void Add(Suppliers newSupplier)
        {
            if (newSupplier == null)
            {
                throw new ArgumentNullException(nameof(newSupplier), "El proveedor no puede ser nulo.");
            }

            if (string.IsNullOrEmpty(newSupplier.CompanyName) || string.IsNullOrEmpty(newSupplier.ContactName) || string.IsNullOrEmpty(newSupplier.ContactTitle) || string.IsNullOrEmpty(newSupplier.Address) || string.IsNullOrEmpty(newSupplier.City) || string.IsNullOrEmpty(newSupplier.PostalCode) || string.IsNullOrEmpty(newSupplier.Country) || string.IsNullOrEmpty(newSupplier.Phone))
            {
                throw new ArgumentException("Este campo no puede esatr vacio.", nameof(newSupplier.CompanyName));
            }

            if (!Regex.IsMatch(newSupplier.CompanyName, @"^[A-Za-z\s]+$"))
            {
                throw new ArgumentException("El nombre de la empresa no puede contener números.", nameof(newSupplier.CompanyName));
            }

            if (!Regex.IsMatch(newSupplier.Phone, @"^[0-9]+$"))
            {
                throw new ArgumentException("El número de teléfono solo puede contener dígitos numéricos.", nameof(newSupplier.Phone));
            }

            if (newSupplier.Phone.Length > 24)
            {
                throw new ArgumentException("El número de teléfono no puede tener más de 24 caracteres.", nameof(newSupplier.Phone));
            }

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


        public void Update(Suppliers supplier)
        {

            if (supplier == null)
            {
                throw new ArgumentNullException(nameof(supplier), "El proveedor no puede ser nulo.");
            }

            var supplierAActualizar = _context.Suppliers.Find(supplier.SupplierID);

            if (supplierAActualizar == null)
            {
                throw new ArgumentException($"No se encontró ningún proveedor con el ID {supplier.SupplierID} para actualizar.");
            }

            if (!Regex.IsMatch(supplier.CompanyName, @"^[A-Za-z\s]+$"))
            {
                throw new ArgumentException("El nombre de la empresa no puede contener números.", nameof(supplier.CompanyName));
            }

            if (supplier == null)
            {
                throw new ArgumentNullException(nameof(supplier), "El proveedor no puede ser nulo.");
            }

            if (supplierAActualizar == null)
            {
                throw new ArgumentException($"No se encontró ningún proveedor con el ID {supplier.SupplierID} para actualizar.");
            }

            if (supplier.Region.Length > 24  || supplier.Fax.Length > 24)
            {
                throw new ArgumentException("Este campo no puede tener mas de 24 caracteres");
            }

            supplierAActualizar.Region = supplier.Region;
            supplierAActualizar.Fax = supplier.Fax;

            _context.SaveChanges();
        }

        public Suppliers GetById(int id)
        {
            return _context.Suppliers.Find(id);
        }
    }
}
