using System.Threading.Tasks;
using NUnit.Framework;
using WooCommerceCore.NET.REST;

namespace WooCommerceCore.NET.Tests
{
    public class BaseTests
    {
        protected IJsonRestClient RestClient { get; private set; }

        [SetUp]
        public async Task TestServerReachable()
        {
            var jsonClient = new JsonRestClient("https://bike.joelluijmes.nl/wp-json/wc/v2/", "ck_907833f04d2a0e269fc00e19ee4bc020bc25963f", "cs_f4ea0836e7ebf4a506168d7bc65d2f6785366829");
            RestClient = new WooCommerceRestClient(jsonClient);

            var response = await RestClient.GetJsonAsync("system_status");
            var version = response.SelectToken("$.environment.version");

            Assert.IsNotNull(version, "Couldn't get version of test target");
        }
    }
}
