using System.Threading.Tasks;
using NUnit.Framework;
using WooCommerceCore.NET.Entities.Orders;
using WooCommerceCore.NET.Exceptions;
using WooCommerceCore.NET.Repositories.Orders;

namespace WooCommerceCore.NET.Tests
{
    [TestFixture]
    internal sealed class OrderRepositoryIntegrationTest : BaseTests
    {
        [SetUp]
        public void Initialize()
        {
            _orderRepository = new OrderRepository(RestClient);
        }

        private OrderRepository _orderRepository;
        private Order _createdOrder;

        [Test]
        [Order(1)]
        [Description("Create a order")]
        public async Task CreateOrder()
        {
            _createdOrder = await _orderRepository.CreateAsync(new Order()); 

            Assert.IsNotNull(_createdOrder);
        }

        [Test]
        [Order(3)]
        [Description("Delete the created order")]
        public async Task DeleteOrder()
        {
            var deletedOrder = await _orderRepository.DeleteAsync(_createdOrder);
            Assert.AreEqual(_createdOrder, deletedOrder);
        }

        [Test]
        [Order(4)]
        [Description("Fails on retrieving the deleted order by id")]
        public void FailRetrieveDeletedOrder()
        {
            Assert.ThrowsAsync<RestException>(async () =>
            {
                await _orderRepository.RetrieveAsync(_createdOrder.Id);
            });
        }

        [Test]
        [Order(2)]
        [Description("List all categories, and check if it contains the created order")]
        public async Task ListOrder()
        {
            var categories = await _orderRepository.ListAsync();
            CollectionAssert.Contains(categories, _createdOrder);
        }

        [Test]
        [Order(2)]
        [Description("Retrieve the created order by id")]
        public async Task RetrieveOrder()
        {
            var retrievedOrder = await _orderRepository.RetrieveAsync(_createdOrder.Id);
            Assert.AreEqual(_createdOrder, retrievedOrder);
        }
    }
}
