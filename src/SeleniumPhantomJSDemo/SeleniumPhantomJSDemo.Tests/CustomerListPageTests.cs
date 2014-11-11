using NUnit.Framework;

namespace SeleniumPhantomJSDemo.Tests
{
    [TestFixture]
    public class CustomerListPageTests : PageTestBase
    {
        [Test]
        public void Can_load_start_page()
        {
            CustomerListPage.GoTo();

            AssertIsShowing(CustomerListPage);
        }

        [Test]
        public void User_is_shown_updated_customer_list_after_adding_a_new_customer()
        {
            CustomerListPage.GoTo();

            CustomerListPage.GoToAddCustomerPage();
            AddCustomerPage.AddCustomer();

            AssertIsShowing(CustomerListPage);

            Assert(CustomerListPage.IsShowingLastAddedCustomer());
        }

        [Test]
        public void Details_can_be_shown_for_customer_in_the_list()
        {
            CustomerListPage.GoTo();
            CustomerListPage.GoToAddCustomerPage();
            AddCustomerPage.AddCustomer();

            CustomerListPage.ShowDetailsForLastAddedCustomer();

            Assert(CustomerDetailsPage.IsLoadedSuccessfully());
            Assert(CustomerDetailsPage.IsShowingLastAddedCustomer());
        }
    }
}