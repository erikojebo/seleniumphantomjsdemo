using System.Collections.ObjectModel;
using System.Linq;
using OpenQA.Selenium;
using SeleniumPhantomJSDemo.Tests.Extensions;

namespace SeleniumPhantomJSDemo.Tests.Infrastructure.Pages
{
    public class CustomerListPage : PageBase
    {
        private readonly UrlPattern _url = new UrlPattern("/Home/Index#/Customers/");

        public CustomerListPage(IWebDriver driver, ApplicationState applicationState) : base(driver, applicationState)
        {
        }

        public void GoTo()
        {
            GoTo(_url.ToAbsoluteUrl());
        }

        public void Refresh()
        {
            GoTo();
        }

        public void GoToAddCustomerPage()
        {
            ClickLinkWithId("add-customer-link");
        }

        public bool IsShowingLastAddedCustomer()
        {
            return GetListItemForLastAddedCustomer() != null;
        }

        private IWebElement GetListItemForLastAddedCustomer()
        {
            var customers = GetCustomers();

            return customers.SingleOrDefault(x => x.FindBySelector(".email").Text.Contains(ApplicationState.LastAddedCustomerEmail));
        }

        public bool IsShowingCustomers()
        {
            return GetCustomers().Any();
        }

        private ReadOnlyCollection<IWebElement> GetCustomers()
        {
            return FindAllBySelector("#customer-list li");
        }

        public void ShowDetailsForLastAddedCustomer()
        {
            var li = GetListItemForLastAddedCustomer();
            li.FindBySelector("a").Click();
        }

        protected override bool IsCurrentUrlForPage()
        {
            return _url.IsMatch(Driver.Url);
        }
    }
}