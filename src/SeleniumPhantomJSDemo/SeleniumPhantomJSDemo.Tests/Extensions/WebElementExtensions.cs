using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium;

namespace SeleniumPhantomJSDemo.Tests.Extensions
{
    public static class WebElementExtensions
    {
         public static void Write(this IWebElement element, string text)
         {
             element.Clear();
             element.SendKeys(text);
         }

        public static IWebElement FindBySelector(this IWebElement element, string selector)
        {
            AssertParentExists(element, selector);

            return element.FindElement(By.CssSelector(selector));
        }
        
        public static ReadOnlyCollection<IWebElement> FindAllBySelector(this IWebElement element, string selector)
        {
            AssertParentExists(element, selector);

            return element.FindElements(By.CssSelector(selector));
        }

        private static void AssertParentExists(IWebElement element, string selector)
        {
            if (element == null)
            {
                throw new ArgumentException(string.Format("Could not find children by the selector '{0}' since the parent element does not exist", selector));
            }
        }

        public static void WriteTextToInput(this IWebElement element, string value, string selector)
        {
            element.FindBySelector(selector).Write(value);
        }
    }
}