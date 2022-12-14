using Database_Service.Model;

namespace Database_Service.DataAccess
{
    /// <summary>
    /// An interface for accessing and modifying products in a database.
    /// </summary>
    public interface IDBAccessProduct
    {
        /// <summary>
        /// Get all products from the database
        /// </summary>
        Task<List<Product>> GetAllProducts();

        /// <summary>
        /// Get a single product from the database by ID
        /// </summary>
        Task<Product> GetProductByID(int id);

        /// <summary>
        /// Update a product in the database by ID
        /// </summary>
        Task UpdateProductById(Product product);

        /// <summary>
        /// Increase the stock on a product in the database by ID
        /// </summary>
        Task IncreaseStockOnProductById(Product product);

        /// <summary>
        /// Create a new product in the database
        /// </summary>
        Task<bool> CreateProduct(Product product);

        /// <summary>
        /// Delete a product from the database by ID
        /// </summary>
        Task DeleteProductById(int id);
    }
}
