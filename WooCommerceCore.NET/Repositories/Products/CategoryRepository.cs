using WooCommerceCore.NET.Entities.Products;
using WooCommerceCore.NET.REST;

namespace WooCommerceCore.NET.Repositories.Products
{
    public sealed class CategoryRepository : BaseWooCommerceRepository<Category>
    {
        public CategoryRepository(IJsonRestClient jsonClient) : base(jsonClient, "products/categories") { }
    }
}
