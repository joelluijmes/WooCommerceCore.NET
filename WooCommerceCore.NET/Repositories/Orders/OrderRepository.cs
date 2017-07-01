using WooCommerceCore.NET.Entities.Orders;
using WooCommerceCore.NET.REST;

namespace WooCommerceCore.NET.Repositories.Orders
{
    public sealed class OrderRepository : BaseWooCommerceRepository<Order>
    {
        public OrderRepository(IJsonRestClient jsonClient) : base(jsonClient, "orders") { }
    }
}
