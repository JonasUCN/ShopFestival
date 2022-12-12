using WebShop.Models;

namespace WebShop.LogicControllers
{
    public interface IProductLogicController
    {
        List<Product> GetProductsFromService();

        Product GetProductFromServiceByID(int id);
        List<Product> AddProductToCart(int id, HttpContext http);
    }
}