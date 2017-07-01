using Newtonsoft.Json;
using WooCommerceCore.NET.Entities.Customers;

namespace WooCommerceCore.NET.Entities.Orders
{
    public class Order : IEntity
    {
        [JsonProperty("parent_id")]
        public int ParentId { get; set; }

        [JsonProperty("number")]
        public string Number { get; set; }

        [JsonProperty("order_key")]
        public string OrderKey { get; set; }

        [JsonProperty("created_via")]
        public string CreatedVia { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("discount_total")]
        public string DiscountTotal { get; set; }

        [JsonProperty("discount_tax")]
        public string DiscountTax { get; set; }

        [JsonProperty("shipping_total")]
        public string ShippingTotal { get; set; }

        [JsonProperty("shipping_tax")]
        public string ShippingTax { get; set; }

        [JsonProperty("cart_tax")]
        public string CartTax { get; set; }

        [JsonProperty("total")]
        public string Total { get; set; }

        [JsonProperty("total_tax")]
        public string TotalTax { get; set; }

        [JsonProperty("prices_include_tax")]
        public bool PricesIncludeTax { get; set; }

        [JsonProperty("customer_id")]
        public int CustomerId { get; set; }

        [JsonProperty("customer_ip_address")]
        public string CustomerIpAddress { get; set; }

        [JsonProperty("customer_user_agent")]
        public string CustomerUserAgent { get; set; }

        [JsonProperty("customer_note")]
        public string CustomerNote { get; set; }

        [JsonProperty("billing")]
        public Billing Billing { get; set; }

        [JsonProperty("shipping")]
        public Shipping Shipping { get; set; }

        [JsonProperty("payment_method")]
        public string PaymentMethod { get; set; }

        [JsonProperty("payment_method_title")]
        public string PaymentMethodTitle { get; set; }

        [JsonProperty("transaction_id")]
        public string TransactionId { get; set; }

        [JsonProperty("cart_hash")]
        public string CartHash { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != GetType())
                return false;

            return Equals((Order) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Billing != null ? Billing.GetHashCode() : 0;
                hashCode = (hashCode * 397) ^ (CartHash != null ? CartHash.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (CartTax != null ? CartTax.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (CreatedVia != null ? CreatedVia.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Currency != null ? Currency.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ CustomerId;
                hashCode = (hashCode * 397) ^ (CustomerIpAddress != null ? CustomerIpAddress.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (CustomerNote != null ? CustomerNote.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (CustomerUserAgent != null ? CustomerUserAgent.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (DiscountTax != null ? DiscountTax.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (DiscountTotal != null ? DiscountTotal.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Id;
                hashCode = (hashCode * 397) ^ (Number != null ? Number.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (OrderKey != null ? OrderKey.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ ParentId;
                hashCode = (hashCode * 397) ^ (PaymentMethod != null ? PaymentMethod.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (PaymentMethodTitle != null ? PaymentMethodTitle.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ PricesIncludeTax.GetHashCode();
                hashCode = (hashCode * 397) ^ (Shipping != null ? Shipping.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ShippingTax != null ? ShippingTax.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ShippingTotal != null ? ShippingTotal.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Status != null ? Status.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Total != null ? Total.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (TotalTax != null ? TotalTax.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (TransactionId != null ? TransactionId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Version != null ? Version.GetHashCode() : 0);
                return hashCode;
            }
        }

        public static bool operator ==(Order left, Order right) => Equals(left, right);

        public static bool operator !=(Order left, Order right) => !Equals(left, right);

        protected bool Equals(Order other) => Equals(Billing, other.Billing) &&
                                              string.Equals(CartHash, other.CartHash) &&
                                              string.Equals(CartTax, other.CartTax) &&
                                              string.Equals(CreatedVia, other.CreatedVia) &&
                                              string.Equals(Currency, other.Currency) &&
                                              CustomerId == other.CustomerId &&
                                              string.Equals(CustomerIpAddress, other.CustomerIpAddress) &&
                                              string.Equals(CustomerNote, other.CustomerNote) &&
                                              string.Equals(CustomerUserAgent, other.CustomerUserAgent) &&
                                              string.Equals(DiscountTax, other.DiscountTax) &&
                                              string.Equals(DiscountTotal, other.DiscountTotal) &&
                                              Id == other.Id &&
                                              string.Equals(Number, other.Number) &&
                                              string.Equals(OrderKey, other.OrderKey) &&
                                              ParentId == other.ParentId &&
                                              string.Equals(PaymentMethod, other.PaymentMethod) &&
                                              string.Equals(PaymentMethodTitle, other.PaymentMethodTitle) &&
                                              PricesIncludeTax == other.PricesIncludeTax &&
                                              Equals(Shipping, other.Shipping) &&
                                              string.Equals(ShippingTax, other.ShippingTax) &&
                                              string.Equals(ShippingTotal, other.ShippingTotal) &&
                                              string.Equals(Status, other.Status) &&
                                              string.Equals(Total, other.Total) &&
                                              string.Equals(TotalTax, other.TotalTax) &&
                                              string.Equals(TransactionId, other.TransactionId) &&
                                              string.Equals(Version, other.Version);
    }
}
