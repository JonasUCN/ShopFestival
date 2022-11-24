using RestSharp;

namespace WebShop.Services
{
    public class DBSaleOrderAccess
    {
        public static void addSaleOrder(string saleOrderJson)
        {
            string url = "https://localhost:5001/api/SaleOrder/AddOrder/" + saleOrderJson;
            var client = new RestClient(url);
            var response = client.Post(new RestRequest());
    }
}}
