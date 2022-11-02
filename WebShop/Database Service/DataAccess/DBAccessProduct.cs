using System.Data.SqlClient;
using Dapper;
using ModelLayer;
using Microsoft.Extensions.Configuration;



namespace Database_Service.DataAccess
{
    public class DBAccessProduct
    {
        ConfigurationManager configuration = new ConfigurationManager();

        public string connectionString;
        public DBAccessProduct()
        {
            string String = configuration["ConnectionStringToUse"];
            connectionString = "Server=hildur.ucn.dk; Database=DMA-CSD-S211_10407530;User=DMA-CSD-S211_10407530;Password=Password1!;TrustServerCertificate=true;"; //configuration.GetConnectionString(String);

        }
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
        public async Task CreateProduct(Product product)
        {
            string sql = "INSERT INTO[dbo].[Product] ([Price],[Stock],[ProductDesc],[Brand],[Title]) VALUES (@Price,@Stock,@ProductDesc,@Brand,@Title)";


            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                connection.Execute(sql, new
                {
                    product.Price,
                    product.Stock,
                    product.ProductDesc,
                    product.Brand,
                    product.Title

                });
            }

        }


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

