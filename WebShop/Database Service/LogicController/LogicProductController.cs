using Database_Service.DataAccess;
using Model;

namespace Database_Service.LogicController
{
    public class LogicProductController
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

    }
}
