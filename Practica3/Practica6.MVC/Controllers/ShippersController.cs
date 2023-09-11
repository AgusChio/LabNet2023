using Practica3.Entities.DTO;
using Practica3.Logic;
using Practica6.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Practica6.MVC.Controllers
{
    public class ShippersController : Controller
    {
        ShippersLogic logic = new ShippersLogic();

        public ActionResult Index()
        {
            List<ShippersDTO> shippers = logic.GetAll();

            List<ShippersView> shippersViews = shippers.Select(s => new ShippersView
            {
                ShipperID = s.ShipperID,
                CompanyName = s.CompanyName,
                Phone = s.Phone
            }).ToList();

            return View(shippersViews);
        }


        [HttpGet]
        public ActionResult Insert()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Insert(ShippersView newShipper)
        {
            try
            {
                logic.Add(new ShippersDTO
                {
                    ShipperID = newShipper.ShipperID,
                    CompanyName = newShipper.CompanyName,
                    Phone = newShipper.Phone
                });

                return Json(new { result = true });
            }
            catch (Exception ex)
            {
                return Json(new { result = false, error = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult Edit(ShippersView updateShipperView)
        {
            try
            {
                var shippersView = new ShippersDTO
                {
                    ShipperID = updateShipperView.ShipperID,
                    CompanyName = updateShipperView.CompanyName,
                    Phone = updateShipperView.Phone
                };
                logic.Update(shippersView);

                return Json(new { result = true });
            }
            catch (Exception ex)
            {
                return Json(new { result = false, error = ex.Message });
            }
        }


        [HttpPost]
        public JsonResult DeleteShipper(int id)
        {
            try
            {
                logic.Delete(id);

                return Json(new { result = true });
            }
            catch (Exception ex)
            {
                return Json(new { result = false, error = ex.Message });
            }
        }
    }
}