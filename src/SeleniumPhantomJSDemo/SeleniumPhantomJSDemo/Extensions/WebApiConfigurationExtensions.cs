using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace SeleniumPhantomJSDemo.Extensions
{
    public static class WebApiConfigurationExtensions
    {
         public static void ApplyApplicationDefaults(this JsonSerializerSettings jsonSerializerSettings)
         {
             jsonSerializerSettings.Formatting = Formatting.Indented;
             jsonSerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
         }
    }
}