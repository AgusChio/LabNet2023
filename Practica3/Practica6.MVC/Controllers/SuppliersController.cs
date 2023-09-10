using Practica.Entities;
using Practica3.Entities.DTO;
using Practica3.Logic;
using Practica6.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practica6.MVC.Controllers
{
    public class SuppliersController : Controller
    {
        // GET: Suppliers
        public ActionResult Index()
        {
            var logic = new SupplierLogic();
            List<SuppliersDTO> suppliers = logic.GetAll();

            List<SupplierView> supplierViews = suppliers.Select(s => new SupplierView
            {
                SupplierID = s.SupplierID, 
                CompanyName = s.CompanyName,
                ContactName = s.ContactName,
                ContactTitle = s.ContactTitle,
                Address = s.Address,
                City = s.City,
                Region = s.Region,
                PostalCode = s.PostalCode,
                Country = s.Country,
                Phone = s.Phone,
                Fax = s.Fax
             }).ToList();

            return View(supplierViews);
        }

        [HttpGet]
        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(SupplierView newSupplier)
        {
            try
            {
                var logic = new SupplierLogic();
                logic.Add(new SuppliersDTO
                {
                    CompanyName = newSupplier.CompanyName,
                    ContactName = newSupplier.ContactName,
                    ContactTitle = newSupplier.ContactTitle,
                    Address = newSupplier.Address,
                    City = newSupplier.City,
                    Region = newSupplier.Region,
                    PostalCode = newSupplier.PostalCode,
                    Country = newSupplier.Country,
                    Phone = newSupplier.Phone,
                    Fax = newSupplier.Fax
                });

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Error");
            }
        }



        public ActionResult DeleteSupplier(int idSupplier)
        {
            try
            {
                var logic = new SupplierLogic();
                logic.Delete(idSupplier);

                return Json(new { result = true });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return Json(new { result = false, error = ex.Message });
            }
        }

    }
}