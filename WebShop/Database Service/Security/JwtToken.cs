using Database_Service.DataAccess;
using Microsoft.IdentityModel.Tokens;
using ModelLayer;
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


        public bool IsValidUsernameAndPassword(string username)
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





    }
}
