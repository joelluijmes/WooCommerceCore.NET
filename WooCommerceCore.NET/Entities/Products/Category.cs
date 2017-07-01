using Newtonsoft.Json;

namespace WooCommerceCore.NET.Entities.Products
{
    public sealed class Category : IEntity
    {
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

        [JsonProperty("id")]
        public int Id { get; set; }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is Category && Equals((Category) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Count;
                hashCode = (hashCode * 397) ^ (Description != null ? Description.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Display != null ? Display.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Id;
                hashCode = (hashCode * 397) ^ MenuOrder;
                hashCode = (hashCode * 397) ^ (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Parent;
                hashCode = (hashCode * 397) ^ (Slug != null ? Slug.GetHashCode() : 0);
                return hashCode;
            }
        }

        public static bool operator ==(Category left, Category right) => Equals(left, right);

        public static bool operator !=(Category left, Category right) => !Equals(left, right);

        public override string ToString() => Name;

        private bool Equals(Category other) => Count == other.Count &&
                                               string.Equals(Description, other.Description) &&
                                               string.Equals(Display, other.Display) &&
                                               Id == other.Id &&
                                               MenuOrder == other.MenuOrder &&
                                               string.Equals(Name, other.Name) &&
                                               Parent == other.Parent &&
                                               string.Equals(Slug, other.Slug);
    }
}
