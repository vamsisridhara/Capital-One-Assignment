using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIDI.Models;

namespace WebAPIDI.Controllers
{
    public class ProductsController : ApiController
    {
        ICustomerAutofacRepository _repository;

        public ProductsController(ICustomerAutofacRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<CustomerAutofac> Get()
        {
            return _repository.GetCustomerDetails();
        }

        public IHttpActionResult Get(string id)
        {
            var product = _repository.GetCustomerDetails().Where(X=>X.CustomerId == id).FirstOrDefault();
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        //public IHttpActionResult Post(Product product)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    _repository.Add(product);
        //    return CreatedAtRoute("DefaultApi", new { id = product.Id }, product);
        //}
    }
}
