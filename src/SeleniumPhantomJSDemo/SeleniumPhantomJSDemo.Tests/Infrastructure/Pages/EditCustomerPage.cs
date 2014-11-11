using OpenQA.Selenium;
using SeleniumPhantomJSDemo.Tests.Extensions;

namespace SeleniumPhantomJSDemo.Tests.Infrastructure.Pages
{
    public class EditCustomerPage : PageBase
    {
        private readonly UrlPattern _url = new UrlPattern("/Home/Index#/Customers/{0}/edit", ParameterType.Integer);

        public EditCustomerPage(IWebDriver driver, ApplicationState applicationState) : base(driver, applicationState)
        {
        }

        public bool IsShowingLastAddedCustomer()
        {
            return FindBySelector(".email").Text == ApplicationState.LastAddedCustomerEmail;
        }

        protected override bool IsCurrentUrlForPage()
        {
            return _url.IsMatch(Driver.Url);
        }

        public void WriteFirstName(string firstName)
        {
            FindById("edit-customer-form").WriteTextToInput(firstName, "input[name=firstName]");
        }

        public void SubmitChanges()
        {
            FindById("edit-customer-form").Submit();
        }
    }
}