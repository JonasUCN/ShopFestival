using Database_Service.Model;

namespace Database_Service.LogicController
{
    public interface ILogicProductController
    {
        /// <summary>
        /// Retrieves a list of all products in the database.
        /// </summary>
        /// <returns>A list of products.</returns>
        Task<List<Product>> GetAllProducts();

        /// <summary>
        /// Retrieves a product from the database with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the product to retrieve.</param>
        /// <returns>The product with the specified ID, or null if no such product exists.</returns>
        Task<Product> GetProductByID(int id);

        /// <summary>
        /// Adds a new product to the database.
        /// </summary>
        /// <param name="product">The product to add to the database.</param>
        /// <returns>True if the product was added successfully, false otherwise.<
        Task<bool> CreateProduct(Product product);

        //Not implemented
        //Task<bool> RemoveStockOnProductById(int id);

        /// <summary>
        /// Increases the stock for a product with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the product to update.</param>
        /// <returns>True if the stock was updated successfully, false otherwise.</returns>
        Task<bool> IncreaseStockOnProductById(int id);
    }
}
