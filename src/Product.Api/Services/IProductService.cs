using ProductApi.Model;

namespace ProductApi.Services;

public interface IProductService
{
    Task TakeProduct(int count, int productId);

    Task<int> CreateProduct(Product product);
    Task<Product> AddProduct(int id, int count);
    Task<IList<Product>> TakeProducts(Dictionary<int, int> productCounts);
    Task ReturnProducts(Dictionary<int, int> productCounts);
}
