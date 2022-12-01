using RestSharp;
using WebShop.ServiceLayer;

namespace WebShop.ServiceLayer
{
    public class DBSaleOrderAccess : IDBSaleOrderAccess
    {
        public static void addSaleOrder(string saleOrderJson)
        {
            string url = "https://localhost:5001/api/SaleOrder/AddOrder/" + saleOrderJson;
            var client = new RestClient(url);
            var response = client.Post(new RestRequest());
    }
}}
