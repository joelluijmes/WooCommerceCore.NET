using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace WooCommerceCore.NET.Entities.Products
{
    public sealed class Product : IEntity
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("permalink")]
        public string Permalink { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("featured")]
        public bool Featured { get; set; }

        [JsonProperty("catalog_visibility")]
        public string CatalogVisibility { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("short_description")]
        public string ShortDescription { get; set; }

        [JsonProperty("sku")]
        public string Sku { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }

        [JsonProperty("regular_price")]
        public string RegularPrice { get; set; }

        [JsonProperty("sale_price")]
        public string SalePrice { get; set; }

        [JsonProperty("price_html")]
        public string PriceHtml { get; set; }

        [JsonProperty("on_sale")]
        public bool OnSale { get; set; }

        [JsonProperty("purchasable")]
        public bool Purchasable { get; set; }

        [JsonProperty("total_sales")]
        public int TotalSales { get; set; }

        [JsonProperty("virtual")]
        public bool Virtual { get; set; }

        [JsonProperty("external_url")]
        public string ExternalUrl { get; set; }

        [JsonProperty("tax_status")]
        public string TaxStatus { get; set; }

        [JsonProperty("tax_class")]
        public string TaxClass { get; set; }

        [JsonProperty("manage_stock")]
        public bool ManageStock { get; set; }

        [JsonProperty("stock_quantity")]
        public object StockQuantity { get; set; }

        [JsonProperty("in_stock")]
        public bool InStock { get; set; }

        [JsonProperty("related_ids")]
        public IList<int> RelatedIds { get; set; }

        [JsonProperty("parent_id")]
        public int ParentId { get; set; }

        [JsonProperty("categories")]
        public IList<Category> Categories { get; set; }

        [JsonProperty("tags")]
        public IList<object> Tags { get; set; }

        [JsonProperty("images")]
        public IList<Image> Images { get; set; }

        [JsonProperty("attributes")]
        public IList<Attribute> Attributes { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is Product && Equals((Product) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Attributes != null ? Attributes.GetHashCode() : 0;
                hashCode = (hashCode * 397) ^ (CatalogVisibility != null ? CatalogVisibility.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Categories != null ? Categories.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Description != null ? Description.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ExternalUrl != null ? ExternalUrl.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Featured.GetHashCode();
                hashCode = (hashCode * 397) ^ Id;
                hashCode = (hashCode * 397) ^ (Images != null ? Images.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ InStock.GetHashCode();
                hashCode = (hashCode * 397) ^ ManageStock.GetHashCode();
                hashCode = (hashCode * 397) ^ (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ OnSale.GetHashCode();
                hashCode = (hashCode * 397) ^ ParentId;
                hashCode = (hashCode * 397) ^ (Permalink != null ? Permalink.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Price != null ? Price.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (PriceHtml != null ? PriceHtml.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Purchasable.GetHashCode();
                hashCode = (hashCode * 397) ^ (RegularPrice != null ? RegularPrice.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (RelatedIds != null ? RelatedIds.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (SalePrice != null ? SalePrice.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ShortDescription != null ? ShortDescription.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Sku != null ? Sku.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Slug != null ? Slug.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Status != null ? Status.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (StockQuantity != null ? StockQuantity.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Tags != null ? Tags.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (TaxClass != null ? TaxClass.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (TaxStatus != null ? TaxStatus.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ TotalSales;
                hashCode = (hashCode * 397) ^ (Type != null ? Type.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Virtual.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(Product left, Product right) => Equals(left, right);

        public static bool operator !=(Product left, Product right) => !Equals(left, right);

        private bool Equals(Product other) => Attributes.SequenceEqual(Attributes) &&
                                              string.Equals(CatalogVisibility, other.CatalogVisibility) &&
                                              Categories.SequenceEqual(other.Categories) &&
                                              string.Equals(Description, other.Description) &&
                                              string.Equals(ExternalUrl, other.ExternalUrl) &&
                                              Featured == other.Featured &&
                                              Id == other.Id &&
                                              Images.SequenceEqual(other.Images) &&
                                              InStock == other.InStock &&
                                              ManageStock == other.ManageStock &&
                                              string.Equals(Name, other.Name) &&
                                              OnSale == other.OnSale &&
                                              ParentId == other.ParentId &&
                                              string.Equals(Permalink, other.Permalink) &&
                                              string.Equals(Price, other.Price) &&
                                              string.Equals(PriceHtml, other.PriceHtml) &&
                                              Purchasable == other.Purchasable &&
                                              string.Equals(RegularPrice, other.RegularPrice) &&
                                              RelatedIds.SequenceEqual(other.RelatedIds) &&
                                              string.Equals(SalePrice, other.SalePrice) &&
                                              string.Equals(ShortDescription, other.ShortDescription) &&
                                              string.Equals(Sku, other.Sku) &&
                                              string.Equals(Slug, other.Slug) &&
                                              string.Equals(Status, other.Status) &&
                                              Equals(StockQuantity, other.StockQuantity) &&
                                              Tags.SequenceEqual(other.Tags) &&
                                              string.Equals(TaxClass, other.TaxClass) &&
                                              string.Equals(TaxStatus, other.TaxStatus) &&
                                              TotalSales == other.TotalSales &&
                                              string.Equals(Type, other.Type) &&
                                              Virtual == other.Virtual;
    }
}
