using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWT.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class Demo2Controller : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Test()
        {
            return Ok("6");
        }
    }
}
