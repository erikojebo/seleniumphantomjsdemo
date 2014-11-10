using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Http;
using System.Web.Http.Results;
using Newtonsoft.Json;
using SeleniumPhantomJSDemo.Entities;
using SeleniumPhantomJSDemo.Extensions;
using SeleniumPhantomJSDemo.Models;
using SeleniumPhantomJSDemo.Persistence;

namespace SeleniumPhantomJSDemo.Controllers.Api
{
    public class CustomersController : ApiController
    {
        public IHttpActionResult Get(int id)
        {
            using (var context = new DemoContext())
            {
                var existing = context.Customers.SingleOrDefault(x => x.Id == id);

                if (existing == null)
                    return NotFound();

                return Json(existing);
            }
        }

        public IEnumerable<CustomerModel> Get()
        {
            using (var context = new DemoContext())
            {
                return context.Customers.Select(CustomerModel.FromCustomer).ToList();
            }
        }

        public IHttpActionResult Post(CustomerModel postedCustomer)
        {
            using (var context = new DemoContext())
            {
                var newCustomer = new Customer()
                {
                    FirstName = postedCustomer.FirstName,
                    LastName = postedCustomer.LastName,
                    Email = postedCustomer.Email
                };

                context.Customers.Add(newCustomer);

                context.SaveChanges();

                var newCustomerModel = CustomerModel.FromCustomer(newCustomer);

                return Created(Url.Link("DefaultApi", new { controller = "Customers", id = newCustomer.Id }), newCustomerModel);
            }
        }

        public IHttpActionResult Put(CustomerModel updatedCustomer)
        {
            using (var context = new DemoContext())
            {
                var existing = context.Customers.SingleOrDefault(x => x.Id == updatedCustomer.Id);

                if (existing == null)
                    return NotFound();

                existing.FirstName = updatedCustomer.FirstName;
                existing.LastName = updatedCustomer.LastName;
                existing.Email = updatedCustomer.Email;

                context.SaveChanges();

                return StatusCode(HttpStatusCode.NoContent);
            }
        }

        public IHttpActionResult Delete(int id)
        {
            using (var context = new DemoContext())
            {
                var existing = context.Customers.SingleOrDefault(x => x.Id == id);

                if (existing == null)
                    return NotFound();

                context.Customers.Remove(existing);

                context.SaveChanges();

                return StatusCode(HttpStatusCode.NoContent);
            }
        }

        protected override JsonResult<T> Json<T>(T content, JsonSerializerSettings serializerSettings, Encoding encoding)
        {
            serializerSettings.ApplyApplicationDefaults();

            return base.Json(content, serializerSettings, encoding);
        }
    }
}