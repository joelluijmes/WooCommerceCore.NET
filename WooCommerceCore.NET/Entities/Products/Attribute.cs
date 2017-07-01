using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace WooCommerceCore.NET.Entities.Products
{
    public sealed class Attribute
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("position")]
        public int Position { get; set; }

        [JsonProperty("visible")]
        public bool Visible { get; set; }

        [JsonProperty("variation")]
        public bool Variation { get; set; }

        [JsonProperty("options")]
        public IList<string> Options { get; set; }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is Attribute && Equals((Attribute) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Id;
                hashCode = (hashCode * 397) ^ (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Options != null ? Options.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Position;
                hashCode = (hashCode * 397) ^ Variation.GetHashCode();
                hashCode = (hashCode * 397) ^ Visible.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(Attribute left, Attribute right) => Equals(left, right);

        public static bool operator !=(Attribute left, Attribute right) => !Equals(left, right);

        private bool Equals(Attribute other) => Id == other.Id &&
                                                string.Equals(Name, other.Name) &&
                                                Options.SequenceEqual(other.Options) &&
                                                Position == other.Position &&
                                                Variation == other.Variation &&
                                                Visible == other.Visible;
    }
}
