using Database_Service.JWTHelper;
using Microsoft.IdentityModel.Tokens;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Configure the JWT Authentication Service
builder.Services.AddAuthentication(options => {
    options.DefaultAuthenticateScheme = "JwtBearer";
    options.DefaultChallengeScheme = "JwtBearer";
})
    .AddJwtBearer("JwtBearer", jwtOptions => {
        jwtOptions.TokenValidationParameters = new TokenValidationParameters()
        {
            // The SigningKey is defined in the TokenController class
            IssuerSigningKey = JwtToken.SIGNING_KEY,
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidIssuer = "https://localhost:5001",
            ValidAudience = "https://localhost:5001",
            ValidateLifetime = true
        };
    });





var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
