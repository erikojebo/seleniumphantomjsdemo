using System;

namespace SeleniumPhantomJSDemo.Entities
{
    public class Customer
    {
        public Customer()
        {
            CreatedDate = DateTime.Now;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}