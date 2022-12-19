using Microsoft.AspNetCore.Identity;
using RestSharp;

namespace WebShop.ServiceLayer
{
    public static class ServiceToken
    {
        /// <summary>
        /// This static method retrieves a token for a default user from a specified server.
        /// </summary>
        /// <returns>A string containing the retrieved token.</returns>
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

        /// <summary>
        /// This static method retrieves a token for a logged-in user from a specified server.
        /// </summary>
        /// <param name="user">The IdentityUser object representing the logged-in user.</param>
        /// <returns>A string containing the retrieved token.</returns>
        public static string GetTokenLoggedInUser(IdentityUser user)
        {
            var client = new RestClient("https://localhost:5001");

            var request = new RestRequest("/token", Method.Post);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("username", $"{user.Email}");
            request.AddParameter("password", "ffa8ffe4-ccea-42e3-b446-d3759f5646fe");
            request.AddParameter("grant_type", "LoggedInUser");
            var response = client.Execute(request);
            string Token = response.Content.Replace("\"", "");
            return Token;

        }
    }
}