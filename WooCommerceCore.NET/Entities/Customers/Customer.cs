using Newtonsoft.Json;

namespace WooCommerceCore.NET.Entities.Customers
{
    public sealed class Customer : IEntity
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("billing")]
        public Billing Billing { get; set; }

        [JsonProperty("shipping")]
        public Shipping Shipping { get; set; }

        [JsonProperty("is_paying_customer")]
        public bool IsPayingCustomer { get; set; }

        [JsonProperty("orders_count")]
        public int OrdersCount { get; set; }

        [JsonProperty("total_spent")]
        public string TotalSpent { get; set; }

        [JsonProperty("avatar_url")]
        public string AvatarUrl { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is Customer && Equals((Customer) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = AvatarUrl != null ? AvatarUrl.GetHashCode() : 0;
                hashCode = (hashCode * 397) ^ (Billing != null ? Billing.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Email != null ? Email.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (FirstName != null ? FirstName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Id;
                hashCode = (hashCode * 397) ^ IsPayingCustomer.GetHashCode();
                hashCode = (hashCode * 397) ^ (LastName != null ? LastName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ OrdersCount;
                hashCode = (hashCode * 397) ^ (Password != null ? Password.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Role != null ? Role.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Shipping != null ? Shipping.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (TotalSpent != null ? TotalSpent.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Username != null ? Username.GetHashCode() : 0);
                return hashCode;
            }
        }

        public static bool operator ==(Customer left, Customer right) => Equals(left, right);

        public static bool operator !=(Customer left, Customer right) => !Equals(left, right);

        private bool Equals(Customer other) => string.Equals(AvatarUrl, other.AvatarUrl) &&
                                               Equals(Billing, other.Billing) &&
                                               string.Equals(Email, other.Email) &&
                                               string.Equals(FirstName, other.FirstName) &&
                                               Id == other.Id &&
                                               IsPayingCustomer == other.IsPayingCustomer &&
                                               string.Equals(LastName, other.LastName) &&
                                               OrdersCount == other.OrdersCount &&
                                               string.Equals(Password, other.Password) &&
                                               string.Equals(Role, other.Role) &&
                                               Equals(Shipping, other.Shipping) &&
                                               string.Equals(TotalSpent, other.TotalSpent) &&
                                               string.Equals(Username, other.Username);
    }
}
