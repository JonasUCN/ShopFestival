using Database_Service.DataAccess;
using Microsoft.IdentityModel.Tokens;
using Database_Service.Model;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Database_Service.Security
{
    /// <summary>
    /// Represents a JSON Web Token (JWT) used for authenticating and authorizing users.
    /// </summary>
    public class JwtToken
    {
 

        private readonly IConfiguration _configuration;
        private IDBASP_NetUser dBASP_NetUser;

        /// <summary>
        /// Initializes a new instance of the <see cref="JwtToken"/> class.
        /// </summary>
        /// <param name="inConfiguration">The configuration to use for creating the security key.</param>
        /// <param name="dBASP_NetUser">The database user to use for accessing user information.</param>
        public JwtToken(IConfiguration inConfiguration,IDBASP_NetUser dBASP_NetUser)
        {
            _configuration = inConfiguration;
            this.dBASP_NetUser = dBASP_NetUser;
        }

        /// <summary>
        /// Creates a security key using the provided configuration.
        /// </summary>
        /// <returns>The security key to use for signing the JWT.</returns>
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

        /// <summary>
        /// Check if the provided username matches the username of the User object retrieved from dBASP_NetUser.GetUser(username).
        /// </summary>
        /// <param name="username">The username to check.</param>
        /// <returns>True if the provided username matches the username of the User object, false otherwise.</returns>
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

        /// <summary>
        /// Check if the "LoggedInUser" property in the JWT contained in the authHeader string is equal to "LoggedInUser".
        /// </summary>
        /// <param name="authHeader">The authorization header containing the JWT to check.</param>
        /// <returns>True if the "LoggedInUser" property in the JWT is equal to "LoggedInUser", false otherwise.</returns>
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
