using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using WooCommerceCore.NET.REST;

namespace WooCommerceCore.NET.Tests
{
    public class BaseTests
    {
        private static bool _initialized;
        private static readonly IConfigurationRoot _configuration;
        private static readonly WooCommerceRestClient _restClient;

        protected IJsonRestClient RestClient => _restClient;
        protected IConfiguration Configuration => _configuration;

        static BaseTests()
        {
            _configuration = new ConfigurationBuilder()
                .AddJsonFile("settings.json")
                .Build();

            var jsonClient = new JsonRestClient(_configuration["api_url"], _configuration["api_key"], _configuration["api_secret"]);
            _restClient = new WooCommerceRestClient(jsonClient);
        }

        [OneTimeSetUp]
        public async Task TestServerReachable()
        {
            if (_initialized)
                return;

            var response = await RestClient.GetJsonAsync("system_status");
            var version = response.SelectToken("$.environment.version");

            Assert.IsNotNull(version, "Couldn't get version of test target");
            _initialized = true;
        }
    }
}
