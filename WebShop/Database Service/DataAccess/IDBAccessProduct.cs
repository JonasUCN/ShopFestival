using ModelLayer;

namespace Database_Service.DataAccess
{
    public interface IDBAccessProduct
    {
        Task<List<Product>> GetAllProducts();
        Task<Product> GetProductByID(int id);
        Task UpdateProductById(Product product);
        Task RemoveStockOnProductById(Product product);
        Task IncreaseStockOnProductById(Product product);
        Task<bool> CreateProduct(Product product);
        Task DeleteProductById(int id);
    }
}
