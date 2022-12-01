using ModelLayer;

namespace WebShop.LogicControllers
{
    public interface IProductLogicController
    {
        List<Product> GetProductsFromService();

        Product GetProductFromServiceByID(int id);
    }
}
