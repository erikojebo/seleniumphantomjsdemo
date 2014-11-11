using System.Diagnostics;
using System.Reflection;

namespace SeleniumPhantomJSDemo.Tests.Extensions
{
    public static class ReflectionHelpers
    {
         public static MethodBase CallingMethod()
         {
             return new StackTrace().GetFrame(2).GetMethod();
         }
    }
}