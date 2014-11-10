using System;
using SeleniumPhantomJSDemo.Entities;

namespace SeleniumPhantomJSDemo.Models
{
    public class CustomerModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }

        public static CustomerModel FromCustomer(Customer customer)
        {
            return new CustomerModel()
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                CreatedDate = customer.CreatedDate
            };
        }
    }
}