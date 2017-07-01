using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using WooCommerceCore.NET.REST;

namespace WooCommerceCore.NET.Tests
{
    public class BaseTests
    {
        protected IJsonRestClient RestClient { get; private set; }
        protected IConfiguration Configuration { get; private set; }

        [OneTimeSetUp]
        public async Task TestServerReachable()
        {
            Configuration = new ConfigurationBuilder()
                .AddJsonFile("settings.json")
                .Build();

            var jsonClient = new JsonRestClient(Configuration["api_url"], Configuration["api_key"], Configuration["api_secret"]);
            RestClient = new WooCommerceRestClient(jsonClient);

            var response = await RestClient.GetJsonAsync("system_status");
            var version = response.SelectToken("$.environment.version");

            Assert.IsNotNull(version, "Couldn't get version of test target");
        }
    }
}
