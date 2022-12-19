using Database_Service.DataAccess;
using Database_Service.Model;

namespace Database_Service.LogicController
{
    public class LogicProductController : ILogicProductController
    {

        /// <summary>
        /// The object responsible for accessing the product database
        /// </summary>
        private readonly DBAccessProduct dBAccessProduct;

        /// <summary>
        /// Initializes a new instance of the <see cref="LogicProductController"/> class
        /// </summary>
        public LogicProductController()
        {
            this.dBAccessProduct = dBAccessProduct;
        }

        /// <summary>
        /// Returns a list of all products in the database
        /// </summary>
        /// <returns>A list of all products in the database</returns>
        public async Task<List<Product> >GetAllProducts()
        {
            List<Product> products = await dBAccessProduct.GetAllProducts();
            return  products;

        }

        /// <summary>
        /// Returns the product with the specified ID from the database
        /// </summary>
        /// <param name="id">The ID of the product to retrieve</param>
        /// <returns>The product with the specified ID</returns>
        public async Task<Product> GetProductByID(int id)
        {
            Product p = await dBAccessProduct.GetProductByID(id);
            return p;
        }

        /// <summary>
        /// Creates a new product in the database
        /// </summary>
        /// <param name="product">The product to create</param>
        /// <returns>True if the product was created successfully, false otherwise</returns>
        public async Task<bool> CreateProduct(Product product)
        {
            bool succes = await dBAccessProduct.CreateProduct(product);
            return succes;
        }

        /// <summary>
        /// Increases the stock of the product with the specified ID in the database
        /// </summary>
        /// <param name="id">The ID of the product to increase the stock of</param>
        /// <returns>True if the stock was increased successfully, false otherwise</returns>
        public async Task<bool> IncreaseStockOnProductById(int id)
        {
            bool status = false;
            Product p = GetProductByID(id).Result;
            try
            {
                await dBAccessProduct.IncreaseStockOnProductById(p);
                status = true;
            }
            catch
            {
                status = false;
            }
            return status;
        }

    }
}
