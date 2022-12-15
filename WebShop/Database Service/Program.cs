using Database_Service.DataAccess;
using Database_Service.Security;
using Microsoft.IdentityModel.Tokens;


/// <summary>
/// Creates a web application builder and adds some services to it, including JWT authentication.
/// </summary>
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configure JWT authentication using the JwtBearer scheme
builder.Services.AddAuthentication(options => {
    options.DefaultAuthenticateScheme = "JwtBearer";
    options.DefaultChallengeScheme = "JwtBearer";
})
    .AddJwtBearer("JwtBearer", jwtOptions => {
        // Set the signing key, issuer, and audience for the JWT token
        jwtOptions.TokenValidationParameters = new TokenValidationParameters()
        {
            // Use the JwtToken and DBASP_NetUser classes to generate the signing key
            IssuerSigningKey = new JwtToken(builder.Configuration, new DBASP_NetUser(builder.Configuration)).GetSecurityKey(),
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidIssuer = "https://localhost:5001",
            ValidAudience = "https://localhost:5001",
            ValidateLifetime = true
        };
    });

// Build the web application
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
// Start the web application
app.Run();