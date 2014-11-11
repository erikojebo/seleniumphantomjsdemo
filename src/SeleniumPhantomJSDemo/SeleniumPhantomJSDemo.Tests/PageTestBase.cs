using NUnit.Framework;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.Extensions;
using SeleniumPhantomJSDemo.Tests.Infrastructure;
using SeleniumPhantomJSDemo.Tests.Infrastructure.Pages;

namespace SeleniumPhantomJSDemo.Tests
{
    public class PageTestBase
    {
        private PhantomJSDriver _driver;
        private ApplicationState _applicationState;

        public CustomerListPage CustomerListPage { get; private set; }
        public CustomerDetailsPage CustomerDetailsPage { get; private set; }
        public EditCustomerPage EditCustomerPage { get; set; }
        public AddCustomerPage AddCustomerPage { get; set; }

        [TestFixtureSetUp]
        public void SetUp()
        {
            TestDatabase.Cleanup();

            _driver = new PhantomJSDriver();
            _applicationState = new ApplicationState();

            CustomerListPage = new CustomerListPage(_driver, _applicationState);
            CustomerDetailsPage = new CustomerDetailsPage(_driver, _applicationState);
            AddCustomerPage = new AddCustomerPage(_driver, _applicationState);
            EditCustomerPage = new EditCustomerPage(_driver, _applicationState);
        }

        [TestFixtureTearDown]
        public void TearDown()
        {
            _driver.Quit();
        }

        protected void AssertIsShowing(PageBase page)
        {
            Assert(page.IsLoadedSuccessfully(), string.Format("Could not load the {0} page", page.PageName));
        }

        protected void Assert(bool condition, string failureDescription = null)
        {
            try
            {
                NUnit.Framework.Assert.IsTrue(condition, failureDescription);
            }
            catch (AssertionException)
            {
                throw;
            }
        }
    }
}