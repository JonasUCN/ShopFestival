using System.Data.SqlClient;
using Dapper;
using Database_Service.Model;
using Microsoft.Extensions.Configuration;



namespace Database_Service.DataAccess
{
    /// <summary>
    /// This namespace contains classes for accessing data in a database.
    /// </summary>
    public class DBAccessProduct
    {
        /// <summary>
        /// This class provides methods for accessing and manipulating data in a database.
        /// </summary>
        private ConfigurationManager configuration = new ConfigurationManager();

        private string connectionString;
        public DBAccessProduct()
        {
            string String = configuration["ConnectionStringToUse"];
            connectionString = "Server=hildur.ucn.dk; Database=DMA-CSD-S211_10407530;User=DMA-CSD-S211_10407530;Password=Password1!;TrustServerCertificate=true;"; 
        }

        /// <summary>
        /// This method retrieves a list of all products from the database.
        /// </summary>
        public async Task<List<Product>> GetAllProducts()
        {
            string sql = "select * from Product";
            List<Product> products = new List<Product>();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                products = (List<Product>)connection.Query<Product>(sql);
            }

            return products;

        }
        /// <summary>
        /// This method retrieves a product from the database with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the product to retrieve.</param>
        /// <returns>The product with the specified ID.</returns>
        public async Task<Product> GetProductByID(int id)
        {
            string sql = "select * from Product where id = @id";
            Product product;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                product = connection.QuerySingle<Product>(sql, new { id = id });
            }
            return product;
        }

        /// <summary>
        /// This method updates a product in the database with the specified ID.
        /// </summary>
        /// <param name="product">The updated product information.</param>
        public async Task UpdateProductById(Product product)
        {
            string sql = "UPDATE [dbo].[Product] SET [Price] = @Price,[Stock] =@Stock,[ProductDesc] =@ProductDesc ,[Brand] =@Brand ,[Title] = @Title WHERE id = @id;";


            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                connection.Execute(sql, new 
                { 
                    product.id,
                    product.Price,
                    product.Stock,
                    product.ProductDesc,
                    product.Brand,
                    product.Title
                
                });
            }
            
        }

        /// <summary>
        /// This method increases the stock of a product in the database with the specified ID.
        /// </summary>
        /// <param name="product">The product whose stock should be increased.</param>
        public async Task IncreaseStockOnProductById(Product product)
        {
            string sql = "UPDATE [dbo].[Product] SET [Stock] =@Stock + 1 WHERE id = @id;";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                connection.Execute(sql, new
                {
                    product.id,
                    product.Price,
                    product.Stock,
                    product.ProductDesc,
                    product.Brand,
                    product.Title
                });
            }
        }

        /// <summary>
        /// This method creates a new product in the database.
        /// </summary>
        /// <param name="product">The product to be created.</param>
        /// <returns>A boolean value indicating whether the product was successfully created.</returns>
        public async Task<bool> CreateProduct(Product product)
        {
            string sql = "INSERT INTO[dbo].[Product] ([Price],[Stock],[ProductDesc],[Brand],[Title]) VALUES (@Price,@Stock,@ProductDesc,@Brand,@Title)";
            bool succes = false;

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var result = connection.Execute(sql, new
                {
                    product.Price,
                    product.Stock,
                    product.ProductDesc,
                    product.Brand,
                    product.Title

                });
                if (result > 0)
                {
                    succes = true;
                }
            }

            return succes;
        }

        /// <summary>
        /// This method deletes a product from the database with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the product to be deleted.</param>
        public async Task DeleteProductById(int id)
        {
            string sql = "Delete from Product where id = @id";
            Product product;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                connection.Execute(sql, new { id = id });
            }
           
        }


    }
}

