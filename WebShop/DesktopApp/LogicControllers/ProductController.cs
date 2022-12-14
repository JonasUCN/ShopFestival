using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DesktopApp.ServiceLayer;
using DesktopApp.ModelLayer;

namespace DesktopApp.LogicControllers
{

    /// <summary>
    /// This is the ProductController class
    /// It implements the IProductController interface, providing methods for managing products
    /// </summary>
    public class ProductController : IProductController
    {
        /// <summary>
        /// A reference to the product data access object
        /// </summary>
        IProductAccess dataAccess;

        /// <summary>
        /// A constructor that initializes the data access object
        /// </summary>
        /// <param name="productAccess">The product access object to use</param>
        public ProductController(IProductAccess productAccess)
        {
            dataAccess = productAccess;
        }

        /// <summary>
        /// Creates a new product with the specified properties
        /// </summary>
        /// <param name="price">The price of the product</param>
        /// <param name="stock">The number of items in stock</param>
        /// <param name="productDesc">The description of the product</param>
        /// <param name="brand">The brand of the product</param>
        /// <param name="title">The title of the product</param>
        /// <returns>True if the product was successfully created, or false otherwise</returns>
        public bool createProduct(decimal price, int stock, string productDesc, string brand, string title)
        {
            bool success = false;

            try
            {
                // Check that the price and stock values are valid
                if (price >= 0 && stock >= 0)
                {
                    // Create the product object and insert it into the database
                    Product product = new Product() { Price = price, Stock = stock, ProductDesc = productDesc, Brand = brand, Title = title };
                    dataAccess.InsertProduct(product);
                    success = true;
                }
            }
            catch (Exception)
            {
                // If an exception occurred, re-throw it
                throw;
            }

            // Return the success value
            return success;
        }

        // Gets a list of all products
        /// <summary>
        /// Gets a list of all products
        /// </summary>
        /// <returns>A list of all products</returns>
        public List<Product> GetProducts()
        {
            // Retrieve the products from the database and return them
            List<Product> products = dataAccess.GetAllProducts();
            return products;
        }
    }
}