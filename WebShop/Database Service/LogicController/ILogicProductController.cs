using Database_Service.Model;

namespace Database_Service.LogicController
{
    public interface ILogicProductController
    {
        Task<List<Product>> GetAllProducts();

        Task<Product> GetProductByID(int id);

        Task<bool> CreateProduct(Product product);

        Task<bool> RemoveStockOnProductById(int id);

        Task<bool> IncreaseStockOnProductById(int id);
    }
}
