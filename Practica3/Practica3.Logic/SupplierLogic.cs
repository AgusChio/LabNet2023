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
                throw new ArgumentNullException(nameof(newSupplierDTO), "The supplier cannot be null and void.");
            }

            if (string.IsNullOrEmpty(newSupplierDTO.CompanyName) || 
                string.IsNullOrEmpty(newSupplierDTO.ContactName) || 
                string.IsNullOrEmpty(newSupplierDTO.ContactTitle) ||
                string.IsNullOrEmpty(newSupplierDTO.Address) ||
                string.IsNullOrEmpty(newSupplierDTO.City) || 
                string.IsNullOrEmpty(newSupplierDTO.PostalCode) || 
                string.IsNullOrEmpty(newSupplierDTO.Country) ||
                string.IsNullOrEmpty(newSupplierDTO.Phone))
            {
                throw new ArgumentException("This field cannot be empty.");
            }

            if (!Regex.IsMatch(newSupplierDTO.CompanyName, @"^[A-Za-z\s]+$"))
            {
                throw new ArgumentException("The company name cannot contain numbers.");
            }

            if (!Regex.IsMatch(newSupplierDTO.ContactName, @"^[A-Za-z\s]+$"))
            {
                throw new ArgumentException("Contact name can only contain letters.");
            }

            if (!Regex.IsMatch(newSupplierDTO.ContactTitle, @"^[A-Za-z\s]+$"))
            {
                throw new ArgumentException("Contact title can only contain letters.");
            }

            if (!string.IsNullOrEmpty(newSupplierDTO.Region) && !Regex.IsMatch(newSupplierDTO.Region, @"^[A-Za-z\s]+$"))
            {
                throw new ArgumentException("Region can only contain letters.");
            }

            if (!Regex.IsMatch(newSupplierDTO.City, @"^[A-Za-z\s]+$"))
            {
                throw new ArgumentException("City can only contain letters.");
            }

            if (!Regex.IsMatch(newSupplierDTO.Country, @"^[A-Za-z\s]+$"))
            {
                throw new ArgumentException("Country can only contain letters.");
            }

            if (!Regex.IsMatch(newSupplierDTO.Phone, @"^\(\d{3}\) \d{3}-\d{4}$"))
            {
                throw new ArgumentException("The telephone number is not in the correct format (for example, (235) 234-2356).");
            }

            if (newSupplierDTO.Phone.Length > 24)
            {
                throw new ArgumentException("The telephone number cannot be longer than 24 characters.");
            }

            if (newSupplierDTO.CompanyName.Length > 40)
            {
                throw new ArgumentException("The Company Name cannot be longer than 40 characters.");
            }

            if (newSupplierDTO.ContactName.Length > 30)
            {
                throw new ArgumentException("The Contact Name cannot be longer than 30 characters.");
            }

            if (newSupplierDTO.ContactTitle.Length > 30)
            {
                throw new ArgumentException("The Contact Title cannot be longer than 30 characters.");
            }

            if (newSupplierDTO.Address.Length > 60)
            {
                throw new ArgumentException("The Address cannot be longer than 60 characters.");
            }

            if (newSupplierDTO.City.Length > 15)
            {
                throw new ArgumentException("The City cannot be longer than 15 characters.");
            }

            if (newSupplierDTO.Region.Length > 15)
            {
                throw new ArgumentException("The Region cannot be longer than 15 characters.");
            }

            if (newSupplierDTO.PostalCode.Length > 10)
            {
                throw new ArgumentException("The Postal Code cannot be longer than 10 characters.");
            }

            if (newSupplierDTO.Country.Length > 15)
            {
                throw new ArgumentException("The Country cannot be longer than 15 characters.");
            }

            if (newSupplierDTO.Fax.Length > 24)
            {
                throw new ArgumentException("The Fax cannot be longer than 24 characters.");
            }

            if (!string.IsNullOrEmpty(newSupplierDTO.Fax) && !Regex.IsMatch(newSupplierDTO.Fax, @"^[0-9]+$"))
            {
                throw new ArgumentException("The Fax can only contain numeric digits.");
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
                throw new ArgumentException($"No supplier with the ID {id} was found to remove.");
            }

            _context.Suppliers.Remove(supplierAEliminar);
            _context.SaveChanges();
        }


        public void Update(SuppliersDTO updatedSupplierDTO)
        {

            var supplierAActualizar = _context.Suppliers.Find(updatedSupplierDTO.SupplierID);

            if (supplierAActualizar == null)
            {
                throw new ArgumentException($"No supplier with the ID {updatedSupplierDTO.SupplierID} was found to update.");
            }

            if (!Regex.IsMatch(updatedSupplierDTO.CompanyName, @"^[A-Za-z\s]+$"))
            {
                throw new ArgumentException("The company name cannot contain numbers.");
            }

            if (!Regex.IsMatch(updatedSupplierDTO.ContactName, @"^[A-Za-z\s]+$"))
            {
                throw new ArgumentException("Contact name can only contain letters.");
            }

            if (!Regex.IsMatch(updatedSupplierDTO.ContactTitle, @"^[A-Za-z\s]+$"))
            {
                throw new ArgumentException("Contact title can only contain letters.");
            }

            if (!string.IsNullOrEmpty(updatedSupplierDTO.Region) && !Regex.IsMatch(updatedSupplierDTO.Region, @"^[A-Za-z\s]+$"))
            {
                throw new ArgumentException("Region can only contain letters.");
            }

            if (!Regex.IsMatch(updatedSupplierDTO.City, @"^[A-Za-z\s]+$"))
            {
                throw new ArgumentException("City can only contain letters.");
            }

            if (!Regex.IsMatch(updatedSupplierDTO.Country, @"^[A-Za-z\s]+$"))
            {
                throw new ArgumentException("Country can only contain letters.");
            }

            if (!Regex.IsMatch(updatedSupplierDTO.Phone, @"^\(\d{3}\) \d{3}-\d{4}$"))
            {
                throw new ArgumentException("The telephone number is not in the correct format (for example, (235) 234-2356).");
            }

            if (updatedSupplierDTO.Phone.Length > 24)
            {
                throw new ArgumentException("The phone number cannot be longer than 24 characters.");
            }

            if (updatedSupplierDTO.CompanyName.Length > 40 )
            {
                throw new ArgumentException("The Company Name cannot be longer than 40 characters.");
            }

            if (updatedSupplierDTO.ContactName.Length > 30)
            {
                throw new ArgumentException("The Contact Name cannot be longer than 30 characters.");
            }

            if (updatedSupplierDTO.ContactTitle.Length > 30)
            {
                throw new ArgumentException("The Contact Title cannot be longer than 30 characters.");
            }

            if (updatedSupplierDTO.Address.Length > 60)
            {
                throw new ArgumentException("The Address cannot be longer than 60 characters.");
            }

            if (updatedSupplierDTO.City.Length > 15)
            {
                throw new ArgumentException("The City cannot be longer than 15 characters.");
            }

            if (updatedSupplierDTO.Region.Length > 15)
            {
                throw new ArgumentException("The Region cannot be longer than 15 characters.");
            }

            if (updatedSupplierDTO.PostalCode.Length > 10)
            {
                throw new ArgumentException("The Postal Code cannot be longer than 10 characters.");
            }

            if (updatedSupplierDTO.Country.Length > 15)
            {
                throw new ArgumentException("The Country cannot be longer than 15 characters.");
            }

            if (updatedSupplierDTO.Fax.Length > 24)
            {
                throw new ArgumentException("The Fax cannot be longer than 24 characters.");
            }

            if (!string.IsNullOrEmpty(updatedSupplierDTO.Fax) && !Regex.IsMatch(updatedSupplierDTO.Fax, @"^[0-9]+$"))
            {
                throw new ArgumentException("The Fax can only contain numeric digits.");
            }

            if (updatedSupplierDTO.Country == null)
            {
                throw new ArgumentException("nothing crazy came in");
            }

            supplierAActualizar.CompanyName = updatedSupplierDTO.CompanyName;
            supplierAActualizar.ContactName = updatedSupplierDTO.ContactName;
            supplierAActualizar.ContactTitle = updatedSupplierDTO.ContactTitle;
            supplierAActualizar.Address = updatedSupplierDTO.Address;
            supplierAActualizar.City = updatedSupplierDTO.City;
            supplierAActualizar.Region = updatedSupplierDTO?.Region;
            supplierAActualizar.PostalCode = updatedSupplierDTO.PostalCode;
            supplierAActualizar.Country = updatedSupplierDTO?.Country;
            supplierAActualizar.Phone = updatedSupplierDTO.Phone;
            supplierAActualizar.Fax = updatedSupplierDTO?.Fax;

            _context.SaveChanges();
        }

        public SuppliersDTO GetById(int id)
        {
            var supplier = _context.Suppliers.Find(id) ?? throw new ArgumentException($"No supplier with the ID {id} was found.");

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
