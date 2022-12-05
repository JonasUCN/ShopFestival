using Microsoft.AspNetCore.Identity;
using RestSharp;

namespace WebShop.Services
{
    public class DBSaleOrderAccess
    {
        public static void addSaleOrder(string saleOrderJson, IdentityUser user)
        {
            string url = "https://localhost:5001/api/SaleOrder/AddOrder/" + saleOrderJson;
            var client = new RestClient(url);
            var request = new RestRequest();
            request.AddHeader("Authorization", $"Bearer {ServiceToken.GetTokenLoggedInUser(user)}");
            var response = client.Post(request);
        }
}}
