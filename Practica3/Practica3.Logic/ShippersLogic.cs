using Practica.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Practica3.Entities.DTO;

namespace Practica3.Logic
{
    public class ShippersLogic : BaseLogic, IRepository<ShippersDTO>
    {
        public List<ShippersDTO> GetAll()
        {
            return _context.Shippers.Select(shipper => new ShippersDTO
            {
                ShipperID = shipper.ShipperID,
                CompanyName = shipper.CompanyName,
                Phone = shipper.Phone
            }).ToList();
        }

        public void Add(ShippersDTO newShipper)
        {
            if (newShipper == null)
            {
                throw new ArgumentNullException(nameof(newShipper), "The shipper cannot be void.");
            }

            if (string.IsNullOrEmpty(newShipper.CompanyName))
            {
                throw new ArgumentException("Company name cannot be empty.");
            }

            if (!Regex.IsMatch(newShipper.CompanyName, @"^[A-Za-z\s]+$"))
            {
                throw new ArgumentException("The company name cannot contain numbers.");
            }

            if (!string.IsNullOrEmpty(newShipper.Phone) && !Regex.IsMatch(newShipper.Phone, @"^\(\d{3}\) \d{3}-\d{4}$"))
            {
                throw new ArgumentException("The telephone number is not in the correct format (for example, (235) 234-2356).");
            }


            if (newShipper.CompanyName.Length > 40)
            {
                throw new ArgumentException("The company name cannot be longer than 40 characters.");
            }

            if (newShipper.Phone.Length > 24)
            {
                throw new ArgumentException("The phone number cannot be longer than 24 characters.");
            }

            var shipper = new Shippers
            {
                CompanyName = newShipper.CompanyName,
                Phone = newShipper.Phone
            };

            _context.Shippers.Add(shipper);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var shipperAEliminar = _context.Shippers.Find(id);

            if (shipperAEliminar == null)
            {
                throw new ArgumentException($"No carrier with the ID {id} was found to delete.");
            }

            _context.Shippers.Remove(shipperAEliminar);
            _context.SaveChanges();
        }


        public void Update(ShippersDTO shipper)
        {

            if (shipper == null)
            {
                throw new ArgumentNullException(nameof(shipper), "The shipper cannot be void.");
            }

            var shipperAActualizar = _context.Shippers.Find(shipper.ShipperID);

            if (shipperAActualizar == null)
            {
                throw new ArgumentException($"No shipper with the ID {shipper.ShipperID} was found to update.");
            }

            if (!Regex.IsMatch(shipper.CompanyName, @"^[A-Za-z\s]+$"))
            {
                throw new ArgumentException("The company name cannot contain numbers.");
            }

            if (!string.IsNullOrEmpty(shipper.Phone) && !Regex.IsMatch(shipper.Phone, @"^\(\d{3}\) \d{3}-\d{4}$"))
            {
                throw new ArgumentException("The telephone number is not in the correct format (for example, (235) 234-2356).");
            }

            if (string.IsNullOrEmpty(shipper.CompanyName))
            {
                throw new ArgumentException("It appears that there are empty fields, please review and complete the form.");
            }

            if (shipper.CompanyName.Length > 40)
            {
                throw new ArgumentException("The company name cannot be longer than 40 characters.");
            }

            if (shipper.Phone.Length > 24)
            {
                throw new ArgumentException("The phone number cannot be longer than 24 characters.");
            }


            shipperAActualizar.CompanyName = shipper.CompanyName;
            shipperAActualizar.Phone = shipper.Phone;

            _context.SaveChanges();
        }

        public ShippersDTO GetById(int id)
        {

            var shipper = _context.Shippers.Find(id) ?? throw new ArgumentException($"No shipper with the ID {id} was found.");

            var shipperDTO = new ShippersDTO
            {
                ShipperID = shipper.ShipperID,
                CompanyName = shipper.CompanyName,
                Phone = shipper.Phone
            };

            return shipperDTO;

        }
    }
}

