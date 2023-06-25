using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RedMango_API_practice.Controllers
{
    [Route("api/AuthTest")]
    [ApiController]
    public class AuthTestController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<string>> GetSomething()
        {
            return "You are authenticated";
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<string>> GetSomething(int someIntValue)
        {
            return "You are Authorized with Role of Admin";
        }
    }
}
