using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Http;
using System.Web.Http.Results;
using Newtonsoft.Json;
using SeleniumPhantomJSDemo.Extensions;
using SeleniumPhantomJSDemo.Models;

namespace SeleniumPhantomJSDemo.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private static readonly IList<CustomerModel> _customers = new List<CustomerModel>()
        {
            new CustomerModel()
            {
                Id = 1,
                FirstName = "Sven",
                LastName = "Karlsson",
                Email = "sven@karlsson.se",
                CreatedDate = new DateTime(2012, 1, 2)
            },
            new CustomerModel()
            {
                Id = 2,
                FirstName = "Karl",
                LastName = "Svensson",
                Email = "karl@svensson.se",
                CreatedDate = new DateTime(2014, 7, 28)
            }
        };

        public IHttpActionResult Get(int id)
        {
            var existing = _customers.SingleOrDefault(x => x.Id == id);

            if (existing == null)
                return NotFound();

            return Json(existing);
        }

        public IEnumerable<CustomerModel> Get()
        {
            return _customers;
        }

        public IHttpActionResult Post(CustomerModel newCustomer)
        {
            newCustomer.Id = _customers.Max(x => x.Id) + 1;

            _customers.Add(newCustomer);

            return Created(Url.Link("DefaultApi", new { controller = "Customers", id = newCustomer.Id }), newCustomer);
        }

        public IHttpActionResult Put(CustomerModel updatedCustomer)
        {
            var existing = _customers.SingleOrDefault(x => x.Id == updatedCustomer.Id);

            if (existing == null)
                return NotFound();

            existing.FirstName = updatedCustomer.FirstName;
            existing.LastName = updatedCustomer.LastName;
            existing.Email = updatedCustomer.Email;

            return StatusCode(HttpStatusCode.NoContent);
        }

        public IHttpActionResult Delete(int id)
        {
            var existing = _customers.SingleOrDefault(x => x.Id == id);

            if (existing == null)
                return NotFound();

            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override JsonResult<T> Json<T>(T content, JsonSerializerSettings serializerSettings, Encoding encoding)
        {
            serializerSettings.ApplyApplicationDefaults();

            return base.Json(content, serializerSettings, encoding);
        }
    }
}