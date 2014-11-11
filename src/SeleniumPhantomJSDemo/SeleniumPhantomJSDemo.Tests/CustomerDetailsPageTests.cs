using NUnit.Framework;

namespace SeleniumPhantomJSDemo.Tests
{
    [TestFixture]
    public class CustomerDetailsPageTests : PageTestBase
    {
        [Test]
        public void User_is_shown_updated_customer_details_after_editing_an_existing_customer()
        {
            AddCustomerPage.GoTo();
            AddCustomerPage.AddCustomer(firstName: "Sven", lastName: "Karlsson", email: "sven@karlsson.se");

            CustomerListPage.ShowDetailsForLastAddedCustomer();
            CustomerDetailsPage.GoToEditPage();

            Assert(EditCustomerPage.IsLoadedSuccessfully());

            EditCustomerPage.WriteFirstName("Sven-Erik");
            EditCustomerPage.SubmitChanges();

            CustomerDetailsPage.TakeScreenShot();
            Assert(CustomerDetailsPage.IsShowingCustomer(firstName: "Sven-Erik", lastName: "Karlsson", email: "sven@karlsson.se"));
        }
    }
}