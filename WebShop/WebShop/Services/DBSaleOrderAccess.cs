using RestSharp;

namespace WebShop.Services
{
    public class DBSaleOrderAccess
    {
        public static int addSaleOrder()
        {
            string url = "https://localhost:5001/api/SaleOrder/AddOrder/2";
            var client = new RestClient(url);
            var response = client.Get(new RestRequest());
            int id = Convert.ToInt32(response.Content);
            return id;
    }
}}
