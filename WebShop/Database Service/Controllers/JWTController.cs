using Database_Service.DataAccess;
using Database_Service.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace Database_Service.Controllers
{

    public class JWTController : ControllerBase
    {




        private readonly IConfiguration _configuration;

        // Fetches configuration from more sources
        public JWTController(IConfiguration inConfiguration)
        {
            _configuration = inConfiguration;
        }

        [Route("/token")]
        [HttpPost]
        // Generate and return a JWT token
        public IActionResult Create([FromForm] string username, string grant_type)
        {

            bool ValidInput = ((!String.IsNullOrWhiteSpace(username)));
            // Only return JWT token if credentials are valid
            JwtToken Token = new JwtToken(_configuration, new DBASP_NetUser(_configuration));
            if (ValidInput && Token.IsValidUsername(username))
            {
                string jwtToken = GenerateToken(username, grant_type);
                return new ObjectResult(jwtToken);
            }
            else
            {
                return BadRequest();
            }


        }

        private string GenerateToken(string username, string grantType)
        {
            string tokenString;
            JwtToken tokenHelper = new JwtToken(_configuration, new DBASP_NetUser(_configuration));

            // Create header with algorithm and token type - and secret added
            SymmetricSecurityKey SIGNING_KEY = tokenHelper.GetSecurityKey();
            SigningCredentials credentials = new SigningCredentials(SIGNING_KEY, SecurityAlgorithms.HmacSha256);
            JwtHeader header = new JwtHeader(credentials);

            // Time to live for newly created JWT Token
            int ttlInMinutes = 10;
            DateTime expiry = DateTime.UtcNow.AddMinutes(ttlInMinutes);
            int ts = (int)(expiry - new DateTime(1970, 1, 1)).TotalSeconds;

            var payload = new JwtPayload {
                { "sub", "testSubject" },
                { "Name", username },
                { "email", "smithtest@tesst.com" },
                { "granttype", grantType },
                { "exp", ts },
                { "iss", "https://localhost:5001" }, // Issuer - the party that generates the JWT
                { "aud", "https://localhost:5001" }  // Audience - The address of the resource
            };

            JwtSecurityToken secToken = new JwtSecurityToken(header, payload);

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            tokenString = handler.WriteToken(secToken);

            return tokenString;
        }
    }

}
