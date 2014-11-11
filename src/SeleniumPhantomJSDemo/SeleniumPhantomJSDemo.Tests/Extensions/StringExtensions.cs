namespace SeleniumPhantomJSDemo.Tests.Extensions
{
    public static class StringExtensions
    {
        public static string EnsureTrailing(this string s, char c)
        {
            if (s.EndsWith(c.ToString()))
                return s;

            return s + c;
        }
    }
}