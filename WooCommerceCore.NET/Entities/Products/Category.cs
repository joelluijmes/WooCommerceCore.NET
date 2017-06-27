using Newtonsoft.Json;

namespace WooCommerceCore.NET.Models.Products
{
    public sealed class Category : IEntity
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("parent")]
        public int Parent { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("display")]
        public string Display { get; set; }

        //[JsonProperty("image")]
        //public IList<object> Image { get; set; }

        [JsonProperty("menu_order")]
        public int MenuOrder { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }

        public override string ToString() => Name;
    }
}
