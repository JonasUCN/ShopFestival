using Microsoft.Extensions.Configuration;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp.ServiceLayer
{
    public class TokenAccess
    {
        readonly IConfiguration configuration;

        public TokenAccess(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string GetToken()
        {
            var client = new RestClient("https://localhost:5001");

            var request = new RestRequest("/token", Method.Post);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("username", "jonas@email.dk");
            request.AddParameter("password", "ffa8ffe4-ccea-42e3-b446-d3759f5646fe");
            request.AddParameter("grant_type", "DesktopApp");
            var response = client.Execute(request).Content;
            string Token = response.Replace("\"", "");
            return Token;

        }

    }
}
