using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Database_Service.JWTHelper
{
    public static class JwtToken
    {
        private const string SECRET_KEY = "eb4b19c2-4001-49e5-a72b-2b83dd1d3975";

        public static readonly SymmetricSecurityKey SIGNING_KEY =
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SECRET_KEY));

        public static string GenerateJwtToken()
        {

            var credentials = new SigningCredentials
                (SIGNING_KEY, SecurityAlgorithms.HmacSha256);

            // Finally create a Token
            JwtHeader header = new JwtHeader(credentials);

            // Token will be good for xx minutes
            DateTime expiry = DateTime.UtcNow.AddMinutes(10);
            int ts = (int)(expiry - new DateTime(1970, 1, 1)).TotalSeconds;

            // Create payload with claims
            var payload = new JwtPayload {
                { "sub", "testSubject" },
                { "Name", "Scott" },
                { "email", "smithtest@tesst.com" },
                { "exp", ts },
                { "iss", "https://localhost:5001" }, // Issuer - the party that generates the JWT
                { "aud", "https://localhost:5001" }  // Audience - The address of the resource
            };
            var secToken = new JwtSecurityToken(header, payload);

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            var tokenString = handler.WriteToken(secToken);

            return tokenString;
        }

    }
}
