using System.Configuration;

namespace SeleniumPhantomJSDemo.Tests.Extensions
{
    public static class UrlExtensions
    {
        public static string ToAbsoluteUrl(this string relativeUrl)
        {
            var baseUrl = ConfigurationManager.AppSettings["baseUrl"];
            return baseUrl.EnsureTrailing('/') + relativeUrl.TrimStart('/');
        } 
    }
}