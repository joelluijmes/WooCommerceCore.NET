using System;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using WooCommerceCore.NET;
using WooCommerceCore.NET.Models.Products;
using WooCommerceCore.NET.Repositories.Products;

namespace WooCommerceCore.NET.Tests
{
    public class BaseTests
    {
        protected JsonRestClient RestClient { get; private set; }

        [SetUp]
        public async Task TestServerReachable()
        {
            RestClient = new JsonRestClient("https://bike.joelluijmes.nl/wp-json/wc/v2/", "ck_907833f04d2a0e269fc00e19ee4bc020bc25963f", "cs_f4ea0836e7ebf4a506168d7bc65d2f6785366829");
            var response = await RestClient.GetJsonAsync("system_status");
            var version = response.SelectToken("$.environment.version");

            Assert.IsNotNull(version, "Couldn't get version of test target");
        }
    }

    [TestFixture]
    public sealed class CategoryRepositoryIntegrationTest : BaseTests
    {
        private CategoryRepository _categoryRepository;
        private Category _createdCategory;

        [SetUp]
        public void Initialize()
        {
            _categoryRepository = new CategoryRepository(RestClient);
        }

        [Test]
        [Order(1)]
        [Description("Create a category")]
        public async Task CreateCategory()
        {
            _createdCategory = await _categoryRepository.CreateAsync(new Category { Name = "test-category" });
            Assert.IsNotNull(_createdCategory);
        }

        [Test]
        [Order(2)]
        [Description("Retrieve the created category by id")]

        public async Task RetrieveCategory()
        {
            var retrievedCategory = await _categoryRepository.Retrieve(_createdCategory.Id);
            Assert.AreEqual(_createdCategory, retrievedCategory);
        }

        [Test]
        [Order(2)]
        [Description("List all categories, and check if it contains the created category")]

        public async Task ListCategory()
        {
            var categories = await _categoryRepository.ListEntitiesAsync();
            Assert.Contains(_createdCategory, categories.ToArray());
        }

        [Test]
        [Order(3)]
        [Description("Delete the created category")]
        public async Task DeleteCategory()
        {
            var deletedCategory = await _categoryRepository.DeleteAsync(_createdCategory);
            Assert.AreEqual(_createdCategory, deletedCategory);
        }

        [Test]
        [Order(4)]
        [Description("Fails on retrieving the deleted category by id")]

        public async Task FailRetrieveDeletedCategory()
        {
            var retrievedCategory = await _categoryRepository.Retrieve(_createdCategory.Id);
            Assert.IsNull(retrievedCategory);
        }
    }
}
