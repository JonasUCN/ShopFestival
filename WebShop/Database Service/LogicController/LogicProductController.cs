using Database_Service.DataAccess;
using ModelLayer;

namespace Database_Service.LogicController
{
    public class LogicProductController : ILogicProductController
    {
        private readonly DBAccessProduct dBAccessProduct;

        public LogicProductController()
        {
            dBAccessProduct = new DBAccessProduct();
        }

        public async Task<List<Product> >GetAllProducts()
        {
            List<Product> products = await dBAccessProduct.GetAllProducts();
            return  products;

        }

        public async Task<Product> GetProductByID(int id)
        {
            Product p = await dBAccessProduct.GetProductByID(id);
            return p;
        }

        public async Task<bool> CreateProduct(Product product)
        {
            bool succes = await dBAccessProduct.CreateProduct(product);
            return succes;
        }

        public async Task<bool> RemoveStockOnProductById(int id)
        {
            bool status = false;
            Product p = GetProductByID(id).Result;
            if (p.Stock <= 0)
            {
                return false;
            }
            try
            {
                await dBAccessProduct.RemoveStockOnProductById(p);
                status = true;
            }
            catch 
            {
                status = false;
            }
            return status;
        }

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
