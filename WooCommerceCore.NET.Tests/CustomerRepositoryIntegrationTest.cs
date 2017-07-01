
using System.Threading.Tasks;
using NUnit.Framework;
using WooCommerceCore.NET.Entities.Customers;
using WooCommerceCore.NET.Exceptions;
using WooCommerceCore.NET.Repositories.Customers;

namespace WooCommerceCore.NET.Tests
{
    [TestFixture]
    internal sealed class CustomerRepositoryIntegrationTest : BaseTests
    {
        [SetUp]
        public void Initialize()
        {
            _customerRepository = new CustomerRepository(RestClient);
        }

        private CustomerRepository _customerRepository;
        private Customer _createdCustomer;

        [Test]
        [Order(1)]
        [Description("Create a customer")]
        public async Task CreateCustomer()
        {
            _createdCustomer = await _customerRepository.CreateAsync(new Customer
            {
                Email = "example@example.com",
                Password = "password",
                Username = "username"
            });

            Assert.IsNotNull(_createdCustomer);
        }

        [Test]
        [Order(3)]
        [Description("Delete the created customer")]
        public async Task DeleteCustomer()
        {
            var deletedCustomer = await _customerRepository.DeleteAsync(_createdCustomer);
            Assert.AreEqual(_createdCustomer, deletedCustomer);
        }

        [Test]
        [Order(4)]
        [Description("Fails on retrieving the deleted customer by id")]
        public void FailRetrieveDeletedCustomer()
        {
            Assert.ThrowsAsync<RestException>(async () =>
            {
                await _customerRepository.RetrieveAsync(_createdCustomer.Id);
            });
        }

        [Test]
        [Order(2)]
        [Description("List all categories, and check if it contains the created customer")]
        public async Task ListCustomer()
        {
            var categories = await _customerRepository.ListAsync();
            CollectionAssert.Contains(categories, _createdCustomer);
        }

        [Test]
        [Order(2)]
        [Description("Retrieve the created customer by id")]
        public async Task RetrieveCustomer()
        {
            var retrievedCustomer = await _customerRepository.RetrieveAsync(_createdCustomer.Id);
            Assert.AreEqual(_createdCustomer, retrievedCustomer);
        }
    }
}
