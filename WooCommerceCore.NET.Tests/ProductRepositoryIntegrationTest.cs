
using System.Threading.Tasks;
using NUnit.Framework;
using WooCommerceCore.NET.Entities.Products;
using WooCommerceCore.NET.Exceptions;
using WooCommerceCore.NET.Repositories.Products;

namespace WooCommerceCore.NET.Tests
{
    [TestFixture]
    internal sealed class ProductRepositoryIntegrationTest : BaseTests
    {
        [SetUp]
        public void Initialize()
        {
            _productRepository = new ProductRepository(RestClient);
        }

        private ProductRepository _productRepository;
        private Product _createdProduct;

        [Test]
        [Order(1)]
        [Description("Create a product")]
        public async Task CreateProduct()
        {
            _createdProduct = await _productRepository.CreateAsync(new Product
            {
                Name = "test-product",
                CatalogVisibility = "visible"
            });

            Assert.IsNotNull(_createdProduct);
        }

        [Test]
        [Order(3)]
        [Description("Delete the created product")]
        public async Task DeleteProduct()
        {
            var deletedProduct = await _productRepository.DeleteAsync(_createdProduct);
            Assert.AreEqual(_createdProduct, deletedProduct);
        }

        [Test]
        [Order(4)]
        [Description("Fails on retrieving the deleted product by id")]
        public void FailRetrieveDeletedProduct()
        {
            Assert.ThrowsAsync<RestException>(async () =>
            {
                await _productRepository.RetrieveAsync(_createdProduct.Id);
            });
        }

        [Test]
        [Order(2)]
        [Description("List all categories, and check if it contains the created product")]
        public async Task ListProduct()
        {
            var categories = await _productRepository.ListAsync();
            CollectionAssert.Contains(categories, _createdProduct);
        }

        [Test]
        [Order(2)]
        [Description("Retrieve the created product by id")]
        public async Task RetrieveProduct()
        {
            var retrievedProduct = await _productRepository.RetrieveAsync(_createdProduct.Id);
            Assert.AreEqual(_createdProduct, retrievedProduct);
        }
    }
}
