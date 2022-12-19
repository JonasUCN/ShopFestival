using WebShop.Models;

namespace WebShop.LogicControllers
{
    /// <summary>
    /// Defines methods for managing products in a web shop application.
    /// </summary>
    public interface IProductLogicController
    {
        /// <summary>
        /// Retrieves a list of products from a remote service.
        /// </summary>
        /// <returns>A list of products.</returns>
        List<Product> GetProductsFromService();

        /// <summary>
        /// Retrieves a specific product from a remote service by ID.
        /// </summary>
        /// <param name="id">The ID of the product to be retrieved.</param>
        /// <returns>The product with the specified ID.</returns>
        Product GetProductFromServiceByID(int id);

        /// <summary>
        /// Adds a product to the user's cart.
        /// </summary>
        /// <param name="id">The ID of the product to be added to the cart.</param>
        /// <param name="http">The current HTTP context.</param>
        /// <returns>A list of products in the user's cart, including the added product.</returns>
        List<Product> AddProductToCart(int id, HttpContext http);
    }
}