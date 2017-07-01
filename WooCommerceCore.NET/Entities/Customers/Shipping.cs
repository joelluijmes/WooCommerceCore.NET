using Newtonsoft.Json;

namespace WooCommerceCore.NET.Entities.Customers
{
    public sealed class Shipping
    {
        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("company")]
        public string Company { get; set; }

        [JsonProperty("address_1")]
        public string Address1 { get; set; }

        [JsonProperty("address_2")]
        public string Address2 { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("postcode")]
        public string Postcode { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is Shipping && Equals((Shipping) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Address1 != null ? Address1.GetHashCode() : 0;
                hashCode = (hashCode * 397) ^ (Address2 != null ? Address2.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (City != null ? City.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Company != null ? Company.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Country != null ? Country.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (FirstName != null ? FirstName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (LastName != null ? LastName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Postcode != null ? Postcode.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (State != null ? State.GetHashCode() : 0);
                return hashCode;
            }
        }

        public static bool operator ==(Shipping left, Shipping right) => Equals(left, right);

        public static bool operator !=(Shipping left, Shipping right) => !Equals(left, right);

        private bool Equals(Shipping other) => string.Equals(Address1, other.Address1) &&
                                               string.Equals(Address2, other.Address2) &&
                                               string.Equals(City, other.City) &&
                                               string.Equals(Company, other.Company) &&
                                               string.Equals(Country, other.Country) &&
                                               string.Equals(FirstName, other.FirstName) &&
                                               string.Equals(LastName, other.LastName) &&
                                               string.Equals(Postcode, other.Postcode) &&
                                               string.Equals(State, other.State);
    }
}
