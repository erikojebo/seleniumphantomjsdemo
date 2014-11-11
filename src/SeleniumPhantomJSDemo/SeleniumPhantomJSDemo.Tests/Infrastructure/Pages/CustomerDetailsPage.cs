using OpenQA.Selenium;

namespace SeleniumPhantomJSDemo.Tests.Infrastructure.Pages
{
    public class CustomerDetailsPage : PageBase
    {
        private readonly UrlPattern _url = new UrlPattern("/Home/Index#/Customers/{0}", ParameterType.Integer);

        public CustomerDetailsPage(IWebDriver driver, ApplicationState applicationState) : base(driver, applicationState)
        {
        }

        protected override bool IsCurrentUrlForPage()
        {
            return _url.IsMatch(Driver.Url);
        }

        public void GoToEditPage()
        {
            FindBySelector("a.edit").Click();
        }

        public bool IsShowingLastAddedCustomer()
        {
            return FindBySelector(".email").Text == ApplicationState.LastAddedCustomerEmail;
        }

        public bool IsShowingCustomer(string firstName, string lastName, string email)
        {
            var s = Driver.PageSource;
            return FindBySelector(".first-name").Text == firstName &&
                   FindBySelector(".last-name").Text == lastName &&
                   FindBySelector(".email").Text == email;
        }
    }
}