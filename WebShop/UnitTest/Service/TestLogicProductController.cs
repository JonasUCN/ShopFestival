using Database_Service.DataAccess;
using Database_Service.LogicController;
using Database_Service.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.Service
{
    
        public class LogicProductControllerTests
        {
            [Fact]
            public async Task TestGetAllProducts()
            {
            // Arrange
            List<Product> expectedProducts = JsonConvert.DeserializeObject<List<Product>>("[{\"id\":1,\"Price\":299,\"Stock\":401,\"ProductDesc\":\"Det her er en ølbong\",\"Brand\":\"Bongmesteren\",\"Title\":\"Ølbong\"},{\"id\":2,\"Price\":350,\"Stock\":65,\"ProductDesc\":\"Det her er et telt til 2 personer\",\"Brand\":\"Teltmesteren\",\"Title\":\"Telt 2 personer\"},{\"id\":3,\"Price\":150,\"Stock\":0,\"ProductDesc\":\"Jeg er en festival stol\",\"Brand\":\"Stolemesteren\",\"Title\":\"Festival stol\"},{\"id\":4,\"Price\":99,\"Stock\":946,\"ProductDesc\":\"Jeg er en festival stol til børn\",\"Brand\":\"Stolemesteren\",\"Title\":\"Festival stol til børn\"}]");

                var controller = new FakeProd();

                // Act
                var products = await controller.GetAllProducts();

                // Assert
                Assert.NotNull(products);

                // Assert that the returned list of products matches the expected values
                Assert.Equal(expectedProducts, products);
            }
        }






    public class FakeProd : IDBAccessProduct
    {
        public Task<bool> CreateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public Task DeleteProductById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Product>> GetAllProducts()
        {
            List<Product> products1 = JsonConvert.DeserializeObject<List<Product>>("[{\"id\":1,\"Price\":299,\"Stock\":401,\"ProductDesc\":\"Det her er en ølbong\",\"Brand\":\"Bongmesteren\",\"Title\":\"Ølbong\"},{\"id\":2,\"Price\":350,\"Stock\":65,\"ProductDesc\":\"Det her er et telt til 2 personer\",\"Brand\":\"Teltmesteren\",\"Title\":\"Telt 2 personer\"},{\"id\":3,\"Price\":150,\"Stock\":0,\"ProductDesc\":\"Jeg er en festival stol\",\"Brand\":\"Stolemesteren\",\"Title\":\"Festival stol\"},{\"id\":4,\"Price\":99,\"Stock\":946,\"ProductDesc\":\"Jeg er en festival stol til børn\",\"Brand\":\"Stolemesteren\",\"Title\":\"Festival stol til børn\"}]");
            return products1;
        }

        public Task<Product> GetProductByID(int id)
        {
            throw new NotImplementedException();
        }

        public Task IncreaseStockOnProductById(Product product)
        {
            throw new NotImplementedException();
        }

        public Task UpdateProductById(Product product)
        {
            throw new NotImplementedException();
        }
    }

}
