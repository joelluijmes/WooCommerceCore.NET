# WooCommerce API - .NET Core Client
A .NET Core wrapper for the WooCommerce REST API. Easily interact with the WooCommerce REST API from .NET Core securely using this library, note that it only supports https (BasicAuth.)

### Requirements
WooCommerceCore.NET - .NET Standard 1.6 | .NET Core 1.0 | .NET 4.6.1

### Example
All repositories inherit from IRepository interface:
```cs
public interface IRepository<T>
    where T : IEntity
{
    Task<T> CreateAsync(T entity);
    Task<T> DeleteAsync(T entity);
    Task<IList<T>> ListAsync();
    Task<T> RetrieveAsync(int id);
    Task<T> UpdateAsync(T entity);
}
```

##### Creating a Product
```cs
var product = await _productRepository.CreateAsync(new Product
{
    Name = "test-product",
    CatalogVisibility = "visible"
});
```

##### Deleting a Product
```cs
var product = await _productRepository.DeleteAsync(product);
```

##### Listing all Products
```cs
var products = await _productRepository.ListAsync();
```

##### Retrieving a Product
```cs
var product = await _productRepository.RetrieveAsync(1);
```

##### Updating a Product
```cs
var alteredProduct = await _productRepository.UpdateAsync(product);
```
