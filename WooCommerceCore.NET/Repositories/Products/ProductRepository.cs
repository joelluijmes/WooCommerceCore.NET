using WooCommerceCore.NET.Entities.Products;
using WooCommerceCore.NET.REST;

namespace WooCommerceCore.NET.Repositories.Products
{
    public sealed class ProductRepository : BaseWooCommerceRepository<Product>
    {
        public ProductRepository(IJsonRestClient jsonClient) : base(jsonClient, "products") { }
    }
}
