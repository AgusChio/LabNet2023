using Practica3.Entities.DTO;
using Practica3.Logic;
using Practica6.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Practica6.MVC.Controllers
{
    public class SuppliersController : Controller
    {

        SupplierLogic logic = new SupplierLogic();

        public ActionResult Index()
        {
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


                return Json(new { result = true });
            }
            catch (Exception ex)
            {
                return Json(new { result = false, error = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult Edit(SupplierView updateSupplierView)
        {
            try
            {
                var supplierView = new SuppliersDTO
                {
                    SupplierID = updateSupplierView.SupplierID,
                    CompanyName = updateSupplierView.CompanyName,
                    ContactName = updateSupplierView.ContactName,
                    ContactTitle = updateSupplierView.ContactTitle,
                    Address = updateSupplierView.Address,
                    City = updateSupplierView.City,
                    Region = updateSupplierView.Region,
                    PostalCode = updateSupplierView.PostalCode,
                    Country = updateSupplierView.Country,
                    Phone = updateSupplierView.Phone,
                    Fax = updateSupplierView.Fax
                };
                logic.Update(supplierView);

                return Json(new { result = true });
            }
            catch (Exception ex)
            {
                return Json(new { result = false, error = ex.Message });
            }   
        }



        public JsonResult DeleteSupplier(int idSupplier)
        {
            try
            {
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