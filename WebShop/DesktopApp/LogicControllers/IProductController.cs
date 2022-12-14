using DesktopApp.ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp.LogicControllers
{
    /// <summary>
    /// This is the IProductController interface
    /// It defines a set of methods for managing products
    /// </summary>
    internal interface IProductController
    {
        /// <summary>
        /// Creates a new product with the specified properties
        /// </summary>
        /// <param name="price">The price of the product</param>
        /// <param name="stock">The number of items in stock</param>
        /// <param name="productDesc">The description of the product</param>
        /// <param name="brand">The brand of the product</param>
        /// <param name="title">The title of the product</param>
        /// <returns>True if the product was successfully created, or false otherwise</returns>
        bool createProduct(decimal price, int stock, string productDesc, string brand, string title);

        /// <summary>
        /// Gets a list of all products
        /// </summary>
        /// <returns>A list of all products</returns>
        List<Product> GetProducts();
    }
}