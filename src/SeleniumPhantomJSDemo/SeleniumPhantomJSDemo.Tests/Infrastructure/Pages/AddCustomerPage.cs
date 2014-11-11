using OpenQA.Selenium;
using SeleniumPhantomJSDemo.Tests.Extensions;

namespace SeleniumPhantomJSDemo.Tests.Infrastructure.Pages
{
    public class AddCustomerPage : PageBase
    {
        private readonly UrlPattern _url = new UrlPattern("/Home/Index#/customers/add");

        public AddCustomerPage(IWebDriver driver, ApplicationState applicationState) : base(driver, applicationState)
        {
        }

        public void GoTo()
        {
            GoTo(_url.ToAbsoluteUrl());
        }

        public void AddCustomer(string firstName = null, string lastName = null, string email = null)
        {
            firstName = firstName ?? TestValues.CreateString();
            lastName = lastName ?? TestValues.CreateString();
            email = email ?? TestValues.CreateString();

            var form = FindById("add-customer-form");

            form.WriteTextToInput(firstName, "input[name=firstName]");
            form.WriteTextToInput(lastName, "input[name=lastName]");
            form.WriteTextToInput(email, "input[name=email]");

            form.Submit();

            ApplicationState.LastAddedCustomerEmail = email;
        }

        protected override bool IsCurrentUrlForPage()
        {
            return Driver.Url == _url.ToAbsoluteUrl();
        }
    }
}