using RestSharp;

namespace WebShop.Services
{
    public static class ServiceToken
    {
        public static string GetToken()
        {
            string url = "https://localhost:5001/jwt";
            var client = new RestClient(url);

            var response = client.Get(new RestRequest());
            string responseToken = response.Content;
            string FinalToken = responseToken.Replace("\"", "");

            return FinalToken;
        }
    }
}
