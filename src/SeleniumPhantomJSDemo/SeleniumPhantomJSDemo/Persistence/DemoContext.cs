using System.Data.Entity;
using System.Linq;
using SeleniumPhantomJSDemo.Entities;

namespace SeleniumPhantomJSDemo.Persistence
{
    public class DemoContext : DbContext
    {
        public DemoContext() : base("DemoContex")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>();

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Customer> Customers
        {
            get { return Set<Customer>(); }
        }
    }
}