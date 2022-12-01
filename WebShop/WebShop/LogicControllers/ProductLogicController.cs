using ModelLayer;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Session;
using WebShop.ServiceLayer;

namespace WebShop.LogicControllers
{
    public class ProductLogicController : IProductLogicController
    {
        public List<Product> GetProductsFromService()
        {
            List<Product> products = DBProductAccess.getAllProductsFromAPI();
            return products;
        }

        public Product GetProductFromServiceByID(int id)
        {
            Product product = DBProductAccess.GetProductFromAPIByID(id);
            return product;
        }

        
    }
}
