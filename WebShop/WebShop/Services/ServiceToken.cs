using Microsoft.AspNetCore.Identity;
using RestSharp;

namespace WebShop.Services
{
    public static class ServiceToken
    {
        
        //public static string GetToken()
        //{
        //    string url = "https://localhost:5001/jwt";
        //    var client = new RestClient(url);

        //    var response = client.Get(new RestRequest());
        //    string responseToken = response.Content;
        //    string FinalToken = responseToken.Replace("\"", "");

        //    return FinalToken;
        //}

        public static string GetTokenDefaultUser()
        {
            var client = new RestClient("https://localhost:5001");

            var request = new RestRequest("/token", Method.Post);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("username", "jonas@email.dk");
            request.AddParameter("password", "ffa8ffe4-ccea-42e3-b446-d3759f5646fe");
            request.AddParameter("grant_type", "DefaultUser");
            var response = client.Execute(request);
            string Token = response.Content.Replace("\"", "");
            return Token;

        }
        public static string GetTokenLoggedInUser(System.Security.Claims.ClaimsPrincipal user)
        {
            var client = new RestClient("https://localhost:5001");

            var request = new RestRequest("/token", Method.Post);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("username", $"{user.Identity.Name}");
            request.AddParameter("password", "ffa8ffe4-ccea-42e3-b446-d3759f5646fe");
            request.AddParameter("grant_type", "DefaultUser");
            var response = client.Execute(request);
            string Token = response.Content.Replace("\"", "");
            return Token;

        }
    }
}
