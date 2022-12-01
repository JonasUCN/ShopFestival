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

        //public string GetToken()
        //{
        //    var client = new RestClient("https://localhost:5001");

        //    var request = new RestRequest("/token", Method.Post);
        //    request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
        //    request.AddParameter("username", "jonas@email.dk");
        //    request.AddParameter("password", "ffa8ffe4-ccea-42e3-b446-d3759f5646fe");
        //    request.AddParameter("grant_type", "test");
        //    var response = client.Execute(request).Content;
        //    string Token = response.Replace("\"", "");
        //    return Token;

        //}
    }
}
