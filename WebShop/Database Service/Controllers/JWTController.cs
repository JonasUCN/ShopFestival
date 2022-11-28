using Database_Service.JWTHelper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Database_Service.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class JWTController : ControllerBase
    {

        [HttpGet]

        public IActionResult Jwt()
        {
            return new ObjectResult(JwtToken.GenerateJwtToken());
        }

    }
}
