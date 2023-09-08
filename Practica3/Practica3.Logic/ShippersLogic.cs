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
                throw new ArgumentNullException(nameof(newShipper), "El transportista no puede ser nulo.");
            }

            if (string.IsNullOrEmpty(newShipper.CompanyName) || string.IsNullOrEmpty(newShipper.Phone))
            {
                throw new ArgumentException("El campo no puede estar vacío");
            }

            if (!Regex.IsMatch(newShipper.CompanyName, @"^[A-Za-z\s]+$"))
            {
                throw new ArgumentException("El nombre de la empresa no puede contener números.", nameof(newShipper.CompanyName));
            }

            if (!Regex.IsMatch(newShipper.Phone, @"^[0-9]+$"))
            {
                throw new ArgumentException("El número de teléfono solo puede contener dígitos numéricos.", nameof(newShipper.Phone));
            }

            if (newShipper.Phone.Length > 24)
            {
                throw new ArgumentException("El número de teléfono no puede tener más de 24 caracteres.", nameof(newShipper.Phone));
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
                throw new ArgumentException($"No se encontró ningún transportista con el ID {id} para eliminar.");
            }

            _context.Shippers.Remove(shipperAEliminar);
            _context.SaveChanges();
        }


        public void Update(ShippersDTO shipper)
        {

            if (shipper == null)
            {
                throw new ArgumentNullException(nameof(shipper), "El transportista no puede ser nulo.");
            }

            var shipperAActualizar = _context.Shippers.Find(shipper.ShipperID);

            if (shipperAActualizar == null)
            {
                throw new ArgumentException($"No se encontró ningún transportista con el ID {shipper.ShipperID} para actualizar.");
            }

            if (!Regex.IsMatch(shipper.CompanyName, @"^[A-Za-z\s]+$"))
            {
                throw new ArgumentException("El nombre de la empresa no puede contener números.", nameof(shipper.CompanyName));
            }

            if (shipper == null)
            {
                throw new ArgumentNullException(nameof(shipper), "El transportista no puede ser nulo.");
            }

            if (shipperAActualizar == null)
            {
                throw new ArgumentException($"No se encontró ningún transportista con el ID {shipper.ShipperID} para actualizar.");
            }

            if (string.IsNullOrEmpty(shipper.CompanyName) || string.IsNullOrEmpty(shipper.Phone))
            {
                throw new ArgumentException("Este campo no puede estar vacio", nameof(shipper.CompanyName));
            }


            shipperAActualizar.CompanyName = shipper.CompanyName;
            shipperAActualizar.Phone = shipper.Phone;

            _context.SaveChanges();
        }

        public Shippers GetById(int id)
        {
            return _context.Shippers.Find(id);
        }
    }
}
