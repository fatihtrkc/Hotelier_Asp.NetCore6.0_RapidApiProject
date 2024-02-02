using JsonWebToken.WebApi.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JsonWebToken.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet("GenerateToken")]
        public IActionResult GenerateToken()
        {
            return Ok(HelperToken.Add());
        }

        [Authorize]
        [HttpGet("Test")]
        public IActionResult Test()
        {
            return Ok("Welcome");
        }

        [HttpGet("GenerateTokenForAdmin")]
        public IActionResult GenerateTokenForAdmin()
        {
            return Ok(HelperToken.AddForAdmin());
        }

        [Authorize(Roles = "Admin, Customer")]
        [HttpGet("TestForAdmin")]
        public IActionResult TestForAdmin()
        {
            return Ok("Welcome");
        }
    }
}
