using Practica3.Entities.DTO;
using Practica3.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Practica7.WA.Controllers
{
    public class ShippersController : ApiController
    {
        ShippersLogic logic = new ShippersLogic();

        // GET: Shippers
        public IHttpActionResult Get()
        {
            try
            {
                List<ShippersDTO> shippers = logic.GetAll();
                return Ok(shippers);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // GET: Shippers/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                ShippersDTO shipper = logic.GetById(id);
                return Ok(shipper);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }   

        // POST: Shippers
        public IHttpActionResult Post(ShippersDTO shipper)
        {
            try
            {
                logic.Add(shipper);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // PUT: Shippers/5
        public IHttpActionResult Put(int id, [FromBody] ShippersDTO shippersDTO)
        {
            try
            {
                shippersDTO.ShipperID = id;
                logic.Update(shippersDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // DELETE: Shippers/5
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