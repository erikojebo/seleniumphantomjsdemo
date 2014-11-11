using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Drawing.Imaging;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using SeleniumPhantomJSDemo.Tests.Extensions;

namespace SeleniumPhantomJSDemo.Tests.Infrastructure.Pages
{
    public abstract class PageBase
    {
        protected readonly IWebDriver Driver;

        protected PageBase(IWebDriver driver, ApplicationState applicationState)
        {
            ApplicationState = applicationState;
            Driver = driver;
        }

        public ApplicationState ApplicationState { get; private set; }

        protected void GoTo(string url)
        {
            Driver.Url = url;
            Driver.Navigate();
        }

        public bool IsLoadedSuccessfully()
        {
            if (!IsCurrentUrlForPage())
            {
                return false;
            }

            var element = FindById("selenium-phantomjs-demo");

            return element != null;
        }

        protected abstract bool IsCurrentUrlForPage();

        public string PageName
        {
            get
            {
                var typeName = GetType().Name;
                return typeName.Substring(0, typeName.Length - "Page".Length);
            }
        }

        public void TakeScreenShot()
        {
            var screenshotDirectory = ConfigurationManager.AppSettings["screenshotDirectory"];

            if (!Directory.Exists(screenshotDirectory))
            {
                Directory.CreateDirectory(screenshotDirectory);
            }

            var screenshot = Driver.TakeScreenshot();

            var callingMethod = ReflectionHelpers.CallingMethod();

            var dateTime = DateTime.Now.ToString("yyyy-MM-dd_HH.mm.ss");
            var fileName = string.Format("{0}_{1}_{2}_{3}.png", callingMethod.DeclaringType.Name, callingMethod.Name, PageName, dateTime);
            var filePath = Path.Combine(screenshotDirectory, fileName);

            screenshot.SaveAsFile(filePath, ImageFormat.Png);
        }

        protected void ClickLinkWithId(string id)
        {
            var link = FindById(id);
            link.Click();
        }

        protected IWebElement FindById(string id)
        {
            return Driver.FindElement(By.Id(id));
        }

        protected IWebElement FindBySelector(string cssSelector)
        {
            return Driver.FindElement(By.CssSelector(cssSelector));
        }

        protected ReadOnlyCollection<IWebElement> FindAllBySelector(string cssSelector)
        {
            return Driver.FindElements(By.CssSelector(cssSelector));
        }
    }
}