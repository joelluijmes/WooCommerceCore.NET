using System.Threading.Tasks;
using NUnit.Framework;
using WooCommerceCore.NET.Entities.Products;
using WooCommerceCore.NET.Exceptions;
using WooCommerceCore.NET.Repositories.Products;

namespace WooCommerceCore.NET.Tests
{
    [TestFixture]
    public sealed class CategoryRepositoryIntegrationTest : BaseTests
    {
        [SetUp]
        public void Initialize()
        {
            _categoryRepository = new CategoryRepository(RestClient);
        }

        private CategoryRepository _categoryRepository;
        private Category _createdCategory;

        [Test]
        [Order(1)]
        [Description("Create a category")]
        public async Task CreateCategory()
        {
            _createdCategory = await _categoryRepository.CreateAsync(new Category {Name = "test-category"});
            Assert.IsNotNull(_createdCategory);
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
        public void FailRetrieveDeletedCategory()
        {
            Assert.ThrowsAsync<RestException>(async () =>
            {
                await _categoryRepository.RetrieveAsync(_createdCategory.Id);
            });
        }

        [Test]
        [Order(2)]
        [Description("List all categories, and check if it contains the created category")]
        public async Task ListCategory()
        {
            var categories = await _categoryRepository.ListAsync();
            CollectionAssert.Contains(categories, _createdCategory);
        }

        [Test]
        [Order(2)]
        [Description("Retrieve the created category by id")]
        public async Task RetrieveCategory()
        {
            var retrievedCategory = await _categoryRepository.RetrieveAsync(_createdCategory.Id);
            Assert.AreEqual(_createdCategory, retrievedCategory);
        }
    }
}
