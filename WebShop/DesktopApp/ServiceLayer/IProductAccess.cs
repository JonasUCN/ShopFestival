using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesktopApp.ModelLayer;

namespace DesktopApp.ServiceLayer
{
    /// <summary>
    /// This is the IProductAccess interface.
    /// It defines a set of methods for accessing product data.
    /// </summary>
    public interface IProductAccess
    {
        /// <summary>
        /// Inserts a new product into the database.
        /// </summary>
        /// <param name="product">The product to insert.</param>
        /// <returns>True if the product was successfully inserted, false otherwise.</returns>
        public bool InsertProduct(Product product);

        /// <summary>
        /// Gets a product by its ID.
        /// </summary>
        /// <param name="id">The ID of the product to retrieve.</param>
        /// <returns>The product with the specified ID, or null if no such product exists.</returns>
        public Product GetProductByID(int id);

        /// <summary>
        /// Gets a list of all products in the database.
        /// </summary>
        /// <returns>A list of all products in the database.</returns>
        public List<Product> GetAllProducts();
    }
}
