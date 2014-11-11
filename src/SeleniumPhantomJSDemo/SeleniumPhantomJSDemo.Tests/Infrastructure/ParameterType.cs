namespace SeleniumPhantomJSDemo.Tests.Infrastructure
{
    public class ParameterType
    {
        public readonly string RegexPattern;

        private ParameterType(string regexPattern)
        {
            RegexPattern = regexPattern;
        }

        public static readonly ParameterType Integer = new ParameterType("[0-9]+");
        public static readonly ParameterType AlphaNumeric = new ParameterType("[a-zA-Z0-9]+");
    }
}