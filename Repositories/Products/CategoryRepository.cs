using WooCommerceCore.NET.Models.Products;

namespace WooCommerceCore.NET.Repositories.Products
{
    public sealed class CategoryRepository : BaseWooCommerceRepository<Category>
    {
        public CategoryRepository(JsonRestClient jsonClient) : base(jsonClient, "products/categories") { }
    }
}
