using Practica3.Entities.DTO;
using Practica3.Logic;
using Practica7.WA.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;


namespace Practica7.WA.Controllers
{
    public class SuppliersController : ApiController
    {
        SupplierLogic logic = new SupplierLogic();

        // GET: Suppliers
        public IHttpActionResult Get()
        {
            try
            {
                List<SuppliersDTO> shippers = logic.GetAll();
                return Ok(shippers);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // GET: Suppliers/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                SuppliersDTO supplier = logic.GetById(id);
                return Ok(supplier);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // POST: Suppliers
        public IHttpActionResult Post(SuppliersDTO supplier)
        {
            try
            {
                logic.Add(supplier);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // PUT: Suppliers/5
        public IHttpActionResult Put(int id, [FromBody] SuppliersDTO suppliersDTO)
        {
            try
            {
                suppliersDTO.SupplierID = id;
                logic.Update(suppliersDTO);
                return Ok(suppliersDTO);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // DELETE: Suppliers/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                logic.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}