using Newtonsoft.Json;

namespace WooCommerceCore.NET.Entities.Products
{
    public sealed class Image
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("src")]
        public string Source { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("alt")]
        public string Alt { get; set; }

        [JsonProperty("position")]
        public int Position { get; set; }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is Image && Equals((Image) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Alt != null ? Alt.GetHashCode() : 0;
                hashCode = (hashCode * 397) ^ Id;
                hashCode = (hashCode * 397) ^ (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Position;
                hashCode = (hashCode * 397) ^ (Source != null ? Source.GetHashCode() : 0);
                return hashCode;
            }
        }

        public static bool operator ==(Image left, Image right) => Equals(left, right);

        public static bool operator !=(Image left, Image right) => !Equals(left, right);

        private bool Equals(Image other) => string.Equals(Alt, other.Alt) &&
                                            Id == other.Id &&
                                            string.Equals(Name, other.Name) &&
                                            Position == other.Position &&
                                            string.Equals(Source, other.Source);
    }
}
