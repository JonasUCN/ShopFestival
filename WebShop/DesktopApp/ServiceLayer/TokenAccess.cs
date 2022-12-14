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
    /// <summary>
    /// The `TokenAccess` class provides methods for accessing and retrieving tokens for authorization.
    /// </summary>
    public class TokenAccess
    {
        /// <summary>
        /// The application configuration to use.
        /// </summary>
        readonly IConfiguration configuration;

        /// <summary>
        /// Constructs a new `TokenAccess` instance.
        /// </summary>
        /// <param name="configuration">The application configuration to use.</param>
        public TokenAccess(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        /// <summary>
        /// Retrieves a token for use in authorization.
        /// </summary>
        /// <returns>A token that can be used in authorization.</returns>
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
