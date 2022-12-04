using ModelLayer;
using RestSharp;

namespace WebShop.ServiceLayer
{
    public interface IDBProductAccess
    {
        Product GetProductFromAPIByID(int id);

        RestResponse RemoveStockByID(int id);

        List<Product> getAllProductsFromAPI();

    }
}
