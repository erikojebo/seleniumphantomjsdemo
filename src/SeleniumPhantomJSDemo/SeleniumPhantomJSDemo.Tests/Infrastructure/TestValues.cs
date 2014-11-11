using System;

namespace SeleniumPhantomJSDemo.Tests.Infrastructure
{
    public class TestValues
    {
        public static string CreateString()
        {
            return "test_" + Guid.NewGuid();
        }
    }
}