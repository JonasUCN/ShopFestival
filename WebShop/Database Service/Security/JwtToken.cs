using Database_Service.DataAccess;
using Microsoft.IdentityModel.Tokens;
using Database_Service.Model;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Database_Service.Security
{
    public class JwtToken
    {
 

        private readonly IConfiguration _configuration;
        private IDBASP_NetUser dBASP_NetUser;

        // Fetches configuration from more sources
        public JwtToken(IConfiguration inConfiguration,IDBASP_NetUser dBASP_NetUser)
        {
            _configuration = inConfiguration;
            this.dBASP_NetUser = dBASP_NetUser;
        }

        // Create key for signing
        public SymmetricSecurityKey GetSecurityKey()
        {
            SymmetricSecurityKey SIGNING_KEY = null;
            if (_configuration != null)
            {
                string SECRET_KEY = _configuration["SECRET_KEY"];
                SIGNING_KEY = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SECRET_KEY));
            }
            return SIGNING_KEY;
        }


        public bool IsValidUsername(string username)
        {
            User user = dBASP_NetUser.GetUser(username);

            if (user.UserName.Equals(username))
            {
                return true;
            }
            else
            {
                return false;
            }
            
            
            
        }


        public static bool ValidateGrantType(string authHeader)
        {
            bool AuthorizeSuccess = false;
            var parts = authHeader.Split(' ');
            var accessToken = parts[1];

            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(accessToken);
            var payload = token.Payload;
            Debug.WriteLine(payload);
            foreach (var PayloadItem in payload)
            {
                if (PayloadItem.Value.Equals("LoggedInUser"))
                {
                    AuthorizeSuccess = true;
                    break;
                }
            }

            return AuthorizeSuccess;
        }


    }
}
