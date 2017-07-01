using WooCommerceCore.NET.Entities.Customers;
using WooCommerceCore.NET.REST;

namespace WooCommerceCore.NET.Repositories.Customers
{
    public sealed class CustomerRepository : BaseWooCommerceRepository<Customer>
    {
        public CustomerRepository(IJsonRestClient jsonClient) : base(jsonClient, "customers") { }
    }
}
